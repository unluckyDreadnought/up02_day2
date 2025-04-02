using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Drawing;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public static class Security
    {
        private static Random rand = new Random();
        private static string en_alp = "qwertyuiopasdfghjklzxcvbnm";
        private static string num = "1234567890";

        public static string HashInput512(string input)
        {
            SHA512 sha5 = SHA512.Create();
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            string output = BitConverter.ToString(sha5.ComputeHash(inputBytes)).Replace("-", "").ToLower();
            return output;
        }

        public static string GenerateCaptchaString(int length)
        {
            string str = "";
            while (str.Length < length)
            {
                int r = rand.Next(5);
                if (r < 2)
                {
                    str += en_alp[rand.Next(num.Length)];
                }
                else
                {
                    str += en_alp[rand.Next(en_alp.Length)];
                }
            }
            return str;
        }

        public static void GenerateCaptchaImage(string text)
        {
            Bitmap bmp = new Bitmap(260, 167);
        }
    }
}
