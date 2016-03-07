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
    /// DataControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class DataControl : UserControl
    {
        private OracleConnection odpConn = new OracleConnection();
        private AllSelect _parent;

        public DataControl(AllSelect inform1)
        {
            InitializeComponent();
            _parent = inform1;
        }

        private void frmCtrl_Loaded(object sender, RoutedEventArgs e)
        {
            if (_parent.getstrCommand == "삭제")
            {
                btnOK.Name = "삭제";
                txtEMPNO.IsEnabled = false;
                initialTextBoxes();

            }
            else if (_parent.getstrCommand == "업데이트")
            {
                btnOK.Name = "업데이트";
                txtEMPNO.IsEnabled = false;
                txtENAME.IsEnabled = false;
                txtHIREDATE.IsEnabled = false;
                initialTextBoxes();
            }
            else btnOK.Name = "추가";
        }

        private void initialTextBoxes() //텍스트 박스들의 초기화 메서드
        {
            odpConn.ConnectionString = "User Id=dba_soo;Password=tnalsl;Data Source=MYORACLE;";

            odpConn.Open();

            string strqry = "SELECT * FROM COPYEMP WHERE EMPLOYEE_ID=:EMPLOYEE_ID";
            OracleCommand OraCmd = new OracleCommand(strqry, odpConn);

            OraCmd.Parameters.Add("EMPLOYEE_ID", OracleDbType.Int32, 6).Value = _parent.getintEMPNO;
            OracleDataReader odr = OraCmd.ExecuteReader();

            while (odr.Read())
            {
                txtEMPNO.Text = Convert.ToString(odr.GetValue(0));
                txtENAME.Text = Convert.ToString(odr.GetValue(1));
                txtJOB.Text = Convert.ToString(odr.GetValue(10));
                txtMGR.Text = Convert.ToString(odr.GetValue(6));
                txtHIREDATE.Text = Convert.ToString(odr.GetValue(4));
                txtSAL.Text = Convert.ToString(odr.GetValue(5));
                txtCOMM.Text = Convert.ToString(odr.GetValue(7));
                txtDEPTNO.Text = Convert.ToString(odr.GetValue(9));

            }
            odr.Close();
            odpConn.Close();

        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            if (btnOK.Name == "추가")
            {
                if (INSERTRow() > 0)
                {
                    MessageBox.Show("정상적으로 데이터 행이 추가되었습니다.");
                }
                else MessageBox.Show("데이터 행이 추가되지 않았습니다.");
                //frmCtrl.
            }
            else if (btnOK.Name == "삭제")
            {
                if (DELETERow() > 0)
                {
                    MessageBox.Show("정상적으로 데이터 행이 삭제되었습니다.");
                }
                else MessageBox.Show("데이터 행이 삭제되지 않았습니다.");
                //this.Close();
            }
            else
            {
                if (UPDATERow() > 0)
                {
                    MessageBox.Show("정상적으로 데이터가 업데이트되었습니다.");
                }
                else MessageBox.Show("데이터 행이 업데이트되지 않았습니다.");
                //this.Close();
            }
        }

        private int INSERTRow()
        {
            odpConn.ConnectionString = "User Id=dba_soo;Password=tnalsl;Data Source=MYORACLE;";

            odpConn.Open();

            string strqry = "INSERT INTO COPYEMP VALUES(:EMPLOYEE_ID,:EMP_NAME,:JOB_ID,:MANAGER_ID,:HIRE_DATE,:SALARY,:COMMISSION_PCT,:DEPARTMENT_ID)";
            OracleCommand OraCmd = new OracleCommand(strqry, odpConn);

            OraCmd.Parameters.Add(":EMPLOYEE_ID", OracleDbType.Int32, 6).Value = txtEMPNO.Text.Trim();
            OraCmd.Parameters.Add(":EMP_NAME", OracleDbType.Varchar2, 80).Value = txtENAME.Text.Trim();
            OraCmd.Parameters.Add(":JOB_ID", OracleDbType.Varchar2, 10).Value = txtJOB.Text.Trim();
            OraCmd.Parameters.Add(":MANAGER_ID", OracleDbType.Int32, 6).Value = txtMGR.Text.Trim();
            OraCmd.Parameters.Add(":HIRE_DATE", OracleDbType.Date).Value = txtHIREDATE.Text.Trim();
            OraCmd.Parameters.Add(":SALARY", OracleDbType.Decimal).Value = txtSAL.Text.Trim();
            OraCmd.Parameters.Add(":COMMISSION_PCT", OracleDbType.Decimal).Value = txtCOMM.Text.Trim();
            OraCmd.Parameters.Add(":DEPARTMENT_ID", OracleDbType.Int32, 6).Value = txtDEPTNO.Text.Trim();

            return OraCmd.ExecuteNonQuery(); //추가되는 행수 반환

        }

        private int DELETERow()
        {
            odpConn.ConnectionString = "User Id=dba_soo;Password=tnalsl;Data Source=MYORACLE;";

            odpConn.Open(); //열기

            string strqry = "DELETE FROM COPYEMP WHERE EMPLOYEE_ID=:EMPLOYEE_ID";
            OracleCommand OraCmd = new OracleCommand(strqry, odpConn);

            OraCmd.Parameters.Add("EMPLOYEE_ID", OracleDbType.Int32, 6).Value = _parent.getintEMPNO;

            return OraCmd.ExecuteNonQuery();
        }

        private int UPDATERow()
        {
            odpConn.ConnectionString = "User Id=dba_soo;Password=tnalsl;Data Source=MYORACLE;";

            odpConn.Open();

            string strqry = "UPDATE COPYEMP SET JOB_ID=:JOB_ID, MANAGER_ID=:MANAGER_ID, SALARY=:SALARY, COMMISSION_PCT=:COMMISSION_PCT, DEPARTMENT_ID=:DEPARTMENT_ID, EMPLOYEE_ID=:EMPLOYEE_ID";
            OracleCommand OraCmd = new OracleCommand(strqry, odpConn);

            OraCmd.Parameters.Add(":JOB_ID", OracleDbType.Varchar2, 10).Value = txtJOB.Text.Trim();
            OraCmd.Parameters.Add(":MANAGER_ID", OracleDbType.Int32, 6).Value = txtMGR.Text.Trim();
            OraCmd.Parameters.Add(":SALARY", OracleDbType.Decimal).Value = txtSAL.Text.Trim();
            OraCmd.Parameters.Add(":COMMISSION_PCT", OracleDbType.Decimal).Value = txtCOMM.Text.Trim();
            OraCmd.Parameters.Add(":DEPARTMENT_ID", OracleDbType.Int32, 6).Value = txtDEPTNO.Text.Trim();
            OraCmd.Parameters.Add(":EMPLOYEE_ID", OracleDbType.Int32, 6).Value = _parent.getintEMPNO;
            return OraCmd.ExecuteNonQuery(); //업데이트되는 행수 반환
        }
    }
}
