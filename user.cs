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
    public partial class user : Form
    {
        SqlConnection con = new SqlConnection("server=.; Initial Catalog=follow;Integrated Security=SSPI");

        public user()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "")
                {
                    SqlCommand cmd = new SqlCommand("select * from user where user_name='" + textBox1.Text + "' and password='" + textBox2.Text + "'", con);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {

                        giris g = new giris();
                        g.Show();
                        this.Hide();
                        MessageBox.Show("İşlem başarıyla gerçekleşti.Hoş geldiniz..");
                    }
                }
             else
                    MessageBox.Show("Lütfen boş bırakılan yeri doldurunuz...");

            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);

            }
            con.Close();
            
               






           

        }
    }
}
