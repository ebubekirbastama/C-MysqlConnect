using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data .MySqlClient ;
using System.Windows.Forms;
namespace Bağlantı_Programı
{
    class Connectiron
    {
        public MySqlConnection baglantı()
        {
            Form1 fb = (Form1)Application.OpenForms["Form1"];
            MySqlConnection con = new MySqlConnection("Server='" + fb.textBox4.Text + "';Database='" + fb.textBox5.Text + "';User='" + fb.textBox1.Text + "';Password='" + fb.textBox2.Text + "'");
            return con;
        }  
    }
}
