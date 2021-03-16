using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditor.Core
{
    public partial class AddMachineForm : Form
    {
        string path; //The path to the folder you want to copy to
        string machineName; //User sees this
        int index; //used for identifying
        CopyToSettingView view;
        public AddMachineForm ( CopyToSettingView settingsView )
        {
            view = settingsView;
            InitializeComponent( );
            Load += AddMachineForm_Load;
            this.TopMost = view.SettingsForm.TopMost;
            this.BringToFront( );
        }

        private void AddMachineForm_Load ( object sender, EventArgs e )
        {
            this.TopMost = view.SettingsForm.mainForm.TopMost;
        }

        public new void ShowDialog ( )
        {

            this.TopMost = view.SettingsForm.mainForm.TopMost;
            this.Show( );
        }

        private void btnPickFolder_Click ( object sender, EventArgs e )
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog( );
            dialog.InitialDirectory = "C:\\";
            dialog.IsFolderPicker = true;
            if ( dialog.ShowDialog( ) == CommonFileDialogResult.Ok )
            {
                BringToFront( );
                path = dialog.FileName;
                lblActualPath.Text = path;
            }
        }

        private void btnSave_Click ( object sender, EventArgs e )
        {
            machineName = txMachineName.Text;
            if ( view.machines.Count == 0 )
                index = 0;
            else index = view.machines.Count;

            //Path does not need to be set since it has already been set up in pickFolderCLick
            txMachineName.Text = "";
            lblActualPath.Text = "";

            var machine = new Machine( );
            machine.ID = index;
            machine.MachineName = machineName;
            machine.FolderPath = path;

            if(view.AddItem(machine))
            {
                this.Hide( );
                view.SaveMachines( );
            }
            else
            {
                MessageBox.Show ( $"Could not add machine \"{machineName}\"" );
            }

        }

        private void AddMachineForm_FormClosing ( object sender, FormClosingEventArgs e )
        {
            if ( e.CloseReason == CloseReason.UserClosing )
            {
                e.Cancel = true;
                this.Hide( );
            }
        }
    }
}
