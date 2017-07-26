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

namespace StokTakip
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("server=.; Initial Catalog=follow;Integrated Security=SSPI");

        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        

         public Form1()
        {
            InitializeComponent();
        }

        void GridFull()
        {
            con = new SqlConnection("server=.; Initial Catalog=follow;Integrated Security=SSPI");
            da = new SqlDataAdapter("Select *From info", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "info");
            dataGridView1.DataSource = ds.Tables["info"];
            con.Close();
        }
        void StockState()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count (*) from info",con);
            textBox1.Text = cmd.ExecuteScalar().ToString();
            con.Close();

        }
       

        private void Form1_Load(object sender, EventArgs e)
        {
            GridFull();
            StockState();

        }

        private void button1_Click(object sender, EventArgs e)
        {
       cmd=new SqlCommand("insert into info(p_name,p_code,p_cost,p_amount,p_date) values(@p_name,@p_code,@p_cost,@p_amount,@p_date)", con);
            cmd.Parameters.AddWithValue("@p_name", txtName.Text);
            cmd.Parameters.AddWithValue("@p_code", txtCode.Text);
            cmd.Parameters.AddWithValue("@p_cost",Convert.ToInt32(txtCost.Text));
            cmd.Parameters.AddWithValue("@p_amount", Convert.ToInt32(txtAmount.Text));
            cmd.Parameters.AddWithValue("@p_date", i_Date.Value.ToString());
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("eklendi");
            GridFull();


         }

        private void Update_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("update info set p_name=@p_name,p_code=@p_code,p_cost=@p_cost,p_amount=@p_amount,p_date=@p_date where no=@no", con);
            cmd.Parameters.AddWithValue("@no", Convert.ToInt32(uNo.Text));
            cmd.Parameters.AddWithValue("@p_name", uName.Text);
            cmd.Parameters.AddWithValue("@p_code", uCode.Text);
            cmd.Parameters.AddWithValue("@p_cost", Convert.ToInt32(uCost.Text));
            cmd.Parameters.AddWithValue("@p_amount", Convert.ToInt32(uAmount.Text));
            cmd.Parameters.AddWithValue("@p_date", u_Date.Value.ToString());
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Güncellendi");
            GridFull();


        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            uNo.Text= dataGridView1.CurrentRow.Cells[0].Value.ToString();
            uName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            uCode.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            uCost.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            uAmount.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            u_Date.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();

        }

        private void Delete_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("delete from info where no=@no",con);
            cmd.Parameters.AddWithValue("@no", Convert.ToInt32(dNo.Text));
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Silindi");
            GridFull();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            giris g = new giris();
            g.Show();
            this.Hide();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            stokCheck check = new stokCheck();
            check.Show();
            this.Hide();
        }
    }
}
