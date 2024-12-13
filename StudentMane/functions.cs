using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace StudentMane
{
     class functions
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private DataTable dt;
        private SqlDataAdapter sda;
        private string ConStr;

       public functions()
        {
            ConStr = "Data Source=MOIZ\\SQLEXPRESS;Initial Catalog=StudentsDBS;Integrated Security=True;TrustServerCertificate=True";
            con = new SqlConnection(ConStr);
            cmd = new SqlCommand();
            cmd.Connection = con;

        }
        public DataTable GetData(string Query) 
        {
            dt = new DataTable();   
            sda = new SqlDataAdapter(Query, ConStr);
            sda.Fill(dt);
            return dt;

        }

        public int SetData (string Query)
        {
            int cnt;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd.CommandText = Query;
            cnt = cmd.ExecuteNonQuery();

            return cnt;
        }
    }
}
