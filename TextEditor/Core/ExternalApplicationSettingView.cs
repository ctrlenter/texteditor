using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextEditor.Core.XML;

namespace TextEditor.Core
{
    public partial class ExternalApplicationSettingView : UserControl
    {
        public SettingsForm settingsForm;

        public List<ProgramPanel> panels = new List<ProgramPanel>( );

        AddTab addTab;

        public ExternalApplicationSettingView ( SettingsForm form )
        {
            settingsForm = form;
            addTab = new AddTab( this );
            InitializeComponent( );
            Load += ExternalApplicationSettingView_Load;
        }

        private void ExternalApplicationSettingView_Load ( object sender, EventArgs e )
        {
            //TODO: implement loading of the different machines. possibly create my own class for storing this data since it just says "Item1","Item2" and "Item3" in the tuple
            //panels = Utils.LoadPanels( );
            //DataTable table = ConvertListToDataTable(  );
            //dataGridView1.DataSource = table;
            //foreach ( DataGridViewColumn elem in dataGridView1.Columns )
            //{
            //    elem.SortMode = DataGridViewColumnSortMode.NotSortable;
            //}

            panels = Utils.LoadPanels( );
            console.log( "xd" + panels.Count );
            DataTable table = LoadDataTable( panels );
            dataGridView1.DataSource = table;
            foreach ( DataGridViewColumn elem in dataGridView1.Columns )
            {
                elem.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private DataTable LoadDataTable ( List<ProgramPanel> list )
        {
            var tb = new DataTable( );

            tb.Columns.Add( "Name" );

            for ( int i = 0 ; i < panels.Count ; i++ )
            {
                var row = tb.NewRow( );
                row [ "Name" ] = panels [ i ].text;
                tb.Rows.Add( row );
            }

            return tb;
        }

        public void SavePanels ( )
        {
            var xml = XMLSerializer.PanelListToXML( panels );
            Utils.WriteText( Utils.panelsFile, xml );
            SelfUpdate( );
        }

        public void SelfUpdate ( )
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = LoadDataTable( panels );
        }
        
        public void AddItem ( ProgramPanel item )
        {
            panels.Add( item );
        }

        private void btnAdd_Click ( object sender, EventArgs e )
        {
            addTab.TopMost = settingsForm.TopMost;
            addTab.ShowFrame( );
        }
        
        public void HardReload ( )
        {
            panels = XMLSerializer.LoadTabsFromXml( Utils.panelsFile );
            dataGridView1.DataSource = LoadDataTable( panels );
        }

        private void btnEdit_Click ( object sender, EventArgs e )
        {
            foreach ( DataGridViewCell item in dataGridView1.SelectedCells )
            {
                console.log( item.RowIndex );
                if ( item.RowIndex < 0 ) continue;
                var itemAt = panels [ item.RowIndex ];
                if ( itemAt != null )
                {
                    new EditPanel( this ).Show( itemAt );
                }
            }
        }

        private void btnDelete_Click ( object sender, EventArgs e )
        {
            foreach ( DataGridViewCell item in this.dataGridView1.SelectedCells )
            {
                if ( item.RowIndex < 0 ) continue;
                console.log( item.RowIndex );
                panels.RemoveAt( item.RowIndex );
                this.dataGridView1.Rows.RemoveAt( item.RowIndex );
                SavePanels( );
            }
        }
    }
}
