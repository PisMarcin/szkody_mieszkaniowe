using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IO_modul1
{
    class Program
    {
        static void Main(string[] args)
        {
            string tempImie, tempNazw, tempAdres, tempTresc;
            int tempNrPolisy;
            long tempPesel;
            DateTime date1 = new DateTime(2008, 5, 1, 8, 30, 52);
            DateTime date2 = new DateTime(2020, 5, 1, 8, 30, 52);
            DateTime date3 = new DateTime(2021, 5, 1, 8, 30, 52);
            Klient[] tab = new Klient[3];
            tab[0] = new Klient("Klaudia", "wrona", 97060706209, "bochenka", 1, date2);
            tab[1] = new Klient("Miłka", "ciszek", 950125, "wrzasowice", 2, date2);
            tab[2] = new Klient("Misia", "wielgos", 20150921, "raciborsko", 3, date3);

            while (true)
            {
                System.Console.WriteLine("Nowe zgloszenie? t/n");
                if (System.Console.ReadKey().KeyChar == 'n') break;
                else
                {
                    System.Console.WriteLine("\n\nNOWE ZGLOSZENIE");
                    System.Console.WriteLine("Wprowadz: ");
                    System.Console.WriteLine("Imie: "); tempImie = System.Console.ReadLine();
                    System.Console.WriteLine("Nazwisko: "); tempNazw = System.Console.ReadLine();
                    System.Console.WriteLine("Pesel: "); tempPesel = Convert.ToInt64(System.Console.ReadLine());
                    System.Console.WriteLine("Adres: "); tempAdres = System.Console.ReadLine();
                    System.Console.WriteLine("Numer polisy: "); tempNrPolisy = Convert.ToInt32(System.Console.ReadLine());
                    System.Console.WriteLine("Tresc zgloszenia: "); tempTresc = System.Console.ReadLine();
                    Zgloszenie zgloszenie = new Zgloszenie(tempImie, tempNazw, tempPesel, tempAdres, tempNrPolisy, tempTresc);
                    zgloszenie.sprawdz_poprawnosc(tab);
                }


            }
            Console.ReadLine();
            
        }
    }
}
