using System.Collections.Generic;
using System.Threading.Tasks;
using datingapp.API.Models;

namespace datingapp.API.Data
{
    public interface IDatingRepository
    {
        void Add<T> (T entity) where T: class;
        void Delete<T> (T entity) where T: class;
        Task<bool> SaveALL();
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int id);
         
    }
}