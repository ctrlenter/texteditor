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
    public partial class AddElement : Form
    {

        string path;
        string name;

        ProgramPanel panel;

        EditPanel Parent;

        public AddElement ( EditPanel edit )
        {
            InitializeComponent( );
            Parent = edit;
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public void DoShow ( ProgramPanel p )
        {
            panel = p;
            ShowDialog( );
        }

        private void btnSelectPath_Click ( object sender, EventArgs e )
        {
            var dialog = new OpenFileDialog( );
            if ( dialog.ShowDialog( ) == DialogResult.OK )
            {
                path = dialog.FileName;
                lblPath.Text = "Path: " + path;
            }
        }

        private void btnAdd_Click ( object sender, EventArgs e )
        {
            if ( !string.IsNullOrEmpty( path ) && !string.IsNullOrEmpty( tbElementName.Text ) )
            {
                console.log( "XDDD" );
                panel.Items.Add( new PanelElement( path, tbElementName.Text ) );
                this.Hide( );
                Parent.SelfUpdate( );
                path = "";
                tbElementName.Text = "";
            }
        }
    }
}
