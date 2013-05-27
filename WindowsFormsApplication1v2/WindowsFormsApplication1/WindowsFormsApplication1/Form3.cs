using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OracleClient;

namespace WindowsFormsApplication1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text.Count() != 0) && (textBox2.Text.Count() != 0) && (textBox3.Text.Count() != 0) && (textBox4.Text.Count() != 0) && (textBox5.Text.Count() != 0) && (textBox6.Text.Count() != 0))
            {
                long text4 = Convert.ToInt64(textBox3.Text);
                long text5 = Convert.ToInt64(textBox5.Text);

                OracleConnection con = new OracleConnection();
                con.ConnectionString = "User Id=DBA_20122013L_GRP_038;Password=9910620;Data Source=(DESCRIPTION=(ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)))(CONNECT_DATA=(SID=ORCL)))";
                con.Open();                

                OracleCommand putUser = new OracleCommand();
                putUser.Connection = con;
                putUser.CommandText = "INSERT INTO KORISNICI (IME, PREZIME, EMBG, ADRESA_NA_ZIVEENJE, BR_NA_TELEFON, MOZNOST_ZA_POPUST) VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "', " + text4 + ", '" + textBox4.Text + "', " + text5 + ", '" + textBox6.Text + "')";
                putUser.ExecuteNonQuery();

                MessageBox.Show("Корисникот е додаден!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Пополнете ги сите полиња!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
