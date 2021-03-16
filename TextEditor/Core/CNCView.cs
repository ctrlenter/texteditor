using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using TextEditor.Core.XML;

namespace TextEditor.Core
{
    public partial class CNCView : UserControl
    {

        public SettingsForm Parent;
        public MachineDef currentMachine;
        public string oldName;
        public string newOprRegex, newTcRegex;
        
        AddMachine addMachine;

        public CNCView(SettingsForm parent)
        {
            InitializeComponent();
            Parent = parent;
            addMachine = new AddMachine(this);
        }


        public void Load()
        {

            foreach (var str in Parent.Machines)
            {
                cbMachines.Items.Add(str);
            }

            tbMachineName.Enabled = false;
            tbTcRegex.Enabled = false;
            tbOprRegex.Enabled = false;
            btnUpdateMachine.Enabled = false;

        }

        private void CbMachines_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = Parent.Machines.First(r => r.Name == cbMachines.Text);
            if (item != null)
            {
                currentMachine = item;

                tbMachineName.Text = item.Name;
                tbOprRegex.Text = item.OperationRegex;
                tbTcRegex.Text = item.ToolCallRegex;

                tbMachineName.Enabled = true;
                tbOprRegex.Enabled = true;
                tbTcRegex.Enabled = true;
                btnUpdateMachine.Enabled = true;
                
                oldName = currentMachine.Name;
            }
        }

        private void BtnUpdateMachine_Click(object sender, EventArgs e)
        {

            if (cbMachines.Text == "Auto"
                    || cbMachines.Text == "ISO"
                    || cbMachines.Text == "Heidenhain"
                    || cbMachines.Text == "Siemens")
            {
                MessageBox.Show("You cannot edit this machine.\nReason: It is a default machine.");
                return;
            }
            else
            {

                currentMachine = Parent.Machines.SingleOrDefault(r => r.Name == cbMachines.Text);

                oldName = currentMachine.Name;

                if (tbOprRegex.Text != "")
                    if (Utils.IsValidRegex(tbOprRegex.Text))
                        currentMachine.OperationRegex = tbOprRegex.Text;

                if (tbTcRegex.Text != "")
                    if (Utils.IsValidRegex(tbTcRegex.Text))
                        currentMachine.ToolCallRegex = tbTcRegex.Text;

                if (tbMachineName.Text != "")
                    currentMachine.Name = tbMachineName.Text;


                //Utils.WriteText(Path.Combine(Config.DirectoryPath, "machines.xml"), XMLSerializer.ConvertMachineDefinitionsToString(Parent.Machines));
                //ReloadMachines();
            }
        }

        public void ReloadMachines()
        {
            cbMachines.Items.Clear();
            Parent.mainForm.rcbCNC.DropDownItems.Clear();
            for (var i = 0; i < Parent.Machines.Count(); i++)
            {
                cbMachines.Items.Add(Parent.Machines[i]);
                Parent.mainForm.rcbCNC.DropDownItems.Add(new RibbonButton(Parent.Machines[i].Name));
            }
        }

        private void BtnAddMachine_Click(object sender, EventArgs e)
        {
            addMachine.Show();
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (cbMachines.Text != "")
            {
                if (cbMachines.Text == "Auto"
                    || cbMachines.Text == "ISO"
                    || cbMachines.Text == "Heidenhain"
                    || cbMachines.Text == "Siemens")
                {
                    MessageBox.Show("You cannot delete the standard machines");
                }
                else
                {

                    var res = MessageBox.Show("Are you sure you want to delete this item?\nThis action cannot be reversed", "Important", MessageBoxButtons.YesNo);

                    if (res == DialogResult.Yes)
                    {
                        var item = Parent.Machines.First(r => r.Name == cbMachines.Text);
                        if (item != null)
                        {
                            console.log(item);
                            Parent.Machines.Remove(item);

                            cbMachines.Items.Clear();
                            for (var i = 0; i < Parent.Machines.Count(); i++)
                            {
                                cbMachines.Items.Add(Parent.Machines[i]);
                            }

                            using (var stream = File.Open(Path.Combine(Config.DirectoryPath, "machines.xml"), FileMode.Open))
                            {
                                lock (stream)
                                {
                                    stream.SetLength(0);
                                }
                            }

                            Utils.WriteText(Path.Combine(Config.DirectoryPath, "machines.xml"), XMLSerializer.ConvertMachineDefinitionsToString(Parent.Machines));
                        }
                    }else if(res == DialogResult.No)
                    {
                        //just cancel then
                    }
                }
            }
        }
    }
}
