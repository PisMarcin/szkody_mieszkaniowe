using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IO_modul1
{
    public class Report
    {
        static int RaportCounter = 0;
        int IdRaport; public int IdRaport {  get { return IdRaport; } }
        string Content; public string Content { get { return Content; } }
        string Name; public string Name { get { return Name; } }
        string Surname; public string Surname { get { return Surname; } }
        long Pesel; public long Pesel { get { return Pesel; } }
        string Adress; public string Adres { get { return Adress; } }
        int NoPolisa; public int NoPolisa { get { return NoPolisa; } }


        public Report(string name, string surname, long pesel, string adress, int noPolisa, string content)
        {
            RaportCounter++;
            IdRaport = RaportCounter;
            this.Name = name;
            this.Surname = surname;
            this.Pesel = pesel;
            this.Adress = adress;
            this.NoPolisa = noPolisa;
            this.Content = content;
        }

        public int Verify(Client[] clients)
        {
            for(int i = 0; i < clients.Length; i++)
            {
                if (this.Pesel == clients[i].Pesel)
                {
                    Console.WriteLine("Klient znaleziony na podstawie Peselu. Sprawdzanie pozostałych danych...");
                    if (string.Equals(this.Name, clients[i].Name) &&
                        string.Equals(this.Surname, clients[i].Surname) &&
                        string.Equals(this.Adress, clients[i].Adres) &&
                       this.NoPolisa == clients[i].NoPolisa &&
                       clients[i].getPolisa.czy_wazna())
                    {
                        Console.WriteLine("Dane całkowicie poprawne");
                        Decide();
                        return 1;
                    }
                    else Console.WriteLine("Dane podane w zgloszeniu niezgodne z bazą danych!");
                    return 0;
               
                }
            
            }
            Console.WriteLine("Błędnie wprowadzony Pesel lub klient nieobecny w bazie!");
            return 0;
        }

        public void Decide()
        {
            Console.WriteLine("Rozpatrz pozytywnie (t/n): ");
            if (Console.ReadKey().KeyChar == 't') Pay();
            else Console.WriteLine("Report odrzucone.");
        }

        public void Pay()
        {
            Console.WriteLine("\nJaki typ wyplaty? (1 - czek /2 - gotowka /3 - przelew)");
            if (Convert.ToInt32(System.Console.ReadLine())==1) Console.WriteLine("Wypłata czekiem");
            else if (Convert.ToInt32(System.Console.ReadLine())==2) Console.WriteLine("Wypłata gotówką");
            else Console.WriteLine("Wypłata przelewem");
        }
    

    }
}
