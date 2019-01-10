using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SzkodyMieszkaniowe.Tests
{
    [TestFixture]
    public class RepositoryTests
    {
        [Test]
        public void repository_should_return_user_by_pesel()
        {
            // arrange
            int pesel = 123456789;
            string name = "Jan";
            var clientDB = new ClientRepository();

            //act
            var clientByPesel = clientDB.Get(pesel);

            //assert
            Assert.NotNull(clientByPesel);
            Assert.AreSame(name, clientByPesel.Name);

        }

        [Test]
        public void repository_should_return_userId_by_email()
        {
            string email = "jankowalski@email.com";
            var clientDB = new ClientRepository();

            var idFromRepository = clientDB.GetIdByEmail(email);
            var clientById = clientDB.Get(idFromRepository);

            Assert.NotNull(clientById);
        }

        [Test]
        public void client_has_been_created_in_Db()
        {
            var id = Guid.NewGuid();
            Client newClient = new Client(id, "newClient@test.com", "Piotr", "Skarga", 456123987, "Krk", new DateTime(2019, 10, 02), Guid.NewGuid());
            var clientDB = new ClientRepository();

            clientDB.Add(newClient);
            var clientFromDb = clientDB.Get(id);

            Assert.AreSame(newClient, clientFromDb);
        }
    }
}
