using TiendaIna.Core.Entities;

namespace TiendaIna.Infrastructure.DataStore {
    public interface IInMemoryClientsStore : IList<Client> { }

    public class InMemoryClientsStore : List<Client>, IInMemoryClientsStore
    {
        public InMemoryClientsStore() {
            Clear();
            AddRange([
              new Client {
                Id = 1,
               Name = "Gustavo Cachiporra",
               Email = "gustavochichi12@gmail.com",
               IdentificationNumber= "33852624"

              },
              new Client {
                Id = 2,
               Name = "Rebeca Angelico",
               Email = "Reberebe@gmail.com",
               IdentificationNumber= "44252624"
              },
              new Client {
                Id = 3,
               Name = "Diego Farias",
               Email = "diegote21@gmail.com",
               IdentificationNumber= "47255024"
              },
              new Client {
                Id = 4,
               Name = "Rocio Farina",
               Email = "rocioloquita254@gail.com",
               IdentificationNumber= "17852624"
              }
        ]);
        }
    }
}