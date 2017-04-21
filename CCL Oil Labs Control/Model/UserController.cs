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
        private Utils.Utils hashingUtil = new Utils.Utils();
        public User (String userName , SecureString password )
        {
            using (var model = new Model.DatabaseEntities())
            {
                var userList = from user in model.Users
                               where user.Username == userName
                               select user;
                var currentuser = userList.First();
                if (currentuser == null)
                {
                    throw new WrongUserNameException("User Name is wrong");
                }
                else
                {
                    this.Salt = currentuser.Salt;
                    this.HashedString = hashingUtil.hash(this.Salt, password);
                }
            }
        }

        public bool login()
        {
            using (var model = new Model.DatabaseEntities())
            {
                var userList = from user in model.Users
                               where user.Username == this.Username && user.HashedString == this.HashedString
                               select user;
                var currentUser = userList.First();
                return currentUser == null;
            }
        }
    }
}
