using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HastaneRandevuSistemi.Data
{
    class SqlMethods
    {
        string ConnectionString;
        public DataTable sqlDt;
        string SqlTableName;
        SqlDataReader sqlDr;
        public static int bolumId; //Special variale you can delete.
        public static int hastaneId; //Special variable you can delete.
        public static int hastaId; //Special variable you can delete.

        public SqlMethods(string connectionString)
        {
            
            ConnectionString = connectionString;
        }


        public void SelectData(string sqlTableName)
        {
            SqlTableName = sqlTableName;
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("Select * From " + sqlTableName + "", con);
            SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
            sqlDt = new DataTable();
            sqlDa.Fill(sqlDt);
        }

        public void SelectSpecialData(string sqlCommandText)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand(sqlCommandText, con);
            SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
            sqlDt = new DataTable();
            sqlDa.Fill(sqlDt);
        }

        public void FillCombobox(string sqlCommandText,ComboBox cmbName,string columnName)
        {
            cmbName.Items.Clear();
            cmbName.Text = null;
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(sqlCommandText, con);
            sqlDr = cmd.ExecuteReader();
            while (sqlDr.Read())
            {
                
                cmbName.Items.Add(sqlDr[""+columnName+""]);
            }
            con.Close();
        }

        //Special Method Not General, You Can Delete NameConvertToBolumId Method
        public void NameConvertToBolumId(string sqlCommandText, string columnName)
        {
            
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(sqlCommandText, con);
            sqlDr = cmd.ExecuteReader();
            while (sqlDr.Read())
            {

                SqlMethods.bolumId =Convert.ToInt32((sqlDr["" + columnName + ""]));
                
            }
            con.Close();
        }

        //Special Method Not General, You Can Delete NameConvertToHastaneId Method
        public void NameConvertToHastaneId(string sqlCommandText, string columnName)
        {

            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(sqlCommandText, con);
            sqlDr = cmd.ExecuteReader();
            while (sqlDr.Read())
            {

                SqlMethods.hastaneId = Convert.ToInt32((sqlDr["" + columnName + ""]));

            }
            con.Close();
        }

        public void KullaniciAdiConvertToId(string sqlCommandText,string columnName)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(sqlCommandText, con);
            sqlDr = cmd.ExecuteReader();
            while (sqlDr.Read())
            {

                SqlMethods.hastaId = Convert.ToInt32((sqlDr["" + columnName + ""]));

            }
            con.Close();
        }

        //Special Method Not General, You Can Delete CheckAppointment Method
        public void CheckAppointment(string sqlCommandText, string columnName,Panel panel)
        {
            
            List<string> values = new List<string>(99);
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(sqlCommandText, con);
            sqlDr = cmd.ExecuteReader();
                while (sqlDr.Read())
                {

                    values.Add(sqlDr["" + columnName + ""].ToString());
                }
                foreach (Control c in panel.Controls)
                {
                    if (c is Button)
                    {
                        Button b = c as Button;
                        if (values.Contains(b.Text))
                        {
                            b.Enabled = false;
                            b.BackColor = System.Drawing.Color.DarkSeaGreen;
                        }
                        else
                        {
                            b.Enabled = true;
                            b.BackColor = System.Drawing.Color.Chartreuse;
                        }
                    }
                }
            
            con.Close();
        }
        
        public void LoginCheck(string sqlCommandText,Form whichFormShow,Form whichFormClose)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(sqlCommandText, con);
            sqlDr = cmd.ExecuteReader();
            if (sqlDr.Read())
            {
                MessageBox.Show("Tebrikler! Başarılı bir şekilde giriş yaptınız.");
                whichFormShow.Show();
                whichFormClose.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı giriş yaptınız.");
            }
            con.Close();
        }

        public void SignUp(string sqlCommandText,string addDataText)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(sqlCommandText, con);
            sqlDr = cmd.ExecuteReader();
            if (sqlDr.Read())
            {
                MessageBox.Show("Bu kullanıcı adına sahip üye var lütfen başka kullanıcı adı deneyiniz.");
                
            }
            else
            {
                MessageBox.Show("Üyelik oluşturulmuştur.");
                AddData(addDataText);
            }
            con.Close();
        }

        public void AddData(string sqlCommandText)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(sqlCommandText, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void UpdateData(string sqlCommandText)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(sqlCommandText, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteData(string tableName, string columnName, int idNo)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string sqlCommandText = "Delete from " + tableName + " where " + columnName + " = " + idNo + "";
            SqlCommand cmd = new SqlCommand(sqlCommandText, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
