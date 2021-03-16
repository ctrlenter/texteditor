using FastColoredTextBoxNS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextEditor.Core.XML;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using static TextEditor.Core.ShowAllForm;
using System.Text.RegularExpressions;

namespace TextEditor.Core
{
    public static class Utils
    {

        public static bool IsValidRegex(string pattern)
        {
            if (string.IsNullOrEmpty(pattern)) return false;

            try
            {
                Regex.Match("", pattern);
            }
            catch (ArgumentException)
            {
                return false;
            }

            return true;
        }

        public static char[] CommentChars = { ';', '(', '*' };
        public static bool DoesLineContainComment(this string str, LineDef def)
        {

            var res = false;
            var line = def.strContent;
            var index = line.IndexOf(def.Token);
            while (index >= 0)
            {
                char charAt = line.ElementAt(index);
                if (CommentChars.Contains(charAt))
                {
#if DEBUG
                    console.log("Line: " + def.iLine + ":Char was in array. " + charAt + "::Token: " + def.Token);
#endif
                    //This means that the line contains the comment.
                    //Then just ignore it.
                    return true;
                }
                else
                {
                    res = false;
                }
                index--;
            }

            return res;
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool FlashWindowEx(ref FLASHWINFO pwfi);

        //Flash both the window caption and taskbar button.
        //This is equivalent to setting the FLASHW_CAPTION | FLASHW_TRAY flags. 
        public const UInt32 FLASHW_ALL = 3;

        // Flash continuously until the window comes to the foreground. 
        public const UInt32 FLASHW_TIMERNOFG = 12;

        [StructLayout(LayoutKind.Sequential)]
        public struct FLASHWINFO
        {
            public UInt32 cbSize;
            public IntPtr hwnd;
            public UInt32 dwFlags;
            public UInt32 uCount;
            public UInt32 dwTimeout;
        }

        public static bool FlashWindowEx(Form form)
        {
            IntPtr hwnd = form.Handle;
            FLASHWINFO fInfo = new FLASHWINFO();

            fInfo.cbSize = Convert.ToUInt32(Marshal.SizeOf(fInfo));
            fInfo.hwnd = hwnd;
            fInfo.dwFlags = FLASHW_ALL | FLASHW_TIMERNOFG;
            fInfo.uCount = UInt32.MaxValue;
            fInfo.dwTimeout = 0;

            return FlashWindowEx(ref fInfo);
        }

        public static string machinesFile = $"{Application.StartupPath}\\machines.xml";
        public static string panelsFile = $"{Application.StartupPath}\\panels.xml";

        public static List<ProgramPanel> LoadPanels()
        {
            var list = new List<ProgramPanel>();

            if (File.Exists(panelsFile))
            {
                list = XMLSerializer.LoadTabsFromXml(panelsFile);
            }

            return list;
        }

        public static List<Machine> LoadMachines()
        {
            if (File.Exists(machinesFile))
            {
                return XMLSerializer.LoadMachinesFromFile(machinesFile);
            }
            return new List<Machine>();
        }

        public static void WriteFile(string path, FastColoredTextBox fctb)
        {
            try
            {
                using (var writer = new StreamWriter(path))
                {
                    writer.WriteLine(fctb.Text);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }

        public static bool CopyFile(string srcPath, string tgtPath)
        {
            try
            {
                if (!File.Exists(tgtPath))
                {
                    File.Copy(srcPath, tgtPath);
                    return true;
                }
                else
                {
                    var res = MessageBox.Show($"File already exists at {tgtPath}\nDo you wanna overwrite?", "Error", MessageBoxButtons.YesNoCancel);
                    if (res == DialogResult.Yes)
                    {
                        File.Copy(srcPath, tgtPath, true);
                        return true;
                    }
                    else if (res == DialogResult.No)
                    {
                        File.Delete(tgtPath);
                        File.Copy(srcPath, tgtPath);
                        return true;
                    }
                    else if (res == DialogResult.Cancel)
                    {
                        return false;
                    }
                    return false;
                }

            }
            catch (UnauthorizedAccessException e)
            {
                MessageBox.Show("You do not have permission to write to this folder", "Error");
                return false;
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show("The wanted file to copy, was not found!", "Error");
                return false;
            }
            catch (IOException e)
            {
                MessageBox.Show($"{e.Message}", "Error");
                return false;
            }

        }

        public static FastColoredTextBox CreateTextBox(ContextMenuStrip strip, MouseEventHandler tab_mouseDown, KeyEventHandler keyDown, DragEventHandler dragEnter, DragEventHandler dragDrop)
        {

            var fctb = new FastColoredTextBox();
            fctb.Language = Language.JS;
            fctb.ContextMenuStrip = strip;
            fctb.Dock = DockStyle.Fill;
            fctb.KeyDown += keyDown;
            fctb.AllowDrop = true;
            fctb.DragEnter += dragEnter;
            fctb.DragDrop += dragDrop;
            fctb.MouseDoubleClick += tab_mouseDown;

            return fctb;
        }

        public static TabPage CreateTabPage(ContextMenuStrip strip, MouseEventHandler tab_mouseDown, KeyEventHandler keyDown, DragEventHandler dragEnter, DragEventHandler dragDrop, int prevTab)
        {
            var tabPage = new TabPage($"[Unnamed {prevTab}]");
            tabPage.Tag = null;
            //TODO: Remove tab_mouseDown param

            var fctb = CreateTextBox(strip, tab_mouseDown, keyDown, dragEnter, dragDrop);

            tabPage.Controls.Add(fctb);

            return tabPage;
        }

        public static TabPage CreateTabPageAndLoadFile(ContextMenuStrip strip, MouseEventHandler tab_mouseDown, KeyEventHandler keyDown, DragEventHandler dragDrop, DragEventHandler dragEnter, string path)
        {
            var tabPage = new TabPage("[Unnamed]");
            tabPage.Tag = null;
            tabPage.ToolTipText = path;
            //TODO: Remove tab_mouseDown param

            var fctb = CreateTextBox(strip, tab_mouseDown, keyDown, dragEnter, dragDrop);

            tabPage.Controls.Add(fctb);
            HandleFileRead(fctb, path);

            tabPage.Focus();

            return tabPage;
        }

        public static void HandleFileRead(FastColoredTextBox fctb, string path)
        {
            var content = ReadFile(path);

            fctb.Parent.Tag = path;
            fctb.Parent.Text = Path.GetFileName(path);

            fctb.Text = content;

            fctb.IsChanged = false;

        }

        public static void WriteText(string path, string content)
        {
            var set = new PermissionSet(PermissionState.None);
            var writePermission = new FileIOPermission(FileIOPermissionAccess.Write, path);
            set.AddPermission(writePermission);

            if (set.IsSubsetOf(AppDomain.CurrentDomain.PermissionSet))
            {
                File.WriteAllText(path, content);
                /*using (var writer = new StreamWriter(new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write)))
                {
                    writer.WriteLine(content);
                }*/
            }
        }


        public static string ReadFile(string path)
        {
            using (var reader = new StreamReader(path))
            {
                return reader.ReadToEnd();
            }
        }

        public static string TryOpenFile(OpenFileDialog dialog)
        {
            if (dialog.ShowDialog() != DialogResult.OK)
                return "";

            var str = dialog.FileName;
            return str;
        }

        public static bool TrySave(FastColoredTextBox fctb, SaveFileDialog dialog)
        {
            //dialog.Filter = dialog.Filter.Insert(0, $"{Path.GetExtension(fctb.Parent.Text)} File|*{Path.GetExtension(fctb.Parent.Text)}|");
            //dialog.FileName = fctb.Parent.Text;
            if (fctb.Parent.Tag == null)
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                    return false;

                fctb.Parent.Tag = dialog.FileName;
                fctb.Parent.Text = Path.GetFileName(dialog.FileName);

            }

            WriteText(Path.GetFullPath(fctb.Parent.Tag as string), fctb.Text);
            fctb.IsChanged = false;

            fctb.Invalidate();

            return true;
        }

        //public static bool TrySaveAs ( TabPage page , SaveFileDialog dialog )
        //{
        //    page.Tag = null;
        //    if ( dialog.ShowDialog ( ) != DialogResult.OK )
        //        return false;

        //    FastColoredTextBox fctb = null;

        //    if ( page.Controls.Count > 0 )
        //    {
        //        page.Tag = dialog.FileName;
        //        fctb = page.Controls [ 0 ] as FastColoredTextBox;

        //    }
        //    WriteText ( page.Tag as string , fctb.Text );
        //    fctb.IsChanged = false;
        //    fctb.Invalidate ( );
        //    return true;
        //}
    }
}

