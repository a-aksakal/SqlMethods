using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SqlCore
{
    class SqlCore
    {
        public string ConDirectory;
        public DataTable sqlDt;
        public SqlCore(string conDirectory)
        {
            ConDirectory = conDirectory;
        }

        public void SelectData(string sqlTableName)
        {
            SqlConnection con = new SqlConnection(ConDirectory);
            SqlCommand cmd = new SqlCommand("Select * From "+sqlTableName+"", con);
            SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
            sqlDt = new DataTable();
            sqlDa.Fill(sqlDt);
        }

        public void AddData(string sqlCommandText)
        {
            SqlConnection con = new SqlConnection(ConDirectory);
            SqlCommand cmd = new SqlCommand(sqlCommandText, con);
            SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }

        public void UpdateData()
        {

        }
    }
}
