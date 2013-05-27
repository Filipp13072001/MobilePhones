using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class Vraboteni
    {
        public string id { set; get; }
        public string name { set; get; }
        public string lastName { set; get; }
        public string address { set; get; }
        public string phone { set; get; }
        public string EMBG { set; get; }
        public string smena { set; get; }
        public string lozinka { set; get; }

        public Vraboteni(string nId, string nName, string nLastName, string nAddress, string nPhone, string nEMBG, string nSmena, string nLozinka) 
        {
            id = nId;
            name = nName;
            lastName = nLastName;
            address = nAddress;
            phone = nPhone;
            EMBG = nEMBG;
            smena = nSmena;
            lozinka = nLozinka;
        }

        public override string ToString()
        {
            return name + " " + lastName;
        }
    }
}
