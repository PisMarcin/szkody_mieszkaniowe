using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IO_modul1
{
    class Klient
    {
        string imie; public string Imie { get { return imie; } }
        string nazwisko; public string Nazwisko { get { return nazwisko; } }
        long pesel; public long Pesel { get { return pesel; } }
        string adres; public string Adres { get { return adres; } }

        Polisa polisa;
        public Polisa getPolisa { get { return polisa; } }
        public int Numer_Polisy { get { return polisa.Numer_Polisy; } }
        public DateTime Waznosc_Polisy { get { return polisa.Waznosc_Polisy; } }

        public Klient(string Imie, string Nazwisko, long Pesel, string Adres, int Numer_Polisy, DateTime data)
        {
            this.imie = Imie;
            this.nazwisko = Nazwisko;
            this.pesel = Pesel;
            this.adres = Adres;
            this.polisa = new Polisa(Numer_Polisy, data);

        }

    }
}
