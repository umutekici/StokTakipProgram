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
    public partial class stokCheck : Form
    {
        SqlConnection con = new SqlConnection("server=.; Initial Catalog=follow;Integrated Security=SSPI");
        SqlDataAdapter da;
        DataSet ds;

        public stokCheck()
        {
            InitializeComponent();
        }
        void dataGridFull()
        {
                con = new SqlConnection("server=.; Initial Catalog=follow;Integrated Security=SSPI");
                da = new SqlDataAdapter("Select *From info", con);
                ds = new DataSet();
                con.Open();
                da.Fill(ds, "info");
                dataGridView1.DataSource = ds.Tables["info"];
                con.Close();
            
        }

        private void stokCheck_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void stokCheck_Load(object sender, EventArgs e)
        {
            dataGridFull();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            da = new SqlDataAdapter("select * from info where p_name like '" + textBox1.Text  + "' ",con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "info");
            con.Close();
            dataGridView1.DataSource = ds.Tables["info"];

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }
    }
}
