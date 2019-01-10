using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SzkodyMieszkaniowe
{
    public class Client// : ClientRepository
    {
        private static readonly Regex NameRegex = new Regex("^(?![_.-])(?!.*[_.-]{2})[a-zA-Z0-9._.-]+(?<![_.-])$");
        public Guid Id { get; } 
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public int Pesel { get; private set; }
        public string Email { get; private set; }
        public string Address { get; private set; }
        public double Funds { get; set; }
        public InsurancePolicy InsurancePolicy { get; private set; }
        public Report Report { get; private set; }

        public DateTime CreateAt { get; protected set; }

        public Client()
        {

        }
        public Client(Guid userId, string email, string name, string surname, int pesel, string address, DateTime expiryDate, Guid idPolicy)
        {
            var insurance = new InsurancePolicy(idPolicy, expiryDate);
            Id = userId;
            Pesel = pesel;
            Address = address;
            InsurancePolicy = insurance;
            SetEmail(email);
            SetName(name);
            SetSurname(surname);
            Funds = 0.0;
            CreateAt = DateTime.UtcNow;
        }

        public void PayCompensation(double funds)
        {
            Funds += funds;
        }

        public void AddInsurancePolicy(InsurancePolicy insurancePolicy)
        {
            InsurancePolicy = insurancePolicy;
        }

        public void SetPesel(int pesel)
        {
            if (pesel.ToString().Length == 9) Pesel = pesel;
            else throw new Exception("Please provide valid data. Pesel either too short or too long.");
        }
        public Guid GetId()
        {
            return Id;
        }

        public void AddReportToClient(string content)
        {
            var report = new Report(Guid.NewGuid(), content);
            this.Report = report;
        }
        public void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email.ToLowerInvariant()))
            {
                throw new Exception("Please provide valid data. There is a null or white space. ");
            }
            else if (Email == email)
            {
                return;
            }

            Email = email;
        }

        public void SetName(string name)
        {
            if (!NameRegex.IsMatch(name))
            {
                throw new Exception("Username is invalid.");
            }
            else if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Please provide valid data. There is a null or white space. ");
            }
            else if (Name == name)
            {
                return;
            }

            Name = name;
        }

        public void SetSurname(string surname)
        {
            if (string.IsNullOrWhiteSpace(surname))
            {
                throw new Exception("Please provide valid data. There is a null or white space. ");
            }
            else if (Surname == surname)
            {
                return;
            }
            Surname = surname;

        }
    }
}