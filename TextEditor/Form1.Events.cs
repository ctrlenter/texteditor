using FastColoredTextBoxNS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextEditor.Core;
using static TextEditor.Core.ShowAllForm;

namespace TextEditor
{
    partial class Form1
    {

        private void Fctb_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void DragDropEvent(object sender, DragEventArgs e)
        {
            var files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files != null)
            {


                //TODO: Fix en fejl med text drag n drop?+

                var tabList = new List<TabPage>();

                foreach (TabPage tab in tabs.TabPages)
                {
                    tabList.Add(tab);
                }

                List<string> tabsWithOpenFile = new List<string>();

                for (int i = 0; i < files.Length; i++)
                {

                    if (tabList.Find(t => t.Tag as string == files[i]) == null)
                    {
                        AddTab(files[i]);
                    }
                    else
                    {
                        tabsWithOpenFile.Add(files[i]);
                    }
                }

                string str = "";

                foreach (var i in tabsWithOpenFile)
                {
                    str += i + "\n";
                }

                if (tabsWithOpenFile.Count > 0)
                {
                    MessageBox.Show("You tried opening files that is already open.\nOpened files:\n" + str);
                }

                tabs.SelectTab(tabs.TabPages.Count - 1);

            }
        }

        private void DragEnterEvent(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }


        private void tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabs.TabCount <= 0) return;
            var tab = tabs.TabPages[tabs.SelectedIndex];
            if (tab != null)
            {
                tab.Controls[0].Focus();
                if (tab.Tag != null)
                    lblPath.Text = $"Path: {tab.Tag.ToString()}";
                else
                    lblPath.Text = "Path: ";
            }
        }

        private void tabs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N)
            {
                if (!FirstTimeNewTab)
                    tabs.TabPages.Add(Utils.CreateTabPage(textContextMenu, fctb_MouseDown, Event_KeyDown, DragEnterEvent, DragDropEvent, prevTab++));

                tabs.SelectTab(tabs.TabPages.Count - 1);
            }

            else if ((e.Control && (e.KeyCode == Keys.W)) || (e.Control && (e.KeyCode == Keys.F4)))
            {
                if (tabs.SelectedTab != null)
                {
                    if (tabs.SelectedTab.Controls[0] != null)
                    {
                        var fctb = (FastColoredTextBox)tabs.SelectedTab.Controls[0];
                        if (fctb.IsChanged)
                        {
                            Utils.TrySave(fctb, saveFile);
                        }
                        tabs.TabPages.Remove(tabs.SelectedTab);
                        if (tabs.TabPages.Count <= 0) tabs.TabPages.Add(Utils.CreateTabPage(textContextMenu, tabs_MouseDown, this.Event_KeyDown, DragEnterEvent, DragDropEvent, prevTab++));
                        else tabs.SelectTab(tabs.TabPages.Count - 1);
                    }
                }
            }
        }

        public void DoSearchDown(MachineDef machine, List<int> lines)
        {
            if (CurrentTextbox.Lines.Count > 2)
            {
                var item = settingsForm.Machines.Find(r => r.Name == rcbCNC.SelectedItem.Text);
                var originalLines = CurrentTextbox.FindLines(item.ToolCallRegex, RegexOptions.None);
                var line = CurrentTextbox.Lines[1];
                if (line.Substring(0, 17).Contains("(1)@start_of_file"))
                {
                    originalLines = CurrentTextbox.FindLines(MachineDef.traceRegex, RegexOptions.None);
                    for (var i = 0; i < originalLines.Count(); i++)
                    {
                        lines.Add(originalLines[i]);
                    }
                }

                else if (rcbIgnoreComments.Checked)
                {
                    for (var i = 0; i < originalLines.Count(); i++)
                    {
                        if (CurrentTextbox.Lines[originalLines[i]].DoesLineContainComment(new LineDef(originalLines[i], CurrentTextbox.Lines[originalLines[i]], item.ToolCallRegex)))
                        {
                        }
                        else
                        {
                            lines.Add(originalLines[i]);
                        }
                    }
                }
                else
                    lines = originalLines;


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

        public void DoSearchUp(MachineDef machine, List<int> lines)
        {
            //get second line
            if (CurrentTextbox.Lines.Count >= 2)
            {
                //this means theres more than 2 lines. lets get the 2nd line

                var line = CurrentTextbox.Lines[1];
                var item = settingsForm.Machines.Find(r => r.Name == rcbCNC.SelectedItem.Text);
                var originalLines = CurrentTextbox.FindLines(item.ToolCallRegex, RegexOptions.None);
                if (line.Substring(0, 17).Contains("(1)@start_of_file"))
                {
                    originalLines = CurrentTextbox.FindLines(MachineDef.traceRegex, RegexOptions.None);
                    for (var i = 0; i < originalLines.Count(); i++)
                    {
                        lines.Add(originalLines[i]);
                    }
                }
                else if (rcbIgnoreComments.Checked)
                {
                    for (var i = 0; i < originalLines.Count(); i++)
                    {
                        if (CurrentTextbox.Lines[originalLines[i]].DoesLineContainComment(new LineDef(originalLines[i], CurrentTextbox.Lines[originalLines[i]], item.ToolCallRegex)))
                        {
                        }
                        else
                        {
                            lines.Add(originalLines[i]);
                        }
                    }
                }
                else
                    lines = originalLines;


                currentLine = CurrentTextbox.Selection.Start.iLine;

                for (var i = lines.Count - 1; i >= 0; i--)
                {
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

        public void DoShowAll(MachineDef def, List<int> lines)
        {
            if (CurrentTextbox.Lines.Count > 2)
            {
                var line = CurrentTextbox.Lines[1];
                if (def != null)
                {
                    if (line.Substring(0, 17).Contains("(1)@start_of_file"))
                    {
                        lines = CurrentTextbox.FindLines(MachineDef.traceRegex, RegexOptions.None);
                    }
                    else
                    {
                        lines = CurrentTextbox.FindLines(def.ToolCallRegex, RegexOptions.None);
                    }
                    var LineDefs = new List<LineDef>();
                    foreach (var li in lines)
                    {
                        LineDefs.Add(new LineDef(li, CurrentTextbox.Lines[li], def.ToolCallRegex));
                    }
                    //CurrentTextbox.FindLines(item.ToolCallRegex, RegexOptions.None);
                    showAllForm.ShowForm(LineDefs);
                }
            }
        }


        private void Event_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Control && e.Shift && e.KeyCode == Keys.D1)
            {
                CenterToScreen();
            }
            else if (e.Control && e.Shift && e.KeyCode == Keys.D2)
            {
                SetClientSizeCore(800, 600);
            }

            else if (e.KeyCode == Keys.F5)
            {
                if (rcbCNC.SelectedItem != null)
                {
                    DoSearchDown(settingsForm.Machines.SingleOrDefault(r => r.Name == rcbCNC.SelectedItem.Text), new List<int>());
                }
            }
            else if (e.KeyCode == Keys.F6)
            {
                if (rcbCNC.SelectedItem != null)
                {
                    DoSearchUp(settingsForm.Machines.SingleOrDefault(r => r.Name == rcbCNC.SelectedItem.Text), new List<int>());
                }
            }

            else if (e.KeyCode == Keys.F7)
            {
                if (rcbCNC.SelectedItem != null)
                {
                    DoShowAll(settingsForm.Machines.SingleOrDefault(r => r.Name == rcbCNC.SelectedItem.Text), new List<int>());
                }
            }

            else if (e.Control && (e.KeyCode == Keys.S))
            {
                if (tabs.SelectedTab != null)
                {
                    if (tabs.SelectedTab.Controls[0] != null)
                    {
                        if (tabs.SelectedTab.Tag != null)
                        {
                            console.log("Tag was not null");
                            Utils.WriteText(tabs.SelectedTab.Tag as string, CurrentTextbox.Text);
                            CurrentTextbox.IsChanged = false;
                            lblLastAction.Text = "Saved...";
                        }
                        else
                        {
                            console.log("tag was null");
                            Utils.TrySave(CurrentTextbox, saveFile);
                            lblLastAction.Text = "Saved...";
                        }
                    }
                }
            }
            else if (e.Control && e.Shift && (e.KeyCode == Keys.S))
            {
                if (tabs.SelectedTab != null)
                {
                    if (tabs.SelectedTab.Controls[0] != null)
                    {

                        Utils.TrySave(CurrentTextbox, saveFile);
                        lblLastAction.Text = "Saved...";
                    }
                }
            }
            else if (e.Alt && (e.KeyCode == Keys.C))
            {
                var curText = CurrentTextbox.SelectedText;
                try
                {
                    var res = new DataTable().Compute(curText, null).ToString();
                    CurrentTextbox.SelectedText = res;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                            $"An error occured when trying to compute \"{curText}\"!" +
                            $"\nMessage: {ex.Message}",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                }

            }
        }

        private void rbNew_Click(object sender, EventArgs e)
        {
            tabs.TabPages.Add(Utils.CreateTabPage(textContextMenu, fctb_MouseDown, Fctb_KeyDown, DragEnterEvent, DragDropEvent, prevTab++));
            tabs.SelectTab(tabs.TabPages.Count - 1);

        }

        private void rbSave_Click(object sender, EventArgs e)
        {
            Utils.TrySave(CurrentTextbox, saveFile);
            lblLastAction.Text = "Saved...";

        }

        private void rbSaveAs_Click(object sender, EventArgs e)
        {

            tabs.SelectedTab.Tag = null;
            Utils.TrySave(CurrentTextbox, saveFile);
            lblLastAction.Text = "Saved...";
        }

        private void rbOpenFile_Click(object sender, EventArgs e)
        {

            string path = Utils.TryOpenFile(openFile);

            if (path != "")
            {
                tabs.TabPages.Add(Utils.CreateTabPageAndLoadFile(textContextMenu, tabs_MouseDown, Event_KeyDown, DragDropEvent, DragEnterEvent, path));
                tabs.SelectTab(tabs.TabPages.Count - 1);
                tabs.SelectedTab.Focus();
                tabs.SelectedTab.Controls[0].Focus();
                lblPath.Text = path;
            }
        }

        private void rbCopy_Click(object sender, EventArgs e)
        {
            CurrentTextbox.Copy();
        }

        private void rbPaste_Click(object sender, EventArgs e)
        {
            CurrentTextbox.Paste();
        }

        private void rbCut_Click(object sender, EventArgs e)
        {
            CurrentTextbox.Cut();
        }

        private void rbSelect_Click(object sender, EventArgs e)
        {
            CurrentTextbox.SelectAll();
        }

        private void rbOnTop_Click(object sender, EventArgs e)
        {
            this.TopMost = !this.TopMost;
        }

        private void btn_rb_click(object sender, EventArgs e)
        {
            var btn = (RibbonButton)sender;
            var path = btn.Tag as string;
            if (File.Exists(path))
            {
                if (tabs.SelectedTab != null)
                {
                    if (File.Exists(tabs.SelectedTab.Tag as string))
                    {
                        console.log(tabs.SelectedTab.Tag as string);
                        Process.Start(path, tabs.SelectedTab.Tag as string);
                    }
                    else
                    {
                        Process.Start(path);
                    }
                }
            }
        }

        private void rbCopyFile_Click(object sender, EventArgs e)
        {
            if (rcbDrives.SelectedItem != null)
            {
                if (!CurrentTextbox.IsChanged)
                {
                    Utils.TrySave(CurrentTextbox, saveFile);
                    lblLastAction.Text = "Saved...";
                }
                if (tabs.SelectedTab.Text != "[Unnamed]")
                {

                    if (rcbFolder.SelectedItem != null && rcbFolder.SelectedItem.Text != "No Folder")
                    {
                        if (tabs.SelectedTab.Tag != null)
                        {
                            if (Utils.CopyFile(tabs.SelectedTab.Tag as string, rcbFolder.SelectedItem.Text + @"\" + tabs.SelectedTab.Text))
                                MessageBox.Show("Copy was successful!");
                        }
                    }
                    else
                    {
                        if (tabs.SelectedTab.Tag != null)
                        {
                            if (Utils.CopyFile(tabs.SelectedTab.Tag as string, rcbDrives.SelectedItem.Text + tabs.SelectedTab.Text))
                                MessageBox.Show("Copy was successful!x");
                        }
                    }

                }
            }
            else
            {
                MessageBox.Show("No drive selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tFindDrives_Tick(object sender, EventArgs e)
        {
            var drivesToFind = LoadDrives();

            if (lDrivers.Count != drivesToFind.Count)
            {
                Logger.Log($"New drive was added.");
                lDrivers.Clear();
                rcbDrives.DropDownItems.Clear();
                lDrivers.AddRange(drivesToFind);
                foreach (var str in lDrivers)
                {
                    rcbDrives.DropDownItems.Add(new RibbonButton(str));
                }
            }



            if (rcbDrives.SelectedItem != null)
            {
                var foldersToFind = LoadFolders(rcbDrives.SelectedItem.Text);

                if (lFolders.Count != foldersToFind.Count)
                {
                    lFolders.Clear();
                    rcbFolder.DropDownItems.Clear();
                    lFolders.AddRange(foldersToFind);
                    rcbFolder.DropDownItems.Add(new RibbonButton("No Folder"));

                    foreach (var item in lFolders)
                    {
                        rcbFolder.DropDownItems.Add(new RibbonButton(item));
                    }
                }
            }
        }

        private void rbtnManualReload_Click(object sender, EventArgs e)
        {
            lFolders.Clear();
            if (rcbDrives.SelectedItem != null)
            {
                var foldersToFind = LoadFolders(rcbDrives.SelectedItem.Text);
                if (foldersToFind.Count != lFolders.Count)
                {
                    lFolders.Clear();
                    rcbFolder.DropDownItems.Clear();
                    lFolders.AddRange(foldersToFind);
                    rcbFolder.DropDownItems.Add(new RibbonButton("No Folder"));

                    foreach (var item in lFolders)
                    {
                        rcbFolder.DropDownItems.Add(new RibbonButton(item));
                    }
                }

            }
        }

        private void event_exit(object server, EventArgs e)
        {
            Application.Exit();
        }

        private void rbOpenSettings_Click(object sender, EventArgs e)
        {
            settingsForm.ShowDialog();
        }

    }
}
