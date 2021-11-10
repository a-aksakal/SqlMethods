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
        public string ConnectionString;
        public DataTable sqlDt;
        public string SqlTableName;
        public SqlMethods(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public void SelectData(string sqlTableName)
        {
            SqlTableName = sqlTableName;
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("Select * From "+sqlTableName+"", con);
            SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
            sqlDt = new DataTable();
            sqlDa.Fill(sqlDt);
        }

        public void AddData(string sqlCommandText)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand(sqlCommandText, con);
            SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            SelectData(SqlTableName);
        }

        public void UpdateData(string sqlCommandText)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand(sqlCommandText, con);
            SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            SelectData(SqlTableName);
        }

        public void DeleteData(string sqlCommandText)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand(sqlCommandText, con);
            SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            SelectData(SqlTableName);
        }
    }
}
