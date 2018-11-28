using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IO_modul1
{
    class Zgloszenie
    {
        static int licznik_zgloszen = 0;
        int numer_zgloszenia; public int Numer_Zgloszenia {  get { return numer_zgloszenia; } }
        string tresc_zgloszenia; public string Tresc_Zgloszenia { get { return tresc_zgloszenia; } }
        string imie; public string Imie { get { return imie; } }
        string nazwisko; public string Nazwisko { get { return nazwisko; } }
        long pesel; public long Pesel { get { return pesel; } }
        string adres; public string Adres { get { return adres; } }
        int numer_polisy; public int Numer_Polisy { get { return numer_polisy; } }


        public Zgloszenie(string Imie, string Nazwisko, long Pesel, string Adres, int Numer_Polisy,
            string Tresc_Zgloszenia)
        {
            licznik_zgloszen++;
            numer_zgloszenia = licznik_zgloszen;
            this.imie = Imie;
            this.nazwisko = Nazwisko;
            this.pesel = Pesel;
            this.adres = Adres;
            this.numer_polisy = Numer_Polisy;
            this.tresc_zgloszenia = Tresc_Zgloszenia;
        }

        public int sprawdz_poprawnosc(Klient[] klienci)
        {
            for(int i = 0; i < klienci.Length; i++)
            {
                if (this.pesel == klienci[i].Pesel)
                {
                    Console.WriteLine("Klient znaleziony na podstawie peselu. Sprawdzanie pozostałych danych...");
                    if (string.Equals(this.imie, klienci[i].Imie) &&
                        string.Equals(this.nazwisko, klienci[i].Nazwisko) &&
                        string.Equals(this.adres, klienci[i].Adres) &&
                       this.numer_polisy == klienci[i].Numer_Polisy &&
                       klienci[i].getPolisa.czy_wazna())
                    {
                        Console.WriteLine("Dane całkowicie poprawne");
                        rozpatrz();
                        return 1;
                    }
                    else Console.WriteLine("Dane podane w zgloszeniu niezgodne z bazą danych!");
                    return 0;
               
                }
            
            }
            Console.WriteLine("Błędnie wprowadzony pesel lub klient nieobecny w bazie!");
            return 0;
        }

        public void rozpatrz()
        {
            Console.WriteLine("Rozpatrz pozytywnie (t/n): ");
            if (Console.ReadKey().KeyChar == 't') wyplata();
            else Console.WriteLine("Zgloszenie odrzucone.");
        }

        public void wyplata()
        {
            Console.WriteLine("\nJaki typ wyplaty? (1 - czek /2 - gotowka /3 - przelew)");
            if (Convert.ToInt32(System.Console.ReadLine())==1) Console.WriteLine("Wypłata czekiem");
            else if (Convert.ToInt32(System.Console.ReadLine())==2) Console.WriteLine("Wypłata gotówką");
            else Console.WriteLine("Wypłata przelewem");
        }
    

    }
}
