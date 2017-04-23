using System;
using System.Text;
using System.Security.Cryptography;
using System.Security;
namespace CCL_Oil_Labs_Control.Utils
{
    public class Utils
    {
        public string hash (String salt , SecureString password)
        {
            var hasher = new SHA256Managed();
            var byteHash = hasher.ComputeHash(new UTF8Encoding().GetBytes(salt + password));
            var hashString = Convert.ToBase64String(byteHash);
            return hashString;
        }
    }
}
