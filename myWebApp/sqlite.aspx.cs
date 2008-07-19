using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using System.Data.SQLite;

namespace myWebApp
{
    public partial class sqlite : System.Web.UI.Page
    {
        static string connstring = @"Data Source=D:\WUTemp\mysampleapp\myWebApp\Data\mydb.s3db";
    
        protected void Page_Load(object sender, EventArgs e)
        {
            connstring = string.Format("Data Source={0}", ConfigurationManager.AppSettings["sqlitedb"]);

            if (!string.IsNullOrEmpty(Request.QueryString["add"]))
                addRow();

            DataTable dt = GetDataTable("select * from mydoc");
            gv.DataSource = dt;
            gv.DataBind();
        }

        void addRow()
        {
            ExecuteNonQuery(
                string.Format(@"insert into mydoc (lib,path,title,description) values ('mydoc','c:\document\od','mon résumé','description du document étiré')"));
        }

        public static DataTable GetDataTable(string sql)
        {

            DataTable dt = new DataTable();

            try
            {

                SQLiteConnection cnn = new SQLiteConnection(connstring);

                cnn.Open();

                SQLiteCommand mycommand = new SQLiteCommand(cnn);

                mycommand.CommandText = sql;

                SQLiteDataReader reader = mycommand.ExecuteReader();

                dt.Load(reader);

                reader.Close();

                cnn.Close();

            }
            catch
            {

                // Catching exceptions is for communists

            }

            return dt;

        }

        public static int ExecuteNonQuery(string sql)
        {

            SQLiteConnection cnn = new SQLiteConnection(connstring);

            cnn.Open();

            SQLiteCommand mycommand = new SQLiteCommand(cnn);

            mycommand.CommandText = sql;

            int rowsUpdated = mycommand.ExecuteNonQuery();

            cnn.Close();

            return rowsUpdated;

        }

        public static string ExecuteScalar(string sql)
        {

            SQLiteConnection cnn = new SQLiteConnection(connstring);

            cnn.Open();

            SQLiteCommand mycommand = new SQLiteCommand(cnn);

            mycommand.CommandText = sql;

            object value = mycommand.ExecuteScalar();

            cnn.Close();

            if (value != null)            
                return value.ToString();

            return string.Empty;

        }
    }
}
