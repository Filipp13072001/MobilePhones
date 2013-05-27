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
    public partial class Najava : Form
    {

       
        
        public Najava()
        {
            InitializeComponent();

            Password.PasswordChar = '*';
            
        }
        
        private void Najavabtn_Click(object sender, EventArgs e)
        {
            if ((Username.Text.Count() != 0) && (Password.Text.Count() != 0))
            {
                OracleConnection con = new OracleConnection();
                con.ConnectionString = "User Id=DBA_20122013L_GRP_038;Password=9910620;Data Source=(DESCRIPTION=(ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)))(CONNECT_DATA=(SID=ORCL)))";
                con.Open();

                OracleCommand getUser = new OracleCommand();
                getUser.Connection = con;
                getUser.CommandText = "SELECT * FROM VRABOTENI WHERE LOZINKA = '" + Password.Text + "'";

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
                    string tmpSmena = reader[6].ToString();
                    string tmpLozinka = reader[7].ToString();

                    Vraboteni vraboten = new Vraboteni(tmpID, tmpName, tmpLastName, tmpAdress, tmpPhone, tmpEmbg, tmpSmena, tmpLozinka);
                    Form2 form2 = new Form2(this, vraboten);
                    form2.Show();
                    this.Hide();
                }
                
                con.Close();

                if (ima)
                {
                    MessageBox.Show("Вработениот не постои!");
                }
            }
            else 
            {
                MessageBox.Show("Внесете име и лозинка!");
            }

                        
        }
    }
}