using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentMane
{
    public partial class Dashboard : Form
    {
        functions con;
        public Dashboard()
        {
            InitializeComponent();
            con = new functions();
            countstd();
            countdepart();
            countMale();
        }
        private void countstd()
        {
            string Query = "Select count(*) as Stud from StudentTbl";

          
            foreach(DataRow dr in con.GetData(Query).Rows)
            {
                StdNamelbl.Text = dr["Stud"].ToString();
            }
        }

        private void countMale()
        {
            string Query = "Select count(*) as Male from StudentTbl where StGen = '{0}'";
            string Gen = "Male";
            Query = string.Format(Query, Gen);
            foreach (DataRow dr in con.GetData(Query).Rows)
            {
                StMalelbl.Text = dr["Male"].ToString();
            }
        }

        private void countdepart()
        {
            string Query = "Select count(*) as Depart from DepartmentTbl";


            foreach (DataRow dr in con.GetData(Query).Rows)
            {
                StDeparlbl.Text = dr["Depart"].ToString();
            }
        }
        private void label10_Click(object sender, EventArgs e)
        {
            Student obj = new Student();        
            obj.Show();
            this.Close();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Departments obj = new Departments();
            obj.Show();
            this.Close();
        }

        private void label22_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Close();
        }
    }
}
