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
    public partial class Student : Form
    {
        functions con;
        public Student()
        {
            InitializeComponent();
            con = new functions();
            ShowStudents();
            getDepartment();
        }
        private void ShowStudents()
        {
            string Query = "select * from StudentTbl";
            StudentsTbl.DataSource = con.GetData(Query);
        }
        private void getDepartment()
        {
            string Query = "Select*from DepartmentTbl";
            StDeparttb.DisplayMember = con.GetData(Query).Columns["DepName"].ToString();
            StDeparttb.ValueMember = con.GetData(Query).Columns["DepId"].ToString();
            StDeparttb.DataSource = con.GetData(Query);
        }
        private void clear()
        {
            StNametb.Text = "";
            StPhonetb.Text = "";
            StParenttb.Text = "";
            StAddtb.Text = "";
            gentb.SelectedIndex = -1;
        }
        private void Addbtn_Click(object sender, EventArgs e)
        {

            if (StNametb.Text == "" || StPhonetb.Text == ""|| StParenttb.Text == ""||StAddtb.Text == ""|| StDeparttb.SelectedIndex == -1 || gentb.SelectedIndex== -1)
            {
                MessageBox.Show("Missing Details");
            }
            else
            {
                try
                {

                    string Query = "insert into StudentTbl values('" + StNametb.Text + "', '" +gentb.SelectedItem.ToString() + "', '"+StPhonetb.Text+"', '"+StParenttb.Text+"', '"+StAddtb.Text+"', '"+StDeparttb.SelectedValue.ToString()+"')";
                    con.SetData(Query);
                    ShowStudents();
                    MessageBox.Show("Student Added!!!!");
                    clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex.Message);
                }
            }
        }
        int id;
        private void StudentsTbl_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                id = Convert.ToInt32(StudentsTbl.SelectedRows[0].Cells[0].Value.ToString());
                StNametb.Text = StudentsTbl.SelectedRows[0].Cells[1].Value.ToString();
                 gentb.SelectedItem= StudentsTbl.SelectedRows[0].Cells[2].Value.ToString();
                StPhonetb.Text = StudentsTbl.SelectedRows[0].Cells[3].Value.ToString();
                StParenttb.Text = StudentsTbl.SelectedRows[0].Cells[4].Value.ToString();
                StAddtb.Text = StudentsTbl.SelectedRows[0].Cells[5].Value.ToString();
                StDeparttb.SelectedValue = StudentsTbl.SelectedRows[0].Cells[6].Value.ToString();
            }
        }

        private void Updatebtn_Click(object sender, EventArgs e)
        {

            if (StNametb.Text == "" || StPhonetb.Text == "" || StParenttb.Text == "" || StAddtb.Text == "" || StDeparttb.SelectedIndex == -1 || gentb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Details");
            }
            else
            {
                try
                {

                    string Query = "Update StudentTbl set StName = '" + StNametb.Text + "',StGen =  '" + gentb.SelectedItem.ToString() + "',StPhone =  '" + StPhonetb.Text + "', StParent = '" + StParenttb.Text + "',StAdd =  '" + StAddtb.Text + "',StDepartment=  '" + StDeparttb.SelectedValue.ToString() + "' where  StCode = '"+id+"' ";
                    con.SetData(Query);
                    ShowStudents();
                    MessageBox.Show("Student Updated!!!!");
                    clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex.Message);
                }
            }
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

                    string Query = "Delete from  StudentTbl where  StCode = '" + id + "' ";
                    con.SetData(Query);
                    ShowStudents();
                    MessageBox.Show("Student Deleted!!!!");
                    clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex.Message);
                }
            }
        }

        private void DeparLbl_Click(object sender, EventArgs e)
        {
            Departments obj = new Departments();
            obj.Show();
            this.Hide();
        }

        private void DashLbl_Click(object sender, EventArgs e)
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
    }
}
