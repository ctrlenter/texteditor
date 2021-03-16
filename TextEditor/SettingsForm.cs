using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextEditor.Core;
using TextEditor.Core.XML;
using TextEditor.Properties;

namespace TextEditor
{
    public partial class SettingsForm : Form
    {



        public ViewSettings viewMain;
        public CopyToSettingView viewCopySettings;
        public ExternalApplicationSettingView viewExtApp;
        public CNCView CNCView;

        public bool HasSaved = false;

        public Form1 mainForm;

        public List<MachineDef> Machines = new List<MachineDef>();


        public SettingsForm(Form1 form)
        {
            mainForm = form;
            viewMain = new ViewSettings(this);
            viewCopySettings = new CopyToSettingView(this);
            viewExtApp = new ExternalApplicationSettingView(this);
            CNCView = new CNCView(this);
            InitializeComponent();
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            treeView1.NodeMouseClick += TreeView1_NodeMouseClick;

            panelMain.Controls.Add(viewMain);
            panelMain.Controls[0].Dock = DockStyle.Fill;

            Machines.Add(new MachineDef("Auto", "(opr)|(OPR)", Form1.RegexPattern));
            Machines.Add(new MachineDef("ISO", "(opr)|(OPR)", "([T][0-9]+)"));
            Machines.Add(new MachineDef("Heidenhain", "(opr)|(OPR)", "(TOOL CALL \".*?\")|(TOOL CALL \'.*?\')|(TOOL CALL [0-9]+)"));
            Machines.Add(new MachineDef("Siemens", "(opr)|(OPR)", ""));

            var customMachines = XMLSerializer.LoadMachineDefinitions(Path.Combine(Config.DirectoryPath, "machines.xml"));

            Machines.AddRange(customMachines);

            CNCView.Load();

        }

        private void TreeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Text == "General")
            {
                if (panelMain.Controls[0].GetType() == typeof(ViewSettings))
                {
                    console.log("current view is: main view");
                    return;
                }
                panelMain.Controls.Clear();
                panelMain.Controls.Add(viewMain);
                panelMain.Controls[0].Dock = DockStyle.Fill;
            }
            else if (e.Node.Text == "Copy settings")
            {
                if (panelMain.Controls[0].GetType() == typeof(CopyToSettingView))
                {
                    console.log("current view is: copy to settings view");
                    return;
                }
                panelMain.Controls.Clear();
                panelMain.Controls.Add(viewCopySettings);
                panelMain.Controls[0].Dock = DockStyle.Fill;

            }
            else if (e.Node.Text == "External Application")
            {
                if (panelMain.Controls[0].GetType() == typeof(ExternalApplicationSettingView))
                {
                    console.log("current view is: external application");
                    return;
                }
                panelMain.Controls.Clear();
                panelMain.Controls.Add(viewExtApp);
                panelMain.Controls[0].Dock = DockStyle.Fill;
            }
            else if (e.Node.Text == "CNC")
            {
                if (panelMain.Controls[0].GetType() == typeof(CNCView))
                {
                    return;
                }
                panelMain.Controls.Clear();
                panelMain.Controls.Add(CNCView);
                panelMain.Controls[0].Dock = DockStyle.Fill;
            }
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            {
                bool onTop = false, newInstance = false;

                bool useStartupSize;

                if (!bool.TryParse(Form1.Config["use_startup_size"], out useStartupSize))
                {
                    if (useStartupSize)
                    {
                        viewMain.tbStartupHeight.Enabled = true;
                        viewMain.tbStartupWidth.Enabled = true;
                        viewMain.tbStartupWidth.Text = Form1.Config["width"];
                        viewMain.tbStartupHeight.Text = Form1.Config["height"];
                    }
                    else
                    {
                        viewMain.tbStartupWidth.Enabled = false;
                        viewMain.tbStartupHeight.Enabled = false;
                    }
                }
                else
                {
                    viewMain.tbStartupWidth.Enabled = false;
                    viewMain.tbStartupHeight.Enabled = false;
                }



                viewMain.txWidth.Text = mainForm.Width.ToString();
                viewMain.txHeight.Text = mainForm.Height.ToString();
                console.log(Form1.Config["width"]);

                if (!bool.TryParse(Form1.Config["ontop"], out onTop))
                {
                    onTop = false;
                }

                if (!bool.TryParse(Form1.Config["tabsinnewinstance"], out newInstance))
                {
                    newInstance = false;
                }

                if (bool.TryParse(Form1.Config["use_startup_size"], out useStartupSize))
                {
                    viewMain.tbStartupHeight.Text = Form1.Config["startup_height"];
                    viewMain.tbStartupWidth.Text = Form1.Config["startup_width"];
                    if (useStartupSize)
                    {

                        viewMain.cbUseStartupSize.Checked = true;
                        viewMain.tbStartupHeight.Enabled = true;
                        viewMain.tbStartupWidth.Enabled = true;
                    }
                    else
                    {

                        viewMain.cbUseStartupSize.Checked = false;
                        viewMain.tbStartupHeight.Enabled = false;
                        viewMain.tbStartupWidth.Enabled = false;
                    }
                }

                viewMain.cbOnTop.Checked = onTop;
                viewMain.cbNewInstance.Checked = newInstance;

                this.TopMost = onTop;
            }
        }

        private void btnSaveAndExit_Click(object sender, EventArgs e)
        {
            if (!HasSaved)
            {
                //var res = MessageBox.Show("Do you want to save your settings?", "Warning", MessageBoxButtons.YesNoCancel);
                //if (res == DialogResult.Yes)
                //{
                bool doesWidthContainLetter =
                    viewMain.tbStartupWidth.Text.Any(x => char.IsLetter(x));

                bool doesHeightContainLetter =
                    viewMain.tbStartupHeight.Text.Any(x => char.IsLetter(x));

                bool onTop = viewMain.cbOnTop.Checked;

                bool doesCurrentWidthContainLetter = viewMain.txWidth.Text.Any(x => char.IsLetter(x));
                bool doesCurrentHeightContainLetter = viewMain.txHeight.Text.Any(x => char.IsLetter(x));

                if (!doesCurrentWidthContainLetter && !string.IsNullOrWhiteSpace(viewMain.txWidth.Text))
                {
                    Form1.Config["width"] = viewMain.txWidth.Text;
                }

                if (!doesCurrentHeightContainLetter && !string.IsNullOrWhiteSpace(viewMain.txHeight.Text))
                {
                    Form1.Config["height"] = viewMain.txHeight.Text;
                }

                if (!doesCurrentWidthContainLetter && !string.IsNullOrWhiteSpace(viewMain.tbStartupWidth.Text))
                {
                    Form1.Config["startup_width"] = viewMain.tbStartupWidth.Text;
                }

                if (!doesCurrentHeightContainLetter && !string.IsNullOrWhiteSpace(viewMain.tbStartupHeight.Text))
                {
                    Form1.Config["startup_height"] = viewMain.tbStartupHeight.Text;
                }

                Form1.Config["ontop"] = onTop.ToString();
                Form1.Config["tabsinnewinstance"] = viewMain.cbNewInstance.Checked.ToString();
                Form1.Config["use_startup_size"] = viewMain.cbUseStartupSize.Checked.ToString();
                mainForm.TopMost = onTop;

                int nWidth;
                int nHeight;
                if (mainForm.WindowState == FormWindowState.Normal)
                {
                    if (int.TryParse(viewMain.txWidth.Text, out nWidth))
                    {
                        mainForm.Width = nWidth;
                    }
                    if (int.TryParse(viewMain.txHeight.Text, out nHeight))
                    {
                        mainForm.Height = nHeight;
                    }
                }

                if (CNCView.currentMachine != null)
                {

                    var oldItem = Machines.SingleOrDefault(r => r.Name == CNCView.oldName);
                    console.log(CNCView.oldName);
                    if (oldItem != null)
                    {
                        if (CNCView.cbMachines.Text == "Auto"
                                || CNCView.cbMachines.Text == "ISO"
                                || CNCView.cbMachines.Text == "Heidenhain"
                                || CNCView.cbMachines.Text == "Siemens")
                        {
                            MessageBox.Show("You cannot edit this machine.\nReason: It's a default machine.");
                            return;
                        }
                        else
                        {
                            console.log("Should update the data");
                            if (Utils.IsValidRegex(CNCView.tbOprRegex.Text))
                                Machines.SingleOrDefault(r => r.Name == CNCView.oldName).OperationRegex = CNCView.tbOprRegex.Text;

                            if (Utils.IsValidRegex(CNCView.tbTcRegex.Text))
                                Machines.SingleOrDefault(r => r.Name == CNCView.oldName).ToolCallRegex = CNCView.tbTcRegex.Text;

                            Machines.SingleOrDefault(r => r.Name == CNCView.oldName).Name = CNCView.tbMachineName.Text;


                            Utils.WriteText(Path.Combine(Config.DirectoryPath, "machines.xml"), XMLSerializer.ConvertMachineDefinitionsToString(Machines));

                            CNCView.ReloadMachines();

                            CNCView.tbMachineName.Enabled = false;
                            CNCView.tbOprRegex.Enabled = false;
                            CNCView.tbTcRegex.Enabled = false;
                            CNCView.tbMachineName.Text = "";
                            CNCView.tbOprRegex.Text = "";
                            CNCView.tbTcRegex.Text = "";

                        }
                    }
                    else
                    {

                    }
                }
                else
                {
                    console.log("Current machine was null");
                }

                mainForm.rbOnTop.Checked = onTop;
                Hide();
                mainForm.ReloadPanels();
                mainForm.BringToFront();
            }
        }

        private void btnCancelAndExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //Copy settings


        }
    }
}
