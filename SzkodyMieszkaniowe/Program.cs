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
                Console.WriteLine("4. Rozpatrywanie wniosku.");
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
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex);
                                }

                                if (pesel.ToString().Length == 9) break;
                                Console.WriteLine("Invalid data, try again. Press \"0\" to exit");
                                var fromConsole = Convert.ToInt32(Console.ReadLine());
                                if (fromConsole == 0)
                                {
                                    break;
                                }
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
                                Console.WriteLine($"Expiry date: {xClient.InsurancePolicy.ExpiryDate}");
                                Console.WriteLine($"Email: {xClient.Email}");
                                Console.WriteLine($"Name: {xClient.Name}");
                                Console.WriteLine($"Surname: {xClient.Surname}");
                                Console.WriteLine($"Address: {xClient.Address}");
                                Console.WriteLine($"Pesel: {xClient.Pesel}");
                                Console.WriteLine($"Funds: {xClient.Funds}");
                                //Console.WriteLine(xClient.Id);
                                if (xClient.Report != null)
                                {
                                    Console.WriteLine($"Treść zgłoszenia: {xClient.Report.Content}");
                                }
                                Console.WriteLine();
                            }
                            break;
                        }
                    case 4:
                    {
                        int pesel = 0;
                        Console.WriteLine("Rozpatrywanie wniosku. \n Podaj PESEL klienta:");
                        while (true)
                        {
                            try
                            {
                                pesel = Int32.Parse(Console.ReadLine());
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                            }

                            if (pesel.ToString().Length == 9) break;
                            Console.WriteLine("Invalid data, try again. Press \"0\" to exit");
                            var fromConsole = Convert.ToInt32(Console.ReadLine());
                            if (fromConsole == 0)
                            {
                                break;
                            }
                        }

                        var clientFromDbByPesel = ClientDbLocal.Get(pesel);
                        try
                        {
                            if (clientFromDbByPesel == null) throw new Exception("Client not exists.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                            break;
                        }
                            Console.WriteLine($"Znaleziono użytkownika: {clientFromDbByPesel.Name} {clientFromDbByPesel.Surname}");
                        Console.WriteLine("Rozpatrz wniosek pozytywnie: \n 1. Tak \n 2. Nie");
                        var decision = Convert.ToInt32(Console.ReadLine());
                        if(decision == 1)
                        {
                            Console.WriteLine("Podaj wysokość odszkodowania: ");
                            var amount = Convert.ToDouble(Console.ReadLine());
                            clientFromDbByPesel.PayCompensation(amount);
                            Console.WriteLine($"Wypłacono użytkowikowi {clientFromDbByPesel.Name} {clientFromDbByPesel.Surname} odszkodowanie w wyskości: {amount}");
                        }
                        else
                        {
                            clientFromDbByPesel.PayCompensation(0);
                            Console.WriteLine("Nie wypłacono odszkodowania.");
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