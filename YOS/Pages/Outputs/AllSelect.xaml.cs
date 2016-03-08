using System;
using System.Collections.Generic;
//using System.Linq;
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
    //{
    //    string strOraConn = "Data Source=MYORACLE;User Id=dba_soo;Password=tnalsl";

    //    private int intEMPNO;
    //    private string strCommand;
    //    private OracleConnection OraCon = new OracleConnection();

    //    public int getintEMPNO
    //    {
    //        get { return intEMPNO; }
    //    }
    //    public string getstrCommand
    //    {
    //        get { return strCommand; }
    //    }
    //    public AllSelect()
    //    {
    //        InitializeComponent();
    //    }

    //    //private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
    //    //{

    //    //}


    //    private void UserControl_Loaded(object sender, RoutedEventArgs e)
    //    {
    //        showDataGrid();

    //        if (getstrCommand == "삭제")
    //        {
    //            btnOK.Name = "삭제";
    //            txtEMPNO.IsEnabled = false;
    //            initialTextBoxes();

    //        }
    //        else btnOK.Name = "추가";
    //    }

    //    private void showDataGrid()
    //    {
    //        try
    //        {
    //            OracleConnection OraCon = new OracleConnection(strOraConn);

    //            OraCon.Open();

    //            OracleDataAdapter oda = new OracleDataAdapter();

    //            oda.SelectCommand = new OracleCommand("SELECT * from COPYEMP", OraCon);

    //            DataTable dt = new DataTable();
    //            oda.Fill(dt);

    //            OraCon.Close();

    //            dataGrid.ItemsSource = dt.DefaultView;

    //            //dataGrid.Columns();
    //            //dataGrid.ColumnWidth = Datagrid.Fill;

    //            dataGrid.SelectionMode = DataGridSelectionMode.Extended;
    //            dataGrid.CanUserAddRows = true;

    //        }
    //        catch (Exception ex)
    //        {
    //            MessageBox.Show("에러 발생: " + ex.ToString());
    //            OraCon.Close();
    //        }
    //    }

    //    private void SelRowDelete_Click(object sender, RoutedEventArgs e)
    //    {
    //        strCommand = "삭제";
    //        intEMPNO = Convert.ToInt32(dataGrid.SelectedCells[0].Column);
    //        //DataCtrl fDML = new DataCtrl(this);
    //        //fDML.ShowDialog();
    //        //fDML.Dispose();
    //        DELETERow();
    //        if (DELETERow() > 0)
    //        {
    //            MessageBox.Show("정상적으로 데이터 행이 삭제되었습니다.");
    //        }
    //        else MessageBox.Show("데이터 행이 삭제되지 않았습니다.");
    //        showDataGrid();
    //    }

    //    private void SelRowNew_Click(object sender, RoutedEventArgs e)
    //    {
    //        strCommand = "추가";
    //        //AllSelect fDML = new AllSelect(this);
    //        //fDML.ShowDialog();
    //        //fDML.Dispose();
    //        showDataGrid();
    //    }

    //    private void btnOK_Click(object sender, RoutedEventArgs e)
    //    {
    //        if (btnOK.Name == "추가")
    //        {
    //            if (INSERTRow() > 0)
    //            {
    //                MessageBox.Show("정상적으로 데이터 행이 추가되었습니다.");
    //            }
    //            else MessageBox.Show("데이터 행이 추가되지 않았습니다.");
    //            //frmCtrl.
    //        }
    //        else if (btnOK.Name == "삭제")
    //        {
    //            if (DELETERow() > 0)
    //            {
    //                MessageBox.Show("정상적으로 데이터 행이 삭제되었습니다.");
    //            }
    //            else MessageBox.Show("데이터 행이 삭제되지 않았습니다.");
    //            //this.Close();
    //        }
    //    }
 
    //private void initialTextBoxes() //텍스트 박스들의 초기화 메서드
    //    {
    //        OracleConnection OraCon = new OracleConnection(strOraConn);
    //        OraCon.Open();

    //        string strqry = "SELECT * FROM COPYEMP WHERE EMPLOYEE_ID=:EMPLOYEE_ID";
    //        OracleCommand OraCmd = new OracleCommand(strqry, OraCon);

    //        OraCmd.Parameters.Add("EMPLOYEE_ID", OracleDbType.Int32, 6).Value = getintEMPNO;
    //        OracleDataReader odr = OraCmd.ExecuteReader();

    //        while (odr.Read())
    //        {
    //            txtEMPNO.Text = Convert.ToString(odr.GetValue(0));
    //            txtENAME.Text = Convert.ToString(odr.GetValue(1));
    //            txtJOB.Text = Convert.ToString(odr.GetValue(10));
    //            txtMGR.Text = Convert.ToString(odr.GetValue(6));
    //            txtHIREDATE.Text = Convert.ToString(odr.GetValue(4));
    //            txtSAL.Text = Convert.ToString(odr.GetValue(5));
    //            txtCOMM.Text = Convert.ToString(odr.GetValue(7));
    //            txtDEPTNO.Text = Convert.ToString(odr.GetValue(9));

    //        }
    //        odr.Close();
    //        OraCon.Close();

    //    }

    //    private int INSERTRow()
    //    {
    //        OracleConnection OraCon = new OracleConnection(strOraConn);
    //        OraCon.Open();

    //        string strqry = "INSERT INTO COPYEMP VALUES(:EMPLOYEE_ID,:EMP_NAME,:JOB_ID,:MANAGER_ID,:HIRE_DATE,:SALARY,:COMMISSION_PCT,:DEPARTMENT_ID)";
    //        OracleCommand OraCmd = new OracleCommand(strqry, OraCon);

    //        OraCmd.Parameters.Add(":EMPLOYEE_ID", OracleDbType.Int32, 6).Value = txtEMPNO.Text.Trim();
    //        OraCmd.Parameters.Add(":EMP_NAME", OracleDbType.Varchar2, 80).Value = txtENAME.Text.Trim();
    //        OraCmd.Parameters.Add(":JOB_ID", OracleDbType.Varchar2, 10).Value = txtJOB.Text.Trim();
    //        OraCmd.Parameters.Add(":MANAGER_ID", OracleDbType.Int32, 6).Value = txtMGR.Text.Trim();
    //        OraCmd.Parameters.Add(":HIRE_DATE", OracleDbType.Date).Value = txtHIREDATE.Text.Trim();
    //        OraCmd.Parameters.Add(":SALARY", OracleDbType.Decimal).Value = txtSAL.Text.Trim();
    //        OraCmd.Parameters.Add(":COMMISSION_PCT", OracleDbType.Decimal).Value = txtCOMM.Text.Trim();
    //        OraCmd.Parameters.Add(":DEPARTMENT_ID", OracleDbType.Int32, 6).Value = txtDEPTNO.Text.Trim();

    //        return OraCmd.ExecuteNonQuery(); //추가되는 행수 반환

    //    }

    //    private int DELETERow()
    //    {
    //        OracleConnection OraCon = new OracleConnection(strOraConn);
    //        OraCon.Open(); //열기

    //        string strqry = "DELETE FROM COPYEMP WHERE EMPLOYEE_ID=:EMPLOYEE_ID";
    //        OracleCommand OraCmd = new OracleCommand(strqry, OraCon);

    //        OraCmd.Parameters.Add("EMPLOYEE_ID", OracleDbType.Int32, 6).Value = getintEMPNO;

    //        return OraCmd.ExecuteNonQuery();

    //    }
    //}
}
