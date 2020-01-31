using System.Threading.Tasks;
using datingapp.API.Models;

namespace datingapp.API.Data
{
    public interface IAuthRepository
    {
        //perdorimi i dabazes per rejgistrim logim dhe verifikim (INTERFACE)
         Task<User> Register(User user, string passowrd);
         Task<User> Login(string username, string passowrd);
         Task<bool> UserExists(string username); 

    }
}