using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TelephoneDiarySystem
{
    public partial class Phone : Form
    {
        /// <summary>
        /// must make sure that full instance name is given in Data source field rather than just .
        /// </summary>
        SqlConnection con = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=Phone;Integrated Security=True");
    
        public Phone()
        {
            InitializeComponent();
        }

        private void Phone_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Clear();
            textBox3.Text = "";
            textBox4.Clear();
            comboBox1.SelectedIndex = -1;
            textBox1.Focus();
        }
        /// <summary>
        /// SqlCommand -> insert, update, delete [send]
        /// SqlDataReader -> Select [read]
        /// SqlDataAdapter -> [both send or read] slower 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();  //no need for sqlAdapter
            SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[Mobiles] ([First], [Last], [Mobile], [Email], [Category]) VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + comboBox1.Text + "')", con
            );
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Saved with Git version control...!");
            Display();
        }

        void Display()
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select * from Mobiles", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["First"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item[2].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item[3].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item[4].ToString();

            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();  //no need for sqlAdapter
            SqlCommand cmd = new SqlCommand(@"DELETE FROM Mobiles WHERE (Mobile='"+ textBox3.Text + "')", con
            );
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Delete Successfully...!");
            Display();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();  //no need for sqlAdapter
            SqlCommand cmd = new SqlCommand(@"UPDATE Mobiles
   SET First = '"+textBox1.Text +"', Last = '" +textBox2.Text + "',Mobile = '" +textBox3.Text +"',Email = '"+textBox4.Text+"',Category = '"+comboBox1.Text+"' WHERE (Mobile='" + textBox3.Text + "')", con
            );
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Update Successfully...!");
            Display();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select * from Mobiles Where (Mobile like '%" + textBox5.Text + "%') or (First like '%" + textBox5.Text + "%') or (Last like '%" + textBox5.Text + "%')", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["First"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item[2].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item[3].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item[4].ToString();

            }
        }

        Form2 f2;
        private void form2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f2 == null)
            {
                f2 = new Form2();
                f2.MdiParent = this;
                f2.FormClosed += f2_FormClosed;
                f2.Show();
            }
            else
                f2.Activate();
        }

        void f2_FormClosed(object sender, FormClosedEventArgs e)
        {
            f2 = null;
            
            //throw new NotImplementedException();
        }

        private void form3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f3 = new Form3();
            f3.MdiParent = this;
            f3.Show();
            
        }
    }
}
