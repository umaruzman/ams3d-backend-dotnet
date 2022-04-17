using ARMSBackend.DTOs;
using ARMSBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARMSBackend.Repository
{
    public class UserRepository : IUsersRepository
    {

        private AppContext _context;

        public UserRepository(AppContext context)
        {
            this._context = context;
        }

        public User AddUser(UserDTO user)
        {
            User newUser = new User()
            {
                Name = user.Name,
                Password = user.Password
            };

            this._context.Users.Add(newUser);
            this._context.SaveChanges();

            return newUser;
        }

        public List<User> AllUsers()
        {
            List<User> users = _context.Users.ToList();

            return users;
        }

        public User GetUser(int userid)
        {
            User user = _context.Users.Find(userid);
            return user;
        }
    }
}
