using System.Threading.Tasks;
using datingapp.API.Models;

namespace datingapp.API.Data
{
    public interface IAuthRepository
    {
        //perdorimi i dabazes per rejgistrim logim dhe verifikim (INTERFACE)
         Task<User> Register(User user, string password);
         Task<User> Login(string username, string password);
         Task<bool> UserExists(string username); 

    }
}