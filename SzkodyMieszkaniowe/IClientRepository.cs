using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzkodyMieszkaniowe
{
    interface IClientRepository
    {
        IEnumerable<Client> Browse();
        Client Get(Guid id);
        //Client Get(InsurancePolicy policy);
        Client Get(int pesel);

        void Add(Client client);
        void Remove(Guid id);

    }
}
