using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Net;
using System.Text.RegularExpressions;

namespace Bağlantı_Programı
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static void güncelle()
        {
            Form1 fb = (Form1)Application.OpenForms["Form1"];
            Connectiron cn = new Connectiron();
            cn.baglantı();
            MySqlConnection con = cn.baglantı();
            con.Open();
            MySqlDataAdapter adtr = new MySqlDataAdapter("Select * From guvenligiris", con);
            DataTable dt = new DataTable();
            adtr.Fill(dt);
            fb.dataGridView1.DataSource = dt;
            con.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           
            string host = Dns.GetHostName();
            IPHostEntry ip = Dns.GetHostByName(host);
            string ipAdresi = ip.AddressList[0].ToString();
            textBox3.Text  = ipAdresi.ToString ();
            //WebClient wc = new WebClient();
            //string strIP = wc.DownloadString("http://checkip.dyndns.org");
            //strIP = (new Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b")).Match(strIP).Value;
            //wc.Dispose();
            ////strIP//internet  ipsini strIP atadık
            //textBox3.Text = strIP.ToString ();//texBox.tex'e ip atadık.


        }
        private void button1_Click(object sender, EventArgs e)
        {
            Connectiron cn = new Connectiron();
            cn.baglantı();
            MySqlConnection con = cn.baglantı();

            string ip;
            con.Open();
            MySqlCommand kmt = new MySqlCommand("Select * From guvenligiris where id='1'", con);
            MySqlDataReader rdr = kmt.ExecuteReader();

            while (rdr.Read())
            {

                ip = rdr["ip"].ToString();
                textBox6.Text = ip.ToString();

            }
            rdr.Close();
            if (textBox3.Text != textBox6.Text)
            {
                MySqlCommand kmt1 = new MySqlCommand("update guvenligiris set ip ='" + textBox3.Text + "' ", con);
                kmt1.ExecuteNonQuery();
                con.Close();
                güncelle();

            }
            else
            {
                MessageBox.Show("İp Adresiniz En Güncel Hali'dir", "Ebubekir Yazılım");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                Point Koordinatlar;
                Koordinatlar = Control.MousePosition;
                Koordinatlar.Offset(-tıkla.X, -tıkla.Y);
                this.Location = Koordinatlar;
            }
        }
        Point tıkla;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            tıkla = new Point(e.X, e.Y);
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            tıkla = new Point(e.X, e.Y);
        }

        private void dataGridView1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                Point Koordinatlar;
                Koordinatlar = Control.MousePosition;
                Koordinatlar.Offset(-tıkla.X, -tıkla.Y);
                this.Location = Koordinatlar;
            }
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void gösterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void gizleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                güncelle();
            }
            catch 
            {
                MessageBox.Show("Bağlantı Başarısız","Ebubekir Yazılım");  
               
            }
         
            
        }
    }
}