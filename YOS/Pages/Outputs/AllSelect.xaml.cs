using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Data;

namespace YOS.Pages.Outputs
{
    /// <summary>
    /// Interaction logic for About.xaml
    /// </summary>
    public partial class AllSelect : UserControl
    {
        private int intEMPNO;
        private string strCommand;
        private OracleConnection odpConn = new OracleConnection();

        public int getintEMPNO
        {
            get { return intEMPNO; }
        }
        public string getstrCommand
        {
            get { return strCommand; }
        }
        public AllSelect()
        {
            InitializeComponent();
        }

        //private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{

        //}


        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            showDataGrid();
        }

        private void showDataGrid()
        {
            try
            {
                odpConn.ConnectionString = "User Id=dba_soo;Password=tnalsl;Data Source=MYORACLE;";

                odpConn.Open();

                OracleDataAdapter oda = new OracleDataAdapter();

                oda.SelectCommand = new OracleCommand("SELECT * from COPYEMP", odpConn);

                //oda.SelectCommand.Parameters.Add("JOB_ID", OracleDbType.Varchar2, 10);
                //oda.SelectCommand.Parameters["JOB_ID"].Value = "IT_PROG";

                DataTable dt = new DataTable();
                oda.Fill(dt);
                odpConn.Close();

                dataGrid.ItemsSource = dt.DefaultView;

                dataGrid.Columns();
                dataGrid.ColumnWidth = AutoSizeColumnsMode.Fill;

                dataGrid.SelectionMode = DataGridSelectionMode.Extended;
                dataGrid.CanUserAddRows = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("에러 발생: " + ex.ToString());
                odpConn.Close();
            }
        }

        private void SelRowDelete_Click(object sender, RoutedEventArgs e)
        {
            strCommand = "삭제";
            intEMPNO = Convert.ToInt32(dataGridView1.SelectedCells[0].Value);
            frmDML fDML = new frmDML(this);
            fDML.ShowDialog();
            fDML.Dispose();
            showDataGridView();
        }

        private void SelRowUpdate_Click(object sender, RoutedEventArgs e)
        {
            strCommand = "업데이트";
            intEMPNO = Convert.ToInt32(dataGridView1.SelectedCells[0].Value);
            frmDML fDML = new frmDML(this);
            fDML.ShowDialog();
            fDML.Dispose();
            showDataGridView();
        }

        private void SelRowNew_Click(object sender, RoutedEventArgs e)
        {
            strCommand = "추가";
            frmDML fDML = new frmDML(this);
            fDML.ShowDialog();
            fDML.Dispose();
            showDataGridView();
        }
    }
}
