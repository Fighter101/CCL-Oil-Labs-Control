using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using CCL_Oil_Labs_Control.Utils;
using CCL_Oil_Labs_Control.Exceptions;

namespace CCL_Oil_Labs_Control.Model
{
    public partial class User
    {
        public User() { }
        private SecureString password;
        public bool state;
        public User (String userName , SecureString _password )
        {
            this.Username = userName;
            password = _password;
        }

        public bool login()
        {
            using (var model = new Model.DatabaseEntities())
            {
                var userList = from user in model.Users
                               where user.Username == this.Username
                               select user;
                var currentuser = userList.First();
                if (currentuser == null)
                {
                    return false;
                }
                else
                {
                    this.Salt = currentuser.Salt;
                    this.HashedString = Utils.Utils.hash(this.Salt, password);
                    this.AuthorizationLevel = currentuser.AuthorizationLevel;
                }
            }
            using (var model = new DatabaseEntities())
            {
                var userList = from user in model.Users
                               where (user.Username == this.Username && user.HashedString == this.HashedString)
                               select user;
                User currentUser = userList?.FirstOrDefault();
                return currentUser != null;
            }
        }
        public bool Register()
        {
            var model = new DatabaseEntities();
            if (model.Users.Any(u => u.Username == this.Username))
                return false;

            var salt = Utils.Utils.RandomString(10);
            var hashString = Utils.Utils.hash(salt, this.password);
            var userData = new Model.User()
            {
                AuthorizationLevel = "User",
                HashedString = hashString,
                Salt = salt,
                Username = this.Username
            };

            model.Users.Add(userData);
            model.SaveChanges();
            return true;
        }
        
    }
}
