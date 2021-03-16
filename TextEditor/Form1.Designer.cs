namespace TextEditor
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.closeFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.revealInExploreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ribbonSeparator1 = new System.Windows.Forms.RibbonSeparator();
            this.rtGeneral = new System.Windows.Forms.RibbonTab();
            this.rpFile = new System.Windows.Forms.RibbonPanel();
            this.rbNew = new System.Windows.Forms.RibbonButton();
            this.rbSave = new System.Windows.Forms.RibbonButton();
            this.rbSaveAs = new System.Windows.Forms.RibbonButton();
            this.rbOpenFile = new System.Windows.Forms.RibbonButton();
            this.rpText = new System.Windows.Forms.RibbonPanel();
            this.rbCopy = new System.Windows.Forms.RibbonButton();
            this.rbPaste = new System.Windows.Forms.RibbonButton();
            this.rbCut = new System.Windows.Forms.RibbonButton();
            this.rbSelect = new System.Windows.Forms.RibbonButton();
            this.rpMisc = new System.Windows.Forms.RibbonPanel();
            this.rbOnTop = new System.Windows.Forms.RibbonButton();
            this.rbOpenSettings = new System.Windows.Forms.RibbonButton();
            this.rtFile = new System.Windows.Forms.RibbonTab();
            this.rpCopyTo = new System.Windows.Forms.RibbonPanel();
            this.rbCopyFile = new System.Windows.Forms.RibbonButton();
            this.rcbDrives = new System.Windows.Forms.RibbonComboBox();
            this.rcbFolder = new System.Windows.Forms.RibbonComboBox();
            this.rbtnManualReload = new System.Windows.Forms.RibbonButton();
            this.rpDirectCopy = new System.Windows.Forms.RibbonPanel();
            this.rcbPresets = new System.Windows.Forms.RibbonComboBox();
            this.rbCopyDirect = new System.Windows.Forms.RibbonButton();
            this.saveFile = new System.Windows.Forms.SaveFileDialog();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.tFindDrives = new System.Windows.Forms.Timer(this.components);
            this.textContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.orbBtnNewFile = new System.Windows.Forms.RibbonOrbMenuItem();
            this.orbBtnOpenFile = new System.Windows.Forms.RibbonOrbMenuItem();
            this.OrbBtnSave = new System.Windows.Forms.RibbonOrbMenuItem();
            this.OrbBtnSaveAs = new System.Windows.Forms.RibbonOrbMenuItem();
            this.orbBtnExit = new System.Windows.Forms.RibbonOrbMenuItem();
            this.rtNC = new System.Windows.Forms.RibbonTab();
            this.rpCNCMachines = new System.Windows.Forms.RibbonPanel();
            this.rcbCNC = new System.Windows.Forms.RibbonComboBox();
            this.rcbIgnoreComments = new System.Windows.Forms.RibbonCheckBox();
            this.ribbonSeparator3 = new System.Windows.Forms.RibbonSeparator();
            this.rbUp = new System.Windows.Forms.RibbonButton();
            this.rbDown = new System.Windows.Forms.RibbonButton();
            this.rbShowAll = new System.Windows.Forms.RibbonButton();
            this.ribbonSeparator2 = new System.Windows.Forms.RibbonSeparator();
            this.rbOprUp = new System.Windows.Forms.RibbonButton();
            this.rbOprDown = new System.Windows.Forms.RibbonButton();
            this.rbOprAll = new System.Windows.Forms.RibbonButton();
            this.ribbonSeparator4 = new System.Windows.Forms.RibbonSeparator();
            this.rtExternalApps = new System.Windows.Forms.RibbonTab();
            this.lblLastAction = new System.Windows.Forms.Label();
            this.lblPath = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabContextMenu.SuspendLayout();
            this.textContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabs
            // 
            this.tabs.AllowDrop = true;
            this.tabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabs.Location = new System.Drawing.Point(15, 156);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(757, 378);
            this.tabs.TabIndex = 0;
            this.tabs.SelectedIndexChanged += new System.EventHandler(this.tabs_SelectedIndexChanged);
            this.tabs.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabs_Selected);
            this.tabs.DragDrop += new System.Windows.Forms.DragEventHandler(this.DragDropEvent);
            this.tabs.DragEnter += new System.Windows.Forms.DragEventHandler(this.DragEnterEvent);
            this.tabs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tabs_KeyDown);
            this.tabs.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabs_MouseDown);
            // 
            // tabContextMenu
            // 
            this.tabContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeFileToolStripMenuItem,
            this.closeAllToolStripMenuItem,
            this.revealInExploreToolStripMenuItem});
            this.tabContextMenu.Name = "tabContextMenu";
            this.tabContextMenu.Size = new System.Drawing.Size(159, 70);
            // 
            // closeFileToolStripMenuItem
            // 
            this.closeFileToolStripMenuItem.Name = "closeFileToolStripMenuItem";
            this.closeFileToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.closeFileToolStripMenuItem.Text = "Close tab";
            this.closeFileToolStripMenuItem.Click += new System.EventHandler(this.closeTabToolStripMenuItem_Click);
            // 
            // closeAllToolStripMenuItem
            // 
            this.closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
            this.closeAllToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.closeAllToolStripMenuItem.Text = "Close all tabs";
            this.closeAllToolStripMenuItem.Click += new System.EventHandler(this.closeAllToolStripMenuItem_Click);
            // 
            // revealInExploreToolStripMenuItem
            // 
            this.revealInExploreToolStripMenuItem.Name = "revealInExploreToolStripMenuItem";
            this.revealInExploreToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.revealInExploreToolStripMenuItem.Text = "Open in explore";
            this.revealInExploreToolStripMenuItem.Click += new System.EventHandler(this.revealInExploreToolStripMenuItem_Click);
            // 
            // rtGeneral
            // 
            this.rtGeneral.Panels.Add(this.rpFile);
            this.rtGeneral.Panels.Add(this.rpText);
            this.rtGeneral.Panels.Add(this.rpMisc);
            this.rtGeneral.Text = "General";
            // 
            // rpFile
            // 
            this.rpFile.Items.Add(this.rbNew);
            this.rpFile.Items.Add(this.rbSave);
            this.rpFile.Items.Add(this.rbSaveAs);
            this.rpFile.Items.Add(this.rbOpenFile);
            this.rpFile.Text = "File";
            // 
            // rbNew
            // 
            this.rbNew.Image = global::TextEditor.Properties.Resources._new;
            this.rbNew.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
            this.rbNew.SmallImage = global::TextEditor.Properties.Resources._new;
            this.rbNew.Text = "";
            this.rbNew.ToolTip = "Creates a new tab with a textbox";
            this.rbNew.ToolTipTitle = "New File";
            this.rbNew.Click += new System.EventHandler(this.rbNew_Click);
            // 
            // rbSave
            // 
            this.rbSave.Image = global::TextEditor.Properties.Resources.save;
            this.rbSave.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
            this.rbSave.SmallImage = global::TextEditor.Properties.Resources.save;
            this.rbSave.Text = "";
            this.rbSave.ToolTip = "Saves the file.";
            this.rbSave.ToolTipTitle = "Save";
            this.rbSave.Click += new System.EventHandler(this.rbSave_Click);
            // 
            // rbSaveAs
            // 
            this.rbSaveAs.Image = global::TextEditor.Properties.Resources.save_as;
            this.rbSaveAs.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
            this.rbSaveAs.SmallImage = global::TextEditor.Properties.Resources.save_as;
            this.rbSaveAs.Text = "";
            this.rbSaveAs.ToolTip = "Saves the file to a selected location";
            this.rbSaveAs.ToolTipTitle = "Save as...";
            this.rbSaveAs.Click += new System.EventHandler(this.rbSaveAs_Click);
            // 
            // rbOpenFile
            // 
            this.rbOpenFile.Image = global::TextEditor.Properties.Resources.open;
            this.rbOpenFile.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
            this.rbOpenFile.SmallImage = global::TextEditor.Properties.Resources.open;
            this.rbOpenFile.Text = "";
            this.rbOpenFile.ToolTip = "Opens a file in a new tab";
            this.rbOpenFile.ToolTipTitle = "Open File";
            this.rbOpenFile.Click += new System.EventHandler(this.rbOpenFile_Click);
            // 
            // rpText
            // 
            this.rpText.Items.Add(this.rbCopy);
            this.rpText.Items.Add(this.rbPaste);
            this.rpText.Items.Add(this.rbCut);
            this.rpText.Items.Add(this.rbSelect);
            this.rpText.Text = "Text";
            // 
            // rbCopy
            // 
            this.rbCopy.Image = global::TextEditor.Properties.Resources.copy;
            this.rbCopy.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
            this.rbCopy.SmallImage = global::TextEditor.Properties.Resources.copy;
            this.rbCopy.Text = "";
            this.rbCopy.ToolTip = "Copies the selected text";
            this.rbCopy.ToolTipTitle = "Copy";
            this.rbCopy.Click += new System.EventHandler(this.rbCopy_Click);
            // 
            // rbPaste
            // 
            this.rbPaste.Image = global::TextEditor.Properties.Resources.paste;
            this.rbPaste.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
            this.rbPaste.SmallImage = global::TextEditor.Properties.Resources.paste;
            this.rbPaste.Text = "";
            this.rbPaste.ToolTip = "Pastes text from clipboard into the current textbox";
            this.rbPaste.ToolTipTitle = "Paste";
            this.rbPaste.Click += new System.EventHandler(this.rbPaste_Click);
            // 
            // rbCut
            // 
            this.rbCut.Image = global::TextEditor.Properties.Resources.cut;
            this.rbCut.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
            this.rbCut.SmallImage = global::TextEditor.Properties.Resources.cut;
            this.rbCut.Text = "";
            this.rbCut.ToolTip = "Cuts the selected text and saves it to the clipboard";
            this.rbCut.ToolTipTitle = "Cut";
            this.rbCut.Click += new System.EventHandler(this.rbCut_Click);
            // 
            // rbSelect
            // 
            this.rbSelect.Image = global::TextEditor.Properties.Resources.select_all;
            this.rbSelect.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
            this.rbSelect.SmallImage = global::TextEditor.Properties.Resources.select_all;
            this.rbSelect.Text = "";
            this.rbSelect.ToolTip = "Selects all the text in the textbox";
            this.rbSelect.ToolTipTitle = "Select All";
            this.rbSelect.Click += new System.EventHandler(this.rbSelect_Click);
            // 
            // rpMisc
            // 
            this.rpMisc.Items.Add(this.rbOnTop);
            this.rpMisc.Items.Add(this.rbOpenSettings);
            this.rpMisc.Text = "Misc";
            // 
            // rbOnTop
            // 
            this.rbOnTop.CheckOnClick = true;
            this.rbOnTop.Image = global::TextEditor.Properties.Resources.Pin;
            this.rbOnTop.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
            this.rbOnTop.SmallImage = global::TextEditor.Properties.Resources.Pin;
            this.rbOnTop.Text = "";
            this.rbOnTop.ToolTip = "Toggles whether the window is always on top or not";
            this.rbOnTop.ToolTipTitle = "On top";
            this.rbOnTop.Click += new System.EventHandler(this.rbOnTop_Click);
            // 
            // rbOpenSettings
            // 
            this.rbOpenSettings.Image = global::TextEditor.Properties.Resources.options;
            this.rbOpenSettings.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
            this.rbOpenSettings.SmallImage = global::TextEditor.Properties.Resources.options;
            this.rbOpenSettings.Text = "";
            this.rbOpenSettings.ToolTip = "Opens the settings window";
            this.rbOpenSettings.ToolTipTitle = "Settings";
            this.rbOpenSettings.Click += new System.EventHandler(this.rbOpenSettings_Click);
            // 
            // rtFile
            // 
            this.rtFile.Panels.Add(this.rpCopyTo);
            this.rtFile.Panels.Add(this.rpDirectCopy);
            this.rtFile.Text = "File";
            // 
            // rpCopyTo
            // 
            this.rpCopyTo.Items.Add(this.rbCopyFile);
            this.rpCopyTo.Items.Add(this.rcbDrives);
            this.rpCopyTo.Items.Add(this.rcbFolder);
            this.rpCopyTo.Items.Add(this.rbtnManualReload);
            this.rpCopyTo.Text = "Copy to folder";
            // 
            // rbCopyFile
            // 
            this.rbCopyFile.Image = global::TextEditor.Properties.Resources.copy_to_folder;
            this.rbCopyFile.SmallImage = global::TextEditor.Properties.Resources.copy;
            this.rbCopyFile.Text = "Copy File";
            this.rbCopyFile.Click += new System.EventHandler(this.rbCopyFile_Click);
            // 
            // rcbDrives
            // 
            this.rcbDrives.AllowTextEdit = false;
            this.rcbDrives.Text = "Drives";
            this.rcbDrives.TextBoxText = "";
            this.rcbDrives.DropDownItemClicked += new System.Windows.Forms.RibbonComboBox.RibbonItemEventHandler(this.rcbDrives_DropDownItemClicked);
            this.rcbDrives.Click += new System.EventHandler(this.rcbDrives_Click);
            // 
            // rcbFolder
            // 
            this.rcbFolder.Text = "Folder";
            this.rcbFolder.TextBoxText = "";
            // 
            // rbtnManualReload
            // 
            this.rbtnManualReload.Image = global::TextEditor.Properties.Resources.refresh_new;
            this.rbtnManualReload.SmallImage = global::TextEditor.Properties.Resources.refresh_new;
            this.rbtnManualReload.Text = "Refresh Files";
            this.rbtnManualReload.Click += new System.EventHandler(this.rbtnManualReload_Click);
            // 
            // rpDirectCopy
            // 
            this.rpDirectCopy.Items.Add(this.rcbPresets);
            this.rpDirectCopy.Items.Add(this.rbCopyDirect);
            this.rpDirectCopy.Text = "Direct Copy";
            // 
            // rcbPresets
            // 
            this.rcbPresets.AllowTextEdit = false;
            this.rcbPresets.Text = "Presets";
            this.rcbPresets.TextBoxText = "";
            // 
            // rbCopyDirect
            // 
            this.rbCopyDirect.Image = global::TextEditor.Properties.Resources.copy_to_folder;
            this.rbCopyDirect.SmallImage = global::TextEditor.Properties.Resources.copy_to_folder;
            this.rbCopyDirect.Text = "Copy Direct";
            this.rbCopyDirect.Click += new System.EventHandler(this.rbCopyDirect_Click);
            // 
            // saveFile
            // 
            this.saveFile.CreatePrompt = true;
            this.saveFile.DefaultExt = "*.nc";
            this.saveFile.FileName = "Unnamed";
            this.saveFile.Filter = "NC File|*.nc|ISO File|*.iso|EIA File|*.eia|H File|*.h|CNC File|*.cnc|Text File|*." +
    "txt|All files|*.*";
            // 
            // tFindDrives
            // 
            this.tFindDrives.Interval = 500;
            this.tFindDrives.Tick += new System.EventHandler(this.tFindDrives_Tick);
            // 
            // textContextMenu
            // 
            this.textContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.copyToolStripMenuItem1,
            this.cutToolStripMenuItem,
            this.pasteToolStripMenuItem});
            this.textContextMenu.Name = "contextMenuStrip1";
            this.textContextMenu.Size = new System.Drawing.Size(123, 92);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.copyToolStripMenuItem.Text = "Select All";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.rbSelect_Click);
            // 
            // copyToolStripMenuItem1
            // 
            this.copyToolStripMenuItem1.Name = "copyToolStripMenuItem1";
            this.copyToolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
            this.copyToolStripMenuItem1.Text = "Copy";
            this.copyToolStripMenuItem1.Click += new System.EventHandler(this.rbCopy_Click);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.rbCut_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.rbPaste_Click);
            // 
            // ribbon1
            // 
            this.ribbon1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ribbon1.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.Minimized = false;
            this.ribbon1.Name = "ribbon1";
            // 
            // 
            // 
            this.ribbon1.OrbDropDown.BorderRoundness = 8;
            this.ribbon1.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.OrbDropDown.MenuItems.Add(this.orbBtnNewFile);
            this.ribbon1.OrbDropDown.MenuItems.Add(this.orbBtnOpenFile);
            this.ribbon1.OrbDropDown.MenuItems.Add(this.OrbBtnSave);
            this.ribbon1.OrbDropDown.MenuItems.Add(this.OrbBtnSaveAs);
            this.ribbon1.OrbDropDown.MenuItems.Add(this.ribbonSeparator1);
            this.ribbon1.OrbDropDown.MenuItems.Add(this.orbBtnExit);
            this.ribbon1.OrbDropDown.Name = "";
            this.ribbon1.OrbDropDown.Size = new System.Drawing.Size(527, 295);
            this.ribbon1.OrbDropDown.TabIndex = 0;
            this.ribbon1.OrbImage = global::TextEditor.Properties.Resources.cadsys_icon;
            // 
            // 
            // 
            this.ribbon1.QuickAcessToolbar.Checked = true;
            this.ribbon1.QuickAcessToolbar.DropDownButtonVisible = false;
            this.ribbon1.QuickAcessToolbar.Visible = false;
            this.ribbon1.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
            this.ribbon1.Size = new System.Drawing.Size(784, 150);
            this.ribbon1.TabIndex = 1;
            this.ribbon1.Tabs.Add(this.rtGeneral);
            this.ribbon1.Tabs.Add(this.rtFile);
            this.ribbon1.Tabs.Add(this.rtNC);
            this.ribbon1.Tabs.Add(this.rtExternalApps);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // orbBtnNewFile
            // 
            this.orbBtnNewFile.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.orbBtnNewFile.Image = global::TextEditor.Properties.Resources._new;
            this.orbBtnNewFile.SmallImage = global::TextEditor.Properties.Resources._new;
            this.orbBtnNewFile.Text = "New File";
            this.orbBtnNewFile.Click += new System.EventHandler(this.rbNew_Click);
            // 
            // orbBtnOpenFile
            // 
            this.orbBtnOpenFile.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.orbBtnOpenFile.Image = global::TextEditor.Properties.Resources.open;
            this.orbBtnOpenFile.SmallImage = global::TextEditor.Properties.Resources.open;
            this.orbBtnOpenFile.Text = "Open File";
            this.orbBtnOpenFile.Click += new System.EventHandler(this.rbOpenFile_Click);
            // 
            // OrbBtnSave
            // 
            this.OrbBtnSave.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.OrbBtnSave.Image = global::TextEditor.Properties.Resources.save;
            this.OrbBtnSave.SmallImage = global::TextEditor.Properties.Resources.save;
            this.OrbBtnSave.Text = "Save";
            this.OrbBtnSave.Click += new System.EventHandler(this.rbSaveAs_Click);
            // 
            // OrbBtnSaveAs
            // 
            this.OrbBtnSaveAs.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.OrbBtnSaveAs.Image = global::TextEditor.Properties.Resources.save_as;
            this.OrbBtnSaveAs.SmallImage = global::TextEditor.Properties.Resources.save_as;
            this.OrbBtnSaveAs.Text = "Save As";
            // 
            // orbBtnExit
            // 
            this.orbBtnExit.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.orbBtnExit.Image = ((System.Drawing.Image)(resources.GetObject("orbBtnExit.Image")));
            this.orbBtnExit.SmallImage = ((System.Drawing.Image)(resources.GetObject("orbBtnExit.SmallImage")));
            this.orbBtnExit.Text = "Exit";
            this.orbBtnExit.Click += new System.EventHandler(this.event_exit);
            // 
            // rtNC
            // 
            this.rtNC.Panels.Add(this.rpCNCMachines);
            this.rtNC.Text = "NC";
            // 
            // rpCNCMachines
            // 
            this.rpCNCMachines.Items.Add(this.rcbCNC);
            this.rpCNCMachines.Items.Add(this.rcbIgnoreComments);
            this.rpCNCMachines.Items.Add(this.ribbonSeparator3);
            this.rpCNCMachines.Items.Add(this.rbUp);
            this.rpCNCMachines.Items.Add(this.rbDown);
            this.rpCNCMachines.Items.Add(this.rbShowAll);
            this.rpCNCMachines.Items.Add(this.ribbonSeparator2);
            this.rpCNCMachines.Items.Add(this.rbOprUp);
            this.rpCNCMachines.Items.Add(this.rbOprDown);
            this.rpCNCMachines.Items.Add(this.rbOprAll);
            this.rpCNCMachines.Items.Add(this.ribbonSeparator4);
            this.rpCNCMachines.Text = "CNC Machines";
            // 
            // rcbCNC
            // 
            this.rcbCNC.Text = "CNC";
            this.rcbCNC.TextBoxText = "";
            // 
            // rcbIgnoreComments
            // 
            this.rcbIgnoreComments.Text = "Ignorer kommentare";
            // 
            // rbUp
            // 
            this.rbUp.Image = ((System.Drawing.Image)(resources.GetObject("rbUp.Image")));
            this.rbUp.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbUp.SmallImage")));
            this.rbUp.Text = "Search Up";
            this.rbUp.Click += new System.EventHandler(this.RbUp_Click);
            // 
            // rbDown
            // 
            this.rbDown.Image = ((System.Drawing.Image)(resources.GetObject("rbDown.Image")));
            this.rbDown.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbDown.SmallImage")));
            this.rbDown.Text = "Search down";
            this.rbDown.Click += new System.EventHandler(this.RbDown_Click);
            // 
            // rbShowAll
            // 
            this.rbShowAll.Image = ((System.Drawing.Image)(resources.GetObject("rbShowAll.Image")));
            this.rbShowAll.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbShowAll.SmallImage")));
            this.rbShowAll.Text = "Show all";
            this.rbShowAll.Click += new System.EventHandler(this.RbShowAll_Click);
            // 
            // rbOprUp
            // 
            this.rbOprUp.Image = ((System.Drawing.Image)(resources.GetObject("rbOprUp.Image")));
            this.rbOprUp.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbOprUp.SmallImage")));
            this.rbOprUp.Text = "Seach operation up";
            this.rbOprUp.Click += new System.EventHandler(this.RbOprUp_Click);
            // 
            // rbOprDown
            // 
            this.rbOprDown.Image = ((System.Drawing.Image)(resources.GetObject("rbOprDown.Image")));
            this.rbOprDown.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbOprDown.SmallImage")));
            this.rbOprDown.Text = "Search operation down";
            this.rbOprDown.Click += new System.EventHandler(this.RbOprDown_Click);
            // 
            // rbOprAll
            // 
            this.rbOprAll.Image = ((System.Drawing.Image)(resources.GetObject("rbOprAll.Image")));
            this.rbOprAll.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbOprAll.SmallImage")));
            this.rbOprAll.Text = "Show all operations";
            this.rbOprAll.Click += new System.EventHandler(this.RbOprAll_Click);
            // 
            // rtExternalApps
            // 
            this.rtExternalApps.Text = "External Apps";
            // 
            // lblLastAction
            // 
            this.lblLastAction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLastAction.AutoSize = true;
            this.lblLastAction.Location = new System.Drawing.Point(12, 539);
            this.lblLastAction.Name = "lblLastAction";
            this.lblLastAction.Size = new System.Drawing.Size(0, 13);
            this.lblLastAction.TabIndex = 2;
            // 
            // lblPath
            // 
            this.lblPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(12, 539);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(32, 13);
            this.lblPath.TabIndex = 3;
            this.lblPath.Text = "Path:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(392, 274);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.lblLastAction);
            this.Controls.Add(this.ribbon1);
            this.Controls.Add(this.tabs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadsys Tools";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.DragDropEvent);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.DragEnterEvent);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Event_KeyDown);
            this.tabContextMenu.ResumeLayout(false);
            this.textContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TabControl tabs;
        public System.Windows.Forms.Ribbon ribbon;
        private System.Windows.Forms.RibbonTab rtGeneral;
        private System.Windows.Forms.RibbonPanel rpFile;
        private System.Windows.Forms.RibbonPanel rpText;
        private System.Windows.Forms.RibbonButton rbNew;
        private System.Windows.Forms.RibbonButton rbSave;
        private System.Windows.Forms.RibbonButton rbSaveAs;
        private System.Windows.Forms.RibbonButton rbOpenFile;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.RibbonButton rbCopy;
        private System.Windows.Forms.RibbonButton rbPaste;
        private System.Windows.Forms.RibbonButton rbCut;
        private System.Windows.Forms.RibbonButton rbSelect;
        private System.Windows.Forms.RibbonPanel rpMisc;
        private System.Windows.Forms.RibbonTab rtFile;
        private System.Windows.Forms.RibbonPanel rpCopyTo;
        private System.Windows.Forms.RibbonButton rbCopyFile;
        private System.Windows.Forms.RibbonComboBox rcbDrives;
        private System.Windows.Forms.Timer tFindDrives;
        private System.Windows.Forms.RibbonComboBox rcbFolder;
        private System.Windows.Forms.RibbonButton rbtnManualReload;
        private System.Windows.Forms.RibbonOrbMenuItem orbBtnNewFile;
        private System.Windows.Forms.RibbonOrbMenuItem orbBtnOpenFile;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator1;
        private System.Windows.Forms.RibbonOrbMenuItem orbBtnExit;
        private System.Windows.Forms.ContextMenuStrip textContextMenu;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.RibbonOrbMenuItem OrbBtnSave;
        private System.Windows.Forms.RibbonOrbMenuItem OrbBtnSaveAs;
        private System.Windows.Forms.RibbonButton rbOpenSettings;
        public System.Windows.Forms.RibbonButton rbOnTop;
        private System.Windows.Forms.RibbonPanel rpDirectCopy;
        private System.Windows.Forms.RibbonButton rbCopyDirect;
        public System.Windows.Forms.SaveFileDialog saveFile;
        private System.Windows.Forms.RibbonTab rtExternalApps;
        private System.Windows.Forms.Label lblLastAction;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem closeFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem revealInExploreToolStripMenuItem;
        public System.Windows.Forms.ContextMenuStrip tabContextMenu;
        private System.Windows.Forms.RibbonComboBox rcbPresets;
        private System.Windows.Forms.RibbonTab rtNC;
        private System.Windows.Forms.RibbonPanel rpCNCMachines;
        private System.Windows.Forms.RibbonButton rbUp;
        private System.Windows.Forms.RibbonButton rbDown;
        private System.Windows.Forms.RibbonButton rbShowAll;
        private System.Windows.Forms.RibbonCheckBox rcbIgnoreComments;
        public System.Windows.Forms.RibbonComboBox rcbCNC;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator3;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator2;
        private System.Windows.Forms.RibbonButton rbOprUp;
        private System.Windows.Forms.RibbonButton rbOprDown;
        private System.Windows.Forms.RibbonButton rbOprAll;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator4;
    }
}

