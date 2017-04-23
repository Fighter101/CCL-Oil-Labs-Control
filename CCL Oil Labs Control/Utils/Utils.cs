using System;
using System.Text;
using System.Security.Cryptography;
using System.Security;
using System.Runtime.InteropServices;

namespace CCL_Oil_Labs_Control.Utils
{
    public class Utils
    {
        public string hash (String salt , SecureString password)
        {
            IntPtr unsecurePass = Marshal.SecureStringToBSTR(password);
            var hasher = new SHA256Managed();
            var byteHash = hasher.ComputeHash(new UTF8Encoding().GetBytes(salt + Marshal.PtrToStringBSTR(unsecurePass)));
            Marshal.FreeBSTR(unsecurePass);
            var hashString = Convert.ToBase64String(byteHash);
            return hashString;

            
           
        }
    }
}
