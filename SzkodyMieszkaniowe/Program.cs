using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace SzkodyMieszkaniowe
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            bool tmp = true;
            int choice = 0;
            var ClientDbLocal = new ClientRepository();

            while (tmp)
            {
                Console.WriteLine("\n\n|| System obsługi zgłaszania szkód mieszkaniowych ||");
                Console.WriteLine("Wybierz co chcesz zrobić: ");
                Console.WriteLine("1. Dodaj zgłoszenie.");
                Console.WriteLine("2. Pokaż klientów z bazy danych.");
                Console.WriteLine("3. Pokaż klientów.");
                //To do: wypłata pieniedzy
                //To do: rozpatrzenie zgłoszenia (decyzja)
                Console.WriteLine("0. Zakończ");
                choice = Convert.ToInt32(Console.ReadLine());


                switch (choice)
                {
                    case 1:
                        {
                            int pesel = 0;

                            Console.WriteLine("Wprowadzanie danych");

                            Console.WriteLine("Wprowadź PESEL:");
                            while (true)
                            {
                                try
                                {
                                    pesel = Int32.Parse(Console.ReadLine());
                                }
                                catch (Exception ex) { }

                                if (pesel.ToString().Length == 9) break;
                                Console.WriteLine("Invalid data, try again.");
                            }

                            var clientFromDb = ClientDbLocal.Get(pesel);
                            try
                            {
                                if (clientFromDb == null) throw new Exception("Client not exists.");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                                break;
                            }

                            Console.WriteLine("DANE POPRAWNE \nZgłaszanie szkody");
                            Console.WriteLine("Podaj treść zgłoszenia:");
                            var content = Console.ReadLine();
                            ClientDbLocal.AddReport(clientFromDb.Pesel, content);
                            break;

                        }
                    case 2:
                        {
                            Console.WriteLine("Wybierz \"1\", aby pokazać wszystkich klientów.");
                            Console.WriteLine("Wybierz \"2\", aby pokazać klientów z modułu zawierania ubezpieczeń mieszkaniowych.");

                            int choice2 = Convert.ToInt32(Console.ReadLine());
                            var dbCon = new DbConnection();
                            var listDb = dbCon.Select(choice2);
                            foreach (var itemList in listDb)
                            {
                                foreach (var item in itemList)
                                {
                                    Console.Write(item + "\t\t");
                                }

                                Console.WriteLine();
                            }
                            break;
                        }
                    case 3:
                        {
                            foreach (var xClient in ClientDbLocal.Browse())
                            {
                                Console.WriteLine(xClient.InsurancePolicy.ExpiryDate);
                                Console.WriteLine(xClient.Email);
                                Console.WriteLine(xClient.Name);
                                Console.WriteLine(xClient.Surname);
                                Console.WriteLine(xClient.Address);
                                Console.WriteLine(xClient.Pesel);
                                //Console.WriteLine(xClient.Id);
                                if (xClient.Report != null)
                                {
                                    Console.WriteLine(xClient.Report.Content);
                                }
                                Console.WriteLine();
                            }
                            break;
                        }
                    case 0:
                        tmp = false;
                        break;
                }
            }

        }
    }
}