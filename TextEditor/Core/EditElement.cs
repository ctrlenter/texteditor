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
    public partial class EditElement : Form
    {
        EditPanel parent;
        PanelElement element;
        string path;
        string oldPath;

        public EditElement ( EditPanel panel )
        {
            parent = panel;
            InitializeComponent( );
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
        }

        public void Show ( PanelElement elem )
        {
            element = elem;
            tbItemName.Text = elem.text;
            lblOldPath.Text += " " + elem.path;
            oldPath = elem.path;
            ShowDialog( );
        }

        private void btnCancel_Click ( object sender, EventArgs e )
        {
            tbItemName.Text = "";
        }

        private void button2_Click ( object sender, EventArgs e )
        {
            FileDialog fileDialog = new OpenFileDialog( );
            if ( fileDialog.ShowDialog( ) == DialogResult.OK )
            {
                lblNewPath.Text = "New path: " + fileDialog.FileName;
                path = fileDialog.FileName;
            }
        }

        private void btnOkay_Click ( object sender, EventArgs e )
        {
            if ( string.IsNullOrEmpty( path ) )
            {
                path = oldPath;
            }
            element.path = path;
            element.text = tbItemName.Text;
            this.Hide( );
            tbItemName.Text = "";
            lblNewPath.Text = "";
            lblOldPath.Text = "Old path: ";
            parent.SelfUpdate( );
        }
    }
}
