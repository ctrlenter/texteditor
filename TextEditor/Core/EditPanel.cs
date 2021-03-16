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
    public partial class EditPanel : Form
    {

        public ExternalApplicationSettingView parent;

        public EditPanel ( ExternalApplicationSettingView view )
        {
            parent = view;
            InitializeComponent( );
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximumSize = this.Size;
            this.MinimizeBox = true;
            this.MinimumSize = this.Size;
            this.MaximizeBox = false;
        }

        ProgramPanel panel;

        public void Show ( ProgramPanel panel )
        {
            this.panel = panel;
            tbPanelName.Text = panel.text;
            dataGridView1.DataSource = LoadDataTable( panel );
            ShowDialog( );
            foreach ( DataGridViewColumn col in dataGridView1.Columns )
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

        }

        private DataTable LoadDataTable ( ProgramPanel panel )
        {
            var table = new DataTable( );
            table.Columns.Add( "Text" );
            table.Columns.Add( "Path" );

            for ( int i = 0 ; i < panel.Items.Count ; i++ )
            {
                var row = table.NewRow( );
                row [ "Text" ] = panel.Items [ i ].text;
                row [ "Path" ] = panel.Items [ i ].path;
                table.Rows.Add( row );
            }
            return table;
        }

        public void SelfUpdate ( )
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = LoadDataTable( panel );
        }

        private void btnEdit_Click ( object sender, EventArgs e )
        {
            foreach ( DataGridViewCell item in dataGridView1.SelectedCells )
            {
                if ( item.RowIndex < 0 ) continue;
                var itemAt = panel.Items [ item.RowIndex ];
                console.log( itemAt );
                if ( itemAt != null )
                {
                    new EditElement( this ).Show( itemAt );
                }
            }
        }

        private void btnSelectNewPath_Click ( object sender, EventArgs e )
        {
            //TODO: Implement this.
        }

        private void btnSave_Click ( object sender, EventArgs e )
        {
            panel.text = tbPanelName.Text;
            foreach(var item in panel.Items )
            {
                console.log( item );
            }
            parent.SavePanels( );
            this.Hide( );
            tbPanelName.Text = "";
            dataGridView1.DataSource = null;
            parent.BringToFront ( );
        }

        private void btnCancel_Click ( object sender, EventArgs e )
        {
            this.Hide( );
            tbPanelName.Text = "";
            dataGridView1.DataSource = null;
            parent.BringToFront ( );
        }

        private void btnRemove_Click ( object sender, EventArgs e )
        {
            foreach ( DataGridViewCell item in this.dataGridView1.SelectedCells )
            {
                if ( item.RowIndex < 0 ) continue;
                panel.Items.RemoveAt( item.RowIndex );
                this.dataGridView1.Rows.RemoveAt( item.RowIndex );
            }
        }

        private void btnAdd_Click ( object sender, EventArgs e )
        {
            new AddElement( this ).DoShow( panel );
        }
    }
}
