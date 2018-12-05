using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IO_modul1
{
    public class Client
    {
        public string Name; public string name { get { return Name; } private set;}
        public string Surname; public string Surname { get { return Surname; } private set; }
        public long Pesel; public long Pesel { get { return Pesel; } private set;}
        public string Adress; public string Adress { get { return Adress; } private set;}

        Polisa polisa;
        public Polisa GetPolisa { get { return polisa; } }
        public int NoPolisa { get { return polisa.NoPolisa; } }
        public DateTime ExpiryDate { get { return polisa.ExpiryDate; } }

        public Klient(string name, string surname, long pesel, string adress, int noPolisa, DateTime date)
        {
            this.Name = name;
            this.Surname = surname;
            this.Pesel = pesel;
            this.Adress = adress;
            this.polisa = new Polisa(noPolisa, date);

        }

    }
}
