using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CCL_Oil_Labs_Control.Controller
{
    public static class UserController
    {
        public static void RegisterUser(Model.User admin, string username, string password, string auth)
        {
            if (admin.AuthorizationLevel != "Admin")
                throw new Exception("This User is not an Admin");
            var model = new Model.DatabaseEntities();
            if (model.Users.Any(u => u.Username == username))
                throw new Exception("Username Exits");

            var salt = RandomString(50);
            var hashString = Hash(password, salt);
            var userData = new Model.User(){
                AuthorizationLevel = auth,
                HashedString = hashString,
                Salt = salt,
                Username = username         
            };

            model.Users.Add(userData);
        }

        public static bool Login(string username, string password)
        {
            using (var model = new Model.DatabaseEntities())
            {
                var userList = from b in model.Users
                           where b.Username == username
                           select b;
                var user = userList.First();
                if (user == null)
                    throw new Exception("User doesn't exist");
                return Hash(password, user.Salt) == user.HashedString ? true : false;
                    
            }
        }
        private static string Hash(string password, string salt)
        {
            var hasher = new SHA256Managed();
            var byteHash = hasher.ComputeHash(new UTF8Encoding().GetBytes(salt + password));
            var hashString = Convert.ToBase64String(byteHash);
            return hashString;
        }
        private static string RandomString(int size)
        {
            var random = new Random();
            string input = "abcdefghijklmnopqrstuvwxyz0123456789";
            var chars = Enumerable.Range(0, size).Select(x => input[random.Next(0, input.Length)]);
            return new string(chars.ToArray());
        }

    }
}
