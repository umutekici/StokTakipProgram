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
    public partial class satis : Form
    {
        List<int> bill = new List<int>();
        List<string> code = new List<string>();
       

         SqlConnection con = new SqlConnection("server=.; Initial Catalog=follow;Integrated Security=SSPI");

        public satis()
        {
            InitializeComponent();
        }

       
        

        private void button2_Click(object sender, EventArgs e)
        {
            giris g = new giris();
            g.Show();
            this.Hide();
        }

        private void satis_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        void hesapla()
        {
            int total = 0;
            foreach (int i in bill)
            {
                total += i;
            }
            textBox3.Text = total.ToString();

           

        }

        void PrintCost()
        {
            
            SqlCommand cmd = new SqlCommand("select * from info where p_code='"+textBox1.Text+"' ",con);
           
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

               

                    //    textBox2.Text = dr["p_cost"].ToString();
                    bill.Add(Convert.ToInt32(dr["p_cost"].ToString()));
                    string textName = dr["p_name"].ToString();
                    string textCost = dr["p_cost"].ToString();
                    listBox1.Items.Add("Product  Name:" + textName);
                    listBox1.Items.Add("Product Cost:" + textCost);
                    listBox1.Items.Add("**************************");
                    code.Add(textBox1.Text);
                    hesapla();
               //     textBox2.Clear();
                    textBox1.Clear();
                    textBox1.Focus();
                
               
            }

            dr.Close();
            con.Close();
            

        }

        void CheckAmount()
        {

            for (int i = 0; i < code.Count; i++)
            {
                SqlCommand komut = new SqlCommand("delete from info where p_code='" + code[i].ToString() + "' ",con);
                con.Open();
                SqlDataReader dr = komut.ExecuteReader();
                con.Close();



            }

        }
        void tb_checkCost(object sender,KeyEventArgs e)  //texte barkod codu okutulduğu anda işlemi yap
        {

            if (e.KeyCode == Keys.Enter)
            {
                PrintCost();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            CheckAmount();
            MessageBox.Show("satın alındı");
            textBox1.Clear();
         //   textBox2.Clear();
            textBox3.Clear();
            textBox1.Focus();

        }

        private void satis_Load(object sender, EventArgs e)
        {
            
        }
    }
}
