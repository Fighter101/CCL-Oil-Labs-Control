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
        public User (String userName , SecureString password )
        {
            this.Username = userName;
            this.password = password;
        }

        public bool login()
        {
            DatabaseEntities.clearEntity<User>();
            var model = DatabaseEntities.Initiate();
            var userList = from user in model.Users
                           where user.Username == this.Username
                           select user;
            var currentuser = userList.FirstOrDefault();
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
            var userListWithHash = from user in model.Users
                                   where (user.Username == this.Username && user.HashedString == this.HashedString)
                                   select user;
            User currentUser = userListWithHash?.FirstOrDefault();
            return currentUser != null;
        }
        public bool Register()
        {
            DatabaseEntities.clearEntity<User>();
            var model = DatabaseEntities.Initiate();
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
        public static IList<string> getuserNames()
        {
            DatabaseEntities.clearEntity<User>();
            List<string> userNames;
            var model = DatabaseEntities.Initiate();
                var names = from user in model.Users
                            select user.Username;
                userNames = names.ToList();
            return userNames;

        }
    }
}
