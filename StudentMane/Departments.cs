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
    public partial class Departments : Form
    {
        functions con;
        public Departments()
        {
            InitializeComponent();
            con = new functions();
            ShowDepartments();
        }
        private void ShowDepartments()
        {
            string Query = "select * from DepartmentTbl";
            departmenttable.DataSource= con.GetData(Query);
        }

        private void Addbtn_Click(object sender, EventArgs e)
        {
            if (DepNametb.Text == "" || Detailstb.Text == "")
            {
                MessageBox.Show("Missing Details");
            }
            else
            {
                try
                {
                 
                    string Query = "insert into DepartmentTbl(DepName, DepDetails) values('"+DepNametb.Text+"', '"+Detailstb.Text+"')";
                    con.SetData(Query);
                    ShowDepartments();
                    MessageBox.Show("Department Added!!!!");
                    clear();
                }catch(Exception ex)
                {
                    MessageBox.Show("Error : "+ ex.Message);
                }
            }

        }

       // int key;
        private void Updatebtn_Click(object sender, EventArgs e)
        {   if (DepNametb.Text == "" || Detailstb.Text == "")
            {
                MessageBox.Show("Missing Details");
            }
            else
            {
                try
                {
                 

                    string Query= " Update  DepartmentTbl set DepName = '"+DepNametb.Text+"', DepDetails ='"+Detailstb.Text+"' where DepId = '"+id+"'  ";
             
                    con.SetData(Query);
                    ShowDepartments();
                    MessageBox.Show("Department Updated!!!!");
                    clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex.Message);
                }
            }
        }

        private void departmenttable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {      
        }
        int id;
        private void departmenttable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>= 0)
            {
                id =Convert.ToInt32(departmenttable.SelectedRows[0].Cells[0].Value.ToString());
                DepNametb.Text = departmenttable.SelectedRows[0].Cells[1].Value.ToString();
                Detailstb.Text = departmenttable.SelectedRows[0].Cells[2].Value.ToString();
            }
        }
        private void clear()
        {
            DepNametb.Text = "";
            Detailstb.Text = "";
                
        }
        private void Deletebtn_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show("Select a row");
            }
            else
            {
                try
                {
               string Query = " Delete from  DepartmentTbl  where DepId = '" + id + "'  ";

                    con.SetData(Query);
                    ShowDepartments();
                    MessageBox.Show("Department Deleted!!!!");
                    clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex.Message);
                }
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Dashboard obj = new Dashboard();
            obj.Show();
            this.Hide();
        }

        private void label22_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Student obj = new Student();
            obj.Show();
            this.Hide();
        }
    }
}
