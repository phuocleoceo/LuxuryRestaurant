using System.Security.Cryptography;
using System.Text;

namespace Common.Extension
{
    public static class SD
    {
        public const string Role_Admin = "Admin";
        public const string Role_Guest = "Guest";

        public static string GetMD5(this string str)
        {
            MD5 md5 = MD5.Create();
            byte[] fromData = Encoding.ASCII.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < targetData.Length; i++)
            {
                sb.Append(targetData[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
