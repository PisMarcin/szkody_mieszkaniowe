using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzkodyMieszkaniowe
{
    public class ClientRepository : IClientRepository
    {
        public ClientRepository()
        {
            _users = new HashSet<Client>()
            {
                new Client(Guid.NewGuid(), "jankowalski@email.com", "Jan", "Kowalski", 123456789, "Krakow",
                    new DateTime(2020, 5, 1, 8, 30, 52), Guid.NewGuid()),
                new Client(Guid.NewGuid(), "andrzejbrzechwa@email.com", "Andrzej", "Brzechwa", 987456321, "Krakow",
                    new DateTime(2022, 5, 1, 8, 30, 52), Guid.NewGuid()),
                new Client(Guid.NewGuid(), "antonikiepski@email.com", "Antoni", "Kiepski", 987654321, "Krakow",
                    new DateTime(2021, 5, 1, 8, 30, 52), Guid.NewGuid())

            };
        }

        private ISet<Client> _users;

        public IEnumerable<Client> Browse()
            => _users;

        public Guid GetIdByEmail(string email)
            => _users.SingleOrDefault(x => x.Email == email).GetId();
        public Client Get(Guid id)
            => _users.SingleOrDefault(x => x.Id == id);

        public Client Get(int pesel)
            => _users.SingleOrDefault(x => x.Pesel == pesel);

        public void Add(Client client)
        {
            _users.Add(client);
        }

        public void AddReport(int pesel, string content)
        {
            _users.SingleOrDefault(x => x.Pesel == pesel).AddReportToClient(content);
        }

        public void Remove(Guid id)
        {
            var client = Get(id);
            _users.Remove(client);
        }
    }
}
