using ZemiBrojce.Models;

namespace ZemiBrojce.Services
{
    public interface IUserService
    {
        public User ChangeNumber(int userId,int salterId);
        public List<User> GetAllUsers();

        public User GetUser(int userId);
    }
}
