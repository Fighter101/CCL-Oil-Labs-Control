using System;
using System.Text;
using System.Security.Cryptography;
using System.Security;
using System.Runtime.InteropServices;
using System.Linq;

namespace CCL_Oil_Labs_Control.Utils
{
    public class Utils
    {
        public static string hash (String salt , SecureString password)
        {
            IntPtr unsecurePass = Marshal.SecureStringToBSTR(password);
            var hasher = new SHA256Managed();
            var byteHash = hasher.ComputeHash(new UTF8Encoding().GetBytes(salt + Marshal.PtrToStringBSTR(unsecurePass)));
            Marshal.FreeBSTR(unsecurePass);
            var hashString = Convert.ToBase64String(byteHash);
            return hashString;
        }

        public static string RandomString(int size)
        {
            var random = new Random();
            string input = "abcdefghijklmnopqrstuvwxyz0123456789";
            var chars = Enumerable.Range(0, size).Select(x => input[random.Next(0, input.Length)]);
            return new string(chars.ToArray());
        }
        public static bool SecureStringEqual(SecureString secureString1, SecureString secureString2)
        {
            if (secureString1 == null)
            {
                throw new ArgumentNullException("s1");
            }
            if (secureString2 == null)
            {
                throw new ArgumentNullException("s2");
            }

            if (secureString1.Length != secureString2.Length)
            {
                return false;
            }

            IntPtr ss_bstr1_ptr = IntPtr.Zero;
            IntPtr ss_bstr2_ptr = IntPtr.Zero;

            try
            {
                ss_bstr1_ptr = Marshal.SecureStringToBSTR(secureString1);
                ss_bstr2_ptr = Marshal.SecureStringToBSTR(secureString2);

                String str1 = Marshal.PtrToStringBSTR(ss_bstr1_ptr);
                String str2 = Marshal.PtrToStringBSTR(ss_bstr2_ptr);

                return str1.Equals(str2);
            }
            finally
            {
                if (ss_bstr1_ptr != IntPtr.Zero)
                {
                    Marshal.ZeroFreeBSTR(ss_bstr1_ptr);
                }

                if (ss_bstr2_ptr != IntPtr.Zero)
                {
                    Marshal.ZeroFreeBSTR(ss_bstr2_ptr);
                }
            }
        }
    }
}
