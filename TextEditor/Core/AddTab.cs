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
    public partial class AddTab : Form
    {

        ExternalApplicationSettingView parent;

        List<PanelElement> elements = new List<PanelElement>( );

        ProgramPanel panel = new ProgramPanel( );

        string path = "";

        public AddTab ( ExternalApplicationSettingView view )
        {
            parent = view;
            InitializeComponent( );
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        public DialogResult ShowFrame ( )
        {
            BringToFront( );
            return ShowDialog( );
        }

        private void btnOkay_Click ( object sender, EventArgs e )
        {
            panel.Items = elements;
            panel.text = tbName.Text;
            parent.AddItem( panel );
            parent.SavePanels( );
            this.Hide( );
            tbName.Text = "";
            lbItems.DataSource = null;
            elements.Clear( );
            parent.SelfUpdate( );
            parent.BringToFront ( );
        }

        private void btnAddPanel_Click ( object sender, EventArgs e )
        {
            if ( !string.IsNullOrEmpty( tbItemName.Text ) )
            {
                if ( !string.IsNullOrEmpty( path ) )
                {
                    var item = new PanelElement( );
                    item.path = path;
                    item.text = tbItemName.Text;
                    elements.Add( item );
                    RefreshItems( );
                    path = "";
                    tbItemName.Text = "";
                    lblPath.Text = "";
                }
            }

        }

        private void RefreshItems ( )
        {
            lbItems.DataSource = null;
            lbItems.DataSource = elements;
        }

        private void btnRemPanel_Click ( object sender, EventArgs e )
        {

        }

        private void btnCancel_Click ( object sender, EventArgs e )
        {
            elements.Clear( );
            panel.text = "";
            this.Hide( );
            tbName.Text = "";
            lbItems.DataSource = null;
            parent.BringToFront ( );
        }

        private void btnSelectPath_Click ( object sender, EventArgs e )
        {
            var dialog = new OpenFileDialog( );
            if ( dialog.ShowDialog( ) == DialogResult.OK )
            {
                BringToFront( );
                path = dialog.FileName;
                lblPath.Text = path;
            }
        }
    }
}
