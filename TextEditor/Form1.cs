using FastColoredTextBoxNS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextEditor.Core;
using TextEditor.Core.XML;
using TextEditor.Properties;
using static TextEditor.Core.ShowAllForm;

namespace TextEditor
{
    public partial class Form1 : Form
    {


        public static string RegexPattern = "(TOOL CALL \".*?\")|(TOOL CALL \'.*?\')|([T][0-9]+)|(TOOL CALL [0-9]+)";
        public static string FailedRegexPattern = @"([{x}][0-9]+ )";

        public const string WindowTitle = "Cadsys Tools";

        public ShowAllForm showAllForm;

        public FastColoredTextBox CurrentTextbox
        {
            get
            {
                if (tabs.SelectedTab != null)
                    if (tabs.SelectedTab.Controls[0] as FastColoredTextBox != null)
                        return tabs.SelectedTab.Controls[0] as FastColoredTextBox;
                    else
                        return null;
                else
                    return null;
            }
        }

        CopyToSpecificFolder CopyToSpecificFolder;

        public static void AddTabMessage(string path)
        {
            var msg = new MessageHelper();
            int hWnd = msg.getWindowId(null, WindowTitle);
            int res = msg.sendWindowsStringMessage(hWnd, 0, path);
        }

        public static void SendMessage(string message)
        {
            MessageHelper helper = new MessageHelper();
            int hWnd = helper.getWindowId(null, WindowTitle);
            int res = helper.sendWindowsStringMessage(hWnd, 0, message);

        }

        protected override void WndProc(ref Message m)
        {

            switch (m.Msg)
            {
                case MessageHelper.WM_USER:
                    break;
                case MessageHelper.WM_COPYDATA:
                    var str = new MessageHelper.COPYDATASTRUCT();
                    var type = str.GetType();
                    str = (MessageHelper.COPYDATASTRUCT)m.GetLParam(type);
                    tabs.TabPages.Add(Utils.CreateTabPageAndLoadFile(textContextMenu, fctb_MouseDown, Event_KeyDown, DragDropEvent, DragEnterEvent, str.lpData));
                    tabs.SelectTab(tabs.TabPages.Count - 1);
                    //TODO: Implement a show up feature. have it show up or blink?
                    this.BringToFront();
                    this.TopLevel = true;
                    this.Focus();
                    tabs.SelectedTab.Focus();
                    Utils.FlashWindowEx(this);
                    break;
            }


            base.WndProc(ref m);
        }

        internal Settings settings;

        public Form1()
        {
            InitializeComponent();
            Init();
            CopyToSpecificFolder = new CopyToSpecificFolder(this, settingsForm.viewCopySettings.machines);
            Text = WindowTitle;
            ReloadPanels();


            Activated += this.Form1_Activated;

            Config.Init();

            if (Config["width"] != null
                && Config["height"] != null
                && Config["ontop"] != null
                && Config["use_startup_size"] != null)
            {

                console.log("Config elements: " + Config.ElementCount);

                var size = new Size();

                if (bool.TryParse(Config["use_startup_size"], out bool useStartupSize))
                {
                    if (useStartupSize)
                    {
                        if (int.TryParse(Config["startup_width"], out int width))
                        {
                            size.Width = width;
                        }
                        else
                        {
                            size.Width = 800;
                        }

                        if (int.TryParse(Config["startup_height"], out int height))
                        {
                            size.Height = height;
                        }
                        else
                        {
                            size.Height = 600;
                        }
                        settingsForm.viewMain.cbUseStartupSize.Checked = true;
                        settingsForm.viewMain.tbStartupHeight.Enabled = true;
                        settingsForm.viewMain.tbStartupWidth.Enabled = true;
                    }
                    else
                    {
                        if (int.TryParse(Config["width"], out int width))
                        {
                            size.Width = width;
                        }
                        else
                        {
                            size.Width = 800;
                        }

                        if (int.TryParse(Config["height"], out int height))
                        {
                            size.Height = height;
                        }
                        else
                        {
                            size.Height = 600;
                        }
                        settingsForm.viewMain.cbUseStartupSize.Checked = false;
                        settingsForm.viewMain.tbStartupHeight.Enabled = false;
                        settingsForm.viewMain.tbStartupWidth.Enabled = false;
                    }
                }

                if (bool.TryParse(Config["ontop"], out bool ontop))
                {
                    this.TopMost = ontop;
                    rbOnTop.Checked = ontop;
                }
                else
                {
                    this.TopMost = false;
                }
                this.Size = size;
            }

            if(Config["start_pos"] != null)
            {
                var val = Config["start_pos"];
                if(val == ViewSettings.POS_CENTER)
                {
                    StartPosition = FormStartPosition.CenterScreen;
                }
                else if(val == ViewSettings.POS_LAST)
                {
                    StartPosition = FormStartPosition.Manual;
                    var newLoc = new Point();
                    if (Config.HasElements("X", "Y"))
                    {
                        var X = Config["X"];
                        var Y = Config["Y"];
                        int res;
                        if (int.TryParse(X, out res))
                            newLoc.X = res;
                        else
                            newLoc.X = 800;

                        if (int.TryParse(Y, out res))
                            newLoc.Y = res;
                        else
                            newLoc.Y = 600;

                    }
                }
            }

            var machines = Utils.LoadMachines();
            console.log(machines.Count());
            foreach (var mach in machines)
            {
                rcbPresets.DropDownItems.Add(new RibbonButton(mach.MachineName));
            }


        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            ThreadHelperClass.Focus(this, CurrentTextbox);

            if (CurrentTextbox.Parent.Tag != null)
                lblPath.Text = $"Path: {CurrentTextbox.Parent.Tag.ToString()}";
        }

        public void ReloadPanels()
        {
            if (File.Exists(Utils.panelsFile))
            {
                rtExternalApps.Panels.Clear();
                var tabs = XMLSerializer.LoadTabsFromXml(Utils.panelsFile);
                foreach (var tab in tabs)
                {
                    var rPanel = new RibbonPanel(tab.text);

                    rPanel.Text = tab.text;

                    foreach (var item in tab.Items)
                    {
                        if (File.Exists(item.path))
                        {
                            RibbonButton btn = null;

                            if (File.Exists(item.path))
                            {
                                var icon = Icon.ExtractAssociatedIcon(item.path).ToBitmap();

                                btn = new RibbonButton();

                                btn.SmallImage = icon;

                                btn.Image = icon;

                                btn.Tag = item.path;

                                btn.Text = item.text;
                            }
                            else
                            {
                                btn = new RibbonButton(Path.GetFileNameWithoutExtension(item.path));
                            }

                            btn.Tag = item.path as string;

                            btn.ToolTip = item.text;

                            btn.Click += btn_rb_click;

                            rPanel.Items.Add(btn);
                        }
                    }

                    rtExternalApps.Panels.Add(rPanel);


                }

            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (TabPage tab in tabs.TabPages)
            {
                if (tab.Controls.Count > 0)
                {
                    if (tab.Controls[0] != null)
                    {
                        var fctb = tab.Controls[0] as FastColoredTextBox;
                        if (fctb != null)
                        {
                            if (fctb.IsChanged)
                            {
                                switch (MessageBox.Show($"Do you want to save {tab.Text}?", "Save", MessageBoxButtons.YesNoCancel))
                                {
                                    case DialogResult.Yes:
                                        Utils.TrySave(fctb, saveFile);
                                        tabs.TabPages.Remove(tab);
                                        break;
                                    case DialogResult.No:
                                        tabs.TabPages.Remove(tab);
                                        continue;
                                    case DialogResult.Cancel:
                                        e.Cancel = true;
                                        break;
                                }
                            }
                        }
                    }
                }
            }

            Config["X"] = Location.X.ToString();
            Config["Y"] = Location.Y.ToString();
        }

        private void tabs_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage != null)
            {
                if (Application.OpenForms.OfType<ShowAllForm>().Count() == 1)
                {
                    Application.OpenForms.OfType<ShowAllForm>().First().Close();
                }

                if (e.TabPage.Tag != null)
                {
                    lblPath.Text = $"Path: {e.TabPage.Tag.ToString()}";
                }
            }

        }

        private void rbCopyDirect_Click(object sender, EventArgs e)
        {
            if (rcbPresets.SelectedItem != null)
            {
                var machines = Utils.LoadMachines();
                console.log("Found preset");
                console.log(machines.Count());

                var mach = machines.Find(r => r.MachineName == rcbPresets.SelectedItem.Text);
                if (mach != null)
                {
                    console.log("Found machine");
                    var path = mach.FolderPath;
                    if (!CurrentTextbox.IsChanged)
                    {
                        Utils.TrySave(CurrentTextbox, saveFile);
                        lblLastAction.Text = "Saved...";
                    }
                    if (tabs.SelectedTab.Text != "[Unnamed]")
                    {

                        if (tabs.SelectedTab.Tag != null)
                        {
                            if (Utils.CopyFile(tabs.SelectedTab.Tag as string, mach.FolderPath + @"\" + tabs.SelectedTab.Text))
                                MessageBox.Show("Copy was successful!");
                        }

                        else
                        {
                            if (tabs.SelectedTab.Tag != null)
                            {
                                if (Utils.CopyFile(tabs.SelectedTab.Tag as string, mach.FolderPath + @"\" + tabs.SelectedTab.Text))
                                    MessageBox.Show("Copy was successful!x");
                            }
                        }

                    }

                }
            }
            else
            {
                MessageBox.Show("Please select a preset to copy to", "Error");
            }
        }

        private void rcbDrives_Click(object sender, EventArgs e)
        {

        }

        private void rcbDrives_DropDownItemClicked(object sender, RibbonItemEventArgs e)
        {
            Logger.Log($"Selected {e.Item.Text}");
        }

        private void fctb_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                CurrentTextbox.ContextMenuStrip.Show(e.Location);
            }
        }

        private void tabs_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point ee = new Point(e.Location.X, e.Location.Y);
                for (int i = 0; i < tabs.TabPages.Count; i++)
                {
                    var r = tabs.GetTabRect(i);
                    if (r.Contains(ee))
                    {
                        tabContextMenu.Show(tabs, ee);
                        wantedPoint = ee;
                        page = tabs.TabPages[i];
                        break;
                    }
                }
            }
        }

        Point wantedPoint;
        TabPage page;

        private void closeTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (wantedPoint != null)
            {
                for (int i = 0; i < tabs.TabPages.Count; i++)
                {
                    var rect = tabs.GetTabRect(i);
                    if (rect.Contains(wantedPoint))
                    {
                        page = tabs.TabPages[i];
                        break;
                    }
                }
            }

            if (page != null)
            {
                var fctb = page.Controls[0] as FastColoredTextBox;
                if (fctb != null)
                {
                    if (fctb.IsChanged)
                    {
                        Utils.TrySave(fctb, saveFile);
                    }
                    tabs.TabPages.Remove(page);
                    if (tabs.TabPages.Count <= 0) tabs.TabPages.Add(Utils.CreateTabPage(textContextMenu, this.fctb_MouseDown, this.Event_KeyDown, DragEnterEvent, DragDropEvent, prevTab++));
                    else tabs.SelectTab(tabs.TabPages.Count - 1);
                }
            }

        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (TabPage tab in tabs.TabPages)
            {
                if (tab.Controls.Count > 0)
                {
                    if (tab.Controls[0] != null)
                    {
                        var fctb = tab.Controls[0] as FastColoredTextBox;
                        if (fctb != null)
                        {
                            if (fctb.IsChanged)
                            {
                                switch (MessageBox.Show($"Do you want to save {tab.Text}?", "Save", MessageBoxButtons.YesNoCancel))
                                {
                                    case DialogResult.Yes:
                                        Utils.TrySave(fctb, saveFile);
                                        tabs.TabPages.Remove(tab);
                                        break;
                                    case DialogResult.No:
                                        tabs.TabPages.Remove(tab);
                                        continue;
                                    case DialogResult.Cancel:
                                        break;
                                }
                            }
                            else
                            {
                                tabs.TabPages.Remove(tab);
                            }
                        }
                    }
                }
            }

            if (tabs.TabPages.Count == 0)
            {
                AddTab();
            }
        }

        private void revealInExploreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (page.Tag != null)
            {
                var path = page.Tag as string;
                if (File.Exists(path))
                {
                    string args = $"/select,\"{path}\"";
                    Process.Start("explorer.exe", args);

                }
            }
        }

        int currentLine = -1;


        private void RbUp_Click(object sender, EventArgs e)
        {
            if (rcbCNC.SelectedItem != null)
            {
                var item = settingsForm.Machines.SingleOrDefault(r => r.Name == rcbCNC.SelectedItem.Text);
                if (item != null)
                {
                    DoSearchUp(item, new List<int>());
                }
                else
                {
                    MessageBox.Show($"Could not find a machine with the name {rcbCNC.Text}");
                }
            }
        }

        private void RbDown_Click(object sender, EventArgs e)
        {
            if (rcbCNC.SelectedItem != null)
            {
                var mach = settingsForm.Machines.SingleOrDefault(r => r.Name == rcbCNC.SelectedItem.Text);
                if (mach != null)
                {
                    //TODO: abstract this to a point where I can just call DoSearchDown(machine);
                    DoSearchDown(mach, new List<int>());
                }
                else
                {
                    MessageBox.Show($"Could not find a machine with the name {rcbCNC.Text}");
                }
            }

        }

        private void RbShowAll_Click(object sender, EventArgs e)
        {
            if (rcbCNC.SelectedItem != null)
            {
                DoShowAll(settingsForm.Machines.SingleOrDefault(r => r.Name == rcbCNC.SelectedItem.Text), new List<int>());
            }
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            Config["width"] = this.Width.ToString();
            Config["height"] = this.Height.ToString();
        }

        private void RbOprUp_Click(object sender, EventArgs e)
        {
            if (rcbCNC.SelectedItem != null)
            {
                var item = settingsForm.Machines.Find(r => r.Name == rcbCNC.SelectedItem.Text);
                var originalLines = CurrentTextbox.FindLines(item.OperationRegex, RegexOptions.None);
                var lines = new List<int>();
                if (rcbIgnoreComments.Checked)
                {
                    for (var i = 0; i < originalLines.Count(); i++)
                    {
                        if (CurrentTextbox.Lines[originalLines[i]].DoesLineContainComment(new LineDef(originalLines[i], CurrentTextbox.Lines[originalLines[i]], item.OperationRegex)))
                        {
                        }
                        else
                        {
                            lines.Add(originalLines[i]);
                        }
                    }
                }
                else
                {
                    lines = originalLines;
                }

                currentLine = CurrentTextbox.Selection.Start.iLine;
                for (var i = lines.Count - 1; i >= 0; i--)
                {
                    Console.WriteLine(i);
                    Console.WriteLine(currentLine);
                    if (currentLine == 0)
                    {
                        currentLine = lines.Last();
                        CurrentTextbox.Selection = new Range(CurrentTextbox, currentLine);
                        CurrentTextbox.DoCaretVisible();
                        break;
                    }
                    else if (currentLine < lines.First())
                    {
                        currentLine = lines.Last();
                        CurrentTextbox.Selection = new Range(CurrentTextbox, currentLine);
                        CurrentTextbox.DoCaretVisible();
                        break;
                    }
                    else if (lines[i] > currentLine)
                    {
                        // if this is true, that means the current line is lower than the bigger line.
                        continue;
                    }
                    else if (i == 0 && lines[i] == currentLine)
                    {
                        currentLine = lines.Last();
                        CurrentTextbox.Selection = new Range(CurrentTextbox, currentLine);
                        CurrentTextbox.DoCaretVisible();
                        break;
                    }
                    else if (lines[i] == currentLine)
                    {
                        // this only executes if the lines@index matches the currentline
                        continue;
                    }
                    else if (lines[i] < currentLine)
                    {
                        currentLine = lines[i];
                        CurrentTextbox.Selection = new Range(CurrentTextbox, currentLine);
                        CurrentTextbox.DoCaretVisible();
                        break;
                    }

                }

            }
        }

        private void RbOprDown_Click(object sender, EventArgs e)
        {
            if (rcbCNC.SelectedItem != null)
            {

                var item = settingsForm.Machines.Find(r => r.Name == rcbCNC.SelectedItem.Text);
                var originalLines = CurrentTextbox.FindLines(item.OperationRegex, RegexOptions.None);
                var lines = new List<int>();
                if (rcbIgnoreComments.Checked)
                {
                    for (var i = 0; i < originalLines.Count(); i++)
                    {
                        if (CurrentTextbox.Lines[originalLines[i]].DoesLineContainComment(new LineDef(originalLines[i], CurrentTextbox.Lines[originalLines[i]], item.OperationRegex)))
                        {
                        }
                        else
                        {
                            lines.Add(originalLines[i]);
                        }
                    }
                }
                else
                {
                    lines = originalLines;
                }

                currentLine = CurrentTextbox.Selection.Start.iLine;

                for (var i = 0; i < lines.Count(); i++)
                {
                    if (currentLine == lines.Last())
                    {
                        currentLine = lines.First();
                        CurrentTextbox.Selection = new Range(CurrentTextbox, currentLine);
                        CurrentTextbox.DoCaretVisible();
                        break;
                    }
                    else if (currentLine > lines.Last())
                    {
                        console.log("???????");
                        currentLine = lines[0];
                        CurrentTextbox.Selection = new Range(CurrentTextbox, currentLine);
                        CurrentTextbox.DoCaretVisible();
                        break;
                    }
                    else if (lines[i] < currentLine) continue; // we dont wanna jump to the current line if its below our current point 
                    else if (lines[i] == currentLine) continue; // if its the same line, just skip it.
                    else if (lines[i] > currentLine)
                    {
                        // if this criteria is hit, that means we have hit either a point 
                        // on the current position or above us.
                        currentLine = lines[i];
                        CurrentTextbox.Selection = new Range(CurrentTextbox, currentLine);
                        CurrentTextbox.DoCaretVisible();
                        break;
                    }
                    else if (i == lines.Count - 1)
                    {
                        currentLine = lines.First();
                        CurrentTextbox.Selection = new Range(CurrentTextbox, currentLine);
                        CurrentTextbox.DoCaretVisible();
                        break;
                    }

                }

            }
        }

        private void RbOprAll_Click(object sender, EventArgs e)
        {
            if (rcbCNC.SelectedItem != null)
            {
                var item = settingsForm.Machines.Find(r => r.Name == rcbCNC.SelectedItem.Text);
                if (item != null)
                {
                    var lines = CurrentTextbox.FindLines(item.OperationRegex, RegexOptions.None);

                    List<LineDef> LineDefs = new List<LineDef>();

                    foreach (var line in lines)
                    {
                        LineDefs.Add(new LineDef(line, CurrentTextbox.Lines[line], item.OperationRegex));
                    }

                    showAllForm.ShowForm(LineDefs);
                }
            }
        }

    }
}
