using System.Text;

namespace ModernWebStore.SharedKernel.Helpers
{
    public class StringHelper
    {
        public static string Encrypt(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return "";
            }

            value += "|7a2b562f-7276-4b76-8747-ee0e0606aed9";
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create(value);
            byte[] data = md5.ComputeHash(System.Text.Encoding.Default.GetBytes(value));

            StringBuilder sbString = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sbString.Append(data[i].ToString("x2"));               
            }
            return sbString.ToString();
        }
    }
}
