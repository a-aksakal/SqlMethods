using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SqlCore
{
    class SqlMethods
    {
        string ConnectionString;
        public DataTable sqlDt;
        string SqlTableName;
        
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

        public void DeleteData(string tableName,string columnName,int idNo)
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
