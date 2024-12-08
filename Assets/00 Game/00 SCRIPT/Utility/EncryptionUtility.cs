using System.Security.Cryptography;
using System.Text;

public static class EncryptionUtility
{
    public static string GetMD5Hash(string input)
    {
        if (string.IsNullOrEmpty(input))
            return string.Empty;

        using (MD5 md5 = MD5.Create())
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            foreach (byte b in hashBytes)
            {
                sb.Append(b.ToString("X2")); // Convert to hexadecimal
            }
            return sb.ToString();
        }
    }
}
