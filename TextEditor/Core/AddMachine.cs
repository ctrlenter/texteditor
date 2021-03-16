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
using TextEditor.Core.XML;

namespace TextEditor.Core
{
    public partial class AddMachine : Form
    {
        CNCView parent;

        public AddMachine(CNCView parent)
        {
            InitializeComponent();
            FormClosing += this.AddMachine_FormClosing;
            this.parent = parent;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            this.MaximizeBox = false;
        }

        private void AddMachine_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (tbName.Text != "")
            {
                var name = tbName.Text;
                var oprRegex = tbOprRegex.Text;
                var tcRegex = tbTcRegex.Text;

                var machDef = new MachineDef();
                machDef.Name = name;
                machDef.OperationRegex = oprRegex;
                machDef.ToolCallRegex = tcRegex;

                if (parent.Parent.Machines.SingleOrDefault(r => r.Name == machDef.Name) == null)
                {
                    parent.Parent.Machines.Add(machDef);
                    parent.ReloadMachines();
                    Utils.WriteText(Path.Combine(Config.DirectoryPath,"machines.xml"),XML.XMLSerializer.ConvertMachineDefinitionsToString(parent.Parent.Machines));
                    this.Hide();
                }
                else
                {
                    MessageBox.Show($"Could not add machine.\nMachine with name \"{name}\" already exists!");
                }
            }
        }
    }
}
