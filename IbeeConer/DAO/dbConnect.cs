using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAO
{
    public class dbConnect
    {
        public static SqlConnection conn;

        string strconn = System.Configuration.ConfigurationSettings.AppSettings["MYCONN"];
      //  string strconn = @"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\IbeeConer.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
        public dbConnect()
        {
            try
            {
                conn = new SqlConnection(strconn);
            }
            catch (Exception)
            {
                
                MessageBox.Show("Không kết nối được csdl", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            
        }

        public void MoKetNoi()
        {
            if (dbConnect.conn == null)
                dbConnect.conn = new SqlConnection(@"Data Source=NHATMINH\NHATMINH;Initial Catalog=IbeeConer;Integrated Security=True");
            if (dbConnect.conn.State != ConnectionState.Open)
                dbConnect.conn.Open();
        }

        public void DongKetNoi()
        {
            if (dbConnect.conn != null)
            {
                if (dbConnect.conn.State == ConnectionState.Open)
                    dbConnect.conn.Close();
            }
        }
        public DataTable GetData(string strSQL) //select
        {
            // MoKetNoi();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(strSQL, conn);
            conn.Open();
            da.Fill(dt);
            conn.Close();
            //DongKetNoi();
            return dt;
        }

        public DataTable GetData(string procName, SqlParameter[] para)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = procName;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            if (para != null)
                cmd.Parameters.AddRange(para);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            conn.Open();
            da.Fill(dt);
            conn.Close();
            return dt;
        }

        public int ExecuteSQL(string strSQL)
        {
            SqlCommand cmd = new SqlCommand(strSQL, conn);
            conn.Open();
            int row = cmd.ExecuteNonQuery();
            conn.Close();
            return row;
        }

        public int ExecuteSQL(string procName, SqlParameter[] para)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = procName;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
            if (para != null)
                cmd.Parameters.AddRange(para);
            conn.Open();
            int row = cmd.ExecuteNonQuery();
            conn.Close();
            return row;
        }
        public bool KiemTraTonTaiId(string id, string tablename)
        {
            bool tontai = false;
            SqlCommand cmd = new SqlCommand("Select * from " + tablename + "", conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (id == dr.GetString(0))
                {
                    tontai = true;
                    break;
                }
            }
            conn.Close();
            return tontai;
        }
        public string LayIdTuDong(string tienTo, int chieuDai, string tablename)
        {
            var i = 0;
            string result;
            do
            {
                i++;
                result = tienTo;
                while ((result + i).Length < chieuDai)
                {
                    result = result.Insert(tienTo.Length, "0");
                }
            } while (KiemTraTonTaiId(result + i, tablename));

            return result + i;
        }
    }
}

