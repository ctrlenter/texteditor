using FastColoredTextBoxNS;
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

namespace TextEditor
{
    public partial class CopyToSpecificFolder : Form
    {
        FastColoredTextBox fctb;
        public Form1 mainForm;

        List<Machine> machines;

        public CopyToSpecificFolder(Form1 mainform, List<Machine> machines)
        {
            mainForm = mainform;
            InitializeComponent();

            Load += CopyToSpecificFolder_Load;
        }

        public DialogResult ShowDialog(FastColoredTextBox fctb)
        {
            LoadMachinesIntoDropdownList();
            this.fctb = fctb;
            return ShowDialog();
        }

        public void LoadMachinesIntoDropdownList()
        {
            machines = Utils.LoadMachines();
            if (machines != null)
            {
                foreach (var machine in machines)
                {
                    cbMachine.Items.Add(machine.MachineName);
                }
            }
        }


        private void CopyToSpecificFolder_Load(object sender, EventArgs e)
        {
            this.TopMost = mainForm.TopMost;
        }

        private void cbMachine_TextChanged(object sender, EventArgs e)
        {
            var machineId = machines[cbMachine.SelectedIndex].ID;

            var machine = machines.SingleOrDefault(x => x.ID ==  machineId);
            if (machine != null)
                lblPath.Text = "Path: " + machine.FolderPath;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbMachine.SelectedItem != null)
                {

                    var machineId = machines[cbMachine.SelectedIndex].ID;

                    var path = machines.SingleOrDefault(m => m.ID == machineId).FolderPath;

                    if (!string.IsNullOrEmpty(path)) 
                    {
                        if (!fctb.IsChanged)
                        {
                            Utils.TrySave(fctb, mainForm.saveFile);
                        }
                        if (mainForm.tabs.SelectedTab.Text != "[Unnamed]")
                        {
                            if (mainForm.tabs.SelectedTab.Tag != null)
                            {
                                if (Utils.CopyFile(mainForm.tabs.SelectedTab.Tag as string, Path.GetFullPath(path) + "\\" + mainForm.tabs.SelectedTab.Text))
                                {
                                    MessageBox.Show("Copy was successful!");
                                    this.Hide();
                                    reset();
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No item selected.\nPlease select an item!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
                Logger.Log(ex.StackTrace);
            }

        }

        private void reset()
        {
            if (machines != null)
                machines.Clear();

            cbMachine.Items.Clear();
            lblPath.Text = "";
        }

        private void CopyToSpecificFolder_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                reset();
                e.Cancel = true;
                this.Hide();
            }
        }
    }
}
