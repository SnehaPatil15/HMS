﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMSA
{
    public partial class Dashboard : Form
    {
        String path = "Data Source=(localdb)\\MSSqlLocalDB; Initial Catalog=hospital; Integrated Security=True";
        SqlConnection con;
        SqlCommand cmd;
        // List<Panel> listPanel = new List<Panel>();
        public void hidepanels()
        {
            //panel1.Visible = false;
            //panel2.Visible = false;
            //panel3.Visible = false;
            //panel4.Visible = false;
        }

        public Dashboard()
        {
            InitializeComponent();
            con = new SqlConnection(path);
            //Load += new EventHandler(Dashboard_Load);
             panel2.Location = panel1.Location;
            panel3.Location = panel1.Location;
            //panel4.Location = panel1.Location;
        }



        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }





        private void labelIndecator3_Click(object sender, EventArgs e)
        {
        }

        private void labelIndecator4_Click(object sender, EventArgs e)
        {
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;


        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }



        private void label14_Click(object sender, EventArgs e)
        {

        }



        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }



        private void btnSave_Click(object sender, EventArgs e)
        {

            if (txtName.Text == "" || txtAddress.Text == "" || txtContactNumber.Text == "" || txtAge.Text == "" || txtBlood.Text == "" || txtAny.Text == "" || txtPid.Text == "")
            {
                MessageBox.Show("Plese fill in the blanks");
            }
            else
            {
                try
                {

                    string Gender;
                    if (radioButton1.Checked) { Gender = "Male"; }
                    else { Gender = "Female"; }
                    con.Open();
                    cmd = new SqlCommand("insert into AddPatient(Name,Full_Address,Contact,Age,Gender ,Blood_Group,Major_Disease,pid) values('" + txtName.Text + "', '" + txtAddress.Text + "', '" + txtContactNumber.Text + "', '" + txtAge.Text + "', '" + Gender + "', '" + txtBlood.Text + "', '" + txtAny.Text + "', '" + txtPid.Text + "')", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("data has been saved in database");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                //MessageBox.Show("");
                txtName.Clear();
                txtAddress.Clear();
                txtContactNumber.Clear();
                txtAge.Clear();
                txtBlood.Clear();
                txtAny.Clear();
                txtPid.Clear();
            }
        }

        private void btnAddPatient_Click_1(object sender, EventArgs e)
        {

            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
        }



        private void btnAddMoreInfo_Click(object sender, EventArgs e)
        {
            //hidepanels();
            panel2.Visible = true;
            panel1.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
        }
        

        private void label14_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textpid_TextChanged(object sender, EventArgs e)
        {

            if (textpid.Text != "")
            {
                int pid = int.Parse(textpid.Text);

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from AddPatient where pid=" + pid + "";
                //cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                //int a;

                dataGridView1.DataSource = ds.Tables[0];

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int pid = int.Parse(textpid.Text);


                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "insert into PatientMore(pid,Symptoms,Diagonosis,Medicines,Ward ,Ward_Type) values('" + textpid.Text + "', '" + txtSymptoms.Text + "', '" + txtDignosis.Text + "', '" + txtMedicines.Text + "', '" + comboBox1.Text + "',  '" + comboBox2.Text + "')";
                //cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                MessageBox.Show("data has been saved in database");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            textpid.Clear();
            txtSymptoms.Clear();
            txtDignosis.Clear();
            txtMedicines.Clear();

        
    }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel1.Visible = false;
            panel2.Visible = false;
            panel4.Visible = false;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from AddPatient inner join PatientMore on AddPatient.pid=PatientMore.pid";
            //cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
            //panel3.Visible = true;
            //panel4.Visible = false;

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnHospitalInfo_Click(object sender, EventArgs e)
        {
            
            panel4.Visible = true;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
        }

        //private void btnShow_Click(object sender, EventArgs e)
        //{
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.Connection = con;
        //    cmd.CommandText = "select * from AddPatient inner join PatientMore on AddPatient.pid=PatientMore.pid";
        //    //cmd.ExecuteNonQuery();
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataSet ds = new DataSet();
        //    da.Fill(ds);
        //    dataGridView2.DataSource = ds.Tables[0];
        //}

        //private void btnAddMoreInfo_Click(object sender, EventArgs e)
        //{
        //    //panel1.Visible = false;
        //   // panel2.Visible = true;
        //}
    }
}
