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
    public partial class Form2 : Form
    {
        Form3 form3 = new Form3();
        Form oppener;
       
        
        public Form2(Form parrentForm, Vraboteni vraboten)
        {
            InitializeComponent();

            oppener = parrentForm;

            Ime.Text = vraboten.name;
            Prezime.Text = vraboten.lastName;
            Adresa.Text = vraboten.address;
            EMBG.Text = vraboten.EMBG;
            Br_tel.Text = vraboten.phone;
            textBox6.Text = vraboten.smena;

            
            
        }

        private void Ime_korisnik_TextChanged(object sender, EventArgs e)
        {

        }

        private void Prezime_korisnik_TextChanged(object sender, EventArgs e)
        {

        }

        private void Delovi_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            form3.Show();


        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((Ime_korisnik.Text.Count() != 0) && (Prezime_korisnik.Text.Count() != 0))
            {
                OracleConnection con = new OracleConnection();
                con.ConnectionString = "User Id=DBA_20122013L_GRP_038;Password=9910620;Data Source=(DESCRIPTION=(ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)))(CONNECT_DATA=(SID=ORCL)))";
                con.Open();

                OracleCommand getUser = new OracleCommand();
                getUser.Connection = con;
                getUser.CommandText = "SELECT * FROM KORISNICI WHERE IME = '" + Ime_korisnik.Text + "' AND PREZIME = '" + Prezime_korisnik.Text + "'";
                
                OracleDataReader reader = getUser.ExecuteReader();

                bool ima = true;
                while (reader.Read()) 
                {
                    ima = false;
                    string tmpID = reader[0].ToString();
                    string tmpName = reader[1].ToString();
                    string tmpLastName = reader[2].ToString();
                    string tmpAdress = reader[3].ToString();
                    string tmpPhone = reader[4].ToString();
                    string tmpEmbg = reader[5].ToString();
                    string tmpPopust = reader[6].ToString();

                    Korisnici korisnik = new Korisnici(tmpID, tmpName, tmpLastName, tmpAdress, tmpPhone, tmpEmbg, tmpPopust);

                    textBox3.Text = korisnik.EMBG;
                    textBox4.Text = korisnik.address;
                    textBox5.Text = korisnik.phone;
                    textBox7.Text = korisnik.popust;
                }

                con.Close();

                if (ima)
                {
                    MessageBox.Show("Корисникот не постои!");
                }
            }
            else 
            {
                MessageBox.Show("Внесете име и презиме!");
            }
        }

       

        
    }
}
