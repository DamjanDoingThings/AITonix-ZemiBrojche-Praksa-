using ZemiBrojce.Models;

namespace ZemiBrojce.Services
{
    public class UserService : IUserService
    {
        private readonly Praksa_ZemiBrojContext _db;

        public UserService(Praksa_ZemiBrojContext db)
        {
            _db = db;
        }

        //Fuction where workers can change seating positions

        public User ChangeNumber(int userId,int salterId)
        {
            var user = _db.Users.FirstOrDefault(x => x.Id == userId);

            var userOldSalterId = user!.SalterId;

            user.SalterId = salterId;

            var userS = _db.Users.FirstOrDefault(x => x.Id == salterId);

            if (userS is not null)
            {
                userS.SalterId = userOldSalterId;
                _db.Users.Update(userS);    
            }
            _db.Users.Update(user);
            _db.SaveChanges();
            return user;
        }

        public List<User> GetAllUsers()
        {
            return  _db.Users.ToList();
          
        }

        public User GetUser(int userId)
        {
            var user = _db.Users.FirstOrDefault(x => x.Id == userId);
            return user;

        }

    }
}
