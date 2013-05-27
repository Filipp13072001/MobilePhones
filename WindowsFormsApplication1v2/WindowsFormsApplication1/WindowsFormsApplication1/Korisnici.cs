using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class Korisnici
    {
        public string id { set; get; }
        public string name { set; get; }
        public string lastName { set; get; }
        public string address { set; get; }
        public string phone { set; get; }
        public string EMBG { set; get; }
        public string popust { set; get; }

        public Korisnici(string nID, string nName, string nLastName, string nAdress, string nPhone, string nEMBG, string nPopust)
        {
            id = nID;
            name = nName;
            lastName = nLastName;
            address = nAdress;
            phone = nPhone;
            EMBG = nEMBG;
            popust = nPopust;
        }
    }
}
