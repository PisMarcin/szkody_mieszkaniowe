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
            string tmpName, tmpName, tmpAdress, tmpContent;
            int tmpPolisa;
            long tmpPesel;
            DateTime date1 = new DateTime(2008, 5, 1, 8, 30, 52);
            DateTime date2 = new DateTime(2020, 5, 1, 8, 30, 52);
            DateTime date3 = new DateTime(2021, 5, 1, 8, 30, 52);
            Klient[] tab = new Klient[3];
            tab[0] = new Klient("Klaudia", "wrona", 97060706209, "bochenka", 1, date2);
            tab[1] = new Klient("Miłka", "ciszek", 950125, "wrzasowice", 2, date2);
            tab[2] = new Klient("Misia", "wielgos", 20150921, "raciborsko", 3, date3);

            while (true)
            {

                System.Console.WriteLine("\n\nNOWE report");
                System.Console.WriteLine("Wprowadz: ");
                System.Console.WriteLine("Imie: "); tmpName = System.Console.ReadLine();
                System.Console.WriteLine("Nazwisko: "); tmpName = System.Console.ReadLine();
                System.Console.WriteLine("Pesel: "); tmpPesel = Convert.ToInt64(System.Console.ReadLine());
                System.Console.WriteLine("Adres: "); tmpAdress = System.Console.ReadLine();
                System.Console.WriteLine("Numer polisy: "); tmpPolisa = Convert.ToInt32(System.Console.ReadLine());
                System.Console.WriteLine("Tresc zgloszenia: "); tmpContent = System.Console.ReadLine();
                Report report = new Report(tmpName, tmpName, tmpPesel, tmpAdress, tmpPolisa, tmpContent);
                report.Verify(tab);
                
            }
            Console.ReadLine();
            
        }
    }
}