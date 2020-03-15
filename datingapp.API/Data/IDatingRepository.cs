using System.Collections.Generic;
using System.Threading.Tasks;
using datingapp.API.Helpers;
using datingapp.API.Models;

namespace datingapp.API.Data
{
    public interface IDatingRepository
    {
        void Add<T> (T entity) where T: class;
        void Delete<T> (T entity) where T: class; 
        Task<bool> SaveALL(); 
        Task<PagedList<User>> GetUsers(UserParams userParams);
        Task<User> GetUser(int id);

        Task<Photo> GetPhoto(int id);
        Task<Photo> GetMainPhotoForUser(int userId);
        Task<Like> GetLike(int userId, int recipientId);
         
    }
}