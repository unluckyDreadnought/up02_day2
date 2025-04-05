using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Drawing;
using System.Windows.Forms;

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
                    str += en_alp[rand.Next(en_alp.Length)];
                }
                else
                {
                    str += num[rand.Next(num.Length)];
                }
            }
            return str;
        }

        public static Bitmap GenerateCaptchaImage(string text)
        {
            Bitmap bmp = new Bitmap(260, 167);
            Color[] bgcolors = new Color[] { Color.LightGray, Color.WhiteSmoke, Color.AliceBlue, Color.Azure, Color.AntiqueWhite };
            Color[] lineColors = new Color[] { Color.DarkSeaGreen, Color.DarkSlateBlue, Color.DarkTurquoise, Color.DeepPink, Color.SteelBlue };
            Color[] textColors = new Color[] { Color.Black, Color.Navy, Color.PaleTurquoise, Color.Indigo, Color.IndianRed, Color.Green, Color.SaddleBrown, Color.Purple, Color.PeachPuff };
            FontStyle[] fontStyles = new FontStyle[] { FontStyle.Bold, FontStyle.Italic, FontStyle.Regular  };
            PointF lastTPoint = new PointF();
            int placedSymbols = 0;
            using (Graphics grhx = Graphics.FromImage(bmp))
            {
                grhx.Clear(bgcolors[rand.Next(bgcolors.Length)]);
                int lineCount = 0;
                while (lineCount < 10)
                {
                    using (Pen p = new Pen(lineColors[rand.Next(lineColors.Length)], (float)(rand.NextDouble() * rand.Next(5,20))))
                    {
                        Point[] points = new Point[2];
                        int w = rand.Next(bmp.Width);
                        int h = rand.Next(bmp.Height);
                        points[0] = new Point(w, h);
                        w = rand.Next(bmp.Width);
                        h = rand.Next(bmp.Height);
                        points[1] = new Point(w, h);
                        grhx.DrawLine(p, points[0], points[1]);
                        if (rand.Next(15) > 7 && placedSymbols < text.Length)
                        {
                            PointF textPoint = new PointF();
                            while (textPoint.X <= lastTPoint.X)
                            {
                                int max = bmp.Width / (text.Length - placedSymbols);
                                textPoint.X = rand.Next(Convert.ToInt32(lastTPoint.X), max);
                                textPoint.Y = rand.Next(Convert.ToInt32(bmp.Height*0.35), Convert.ToInt32(bmp.Height*0.6));
                            }
                            Font font = new Font(FontFamily.GenericSansSerif, rand.Next(20, 40), fontStyles[rand.Next(fontStyles.Length)]);
                            grhx.DrawString(text[placedSymbols].ToString(), font, new SolidBrush(textColors[rand.Next(textColors.Length)]), textPoint);
                            lastTPoint = textPoint;
                            placedSymbols++;
                        }
                    }
                    lineCount++;
                }
            }

            return bmp;
        }

        public static string GetSnp(string fullName)
        {
            string[] parts = fullName.Trim().Split(' ');
            int pIndx = 1;
            while (pIndx < parts.Length)
            {
                parts[pIndx] = $"{parts[pIndx][0]}.";
                pIndx++;
            }
            return string.Join(" ", parts);
        }

        public static string HidePhoneData(string phoneNumber)
        {
            string hidden = $"+{phoneNumber[0]}";
            hidden += " ... ";
            int numIndx = 7;
            while (numIndx < phoneNumber.Length)
            {
                if (numIndx % 2 != 0 && numIndx != phoneNumber.Length - 1)
                {
                    hidden += '-';
                }
                hidden += phoneNumber[numIndx];
                numIndx++;
            }
            return hidden;
        }

        public static void LogOut()
        {
            Form[] forms = Application.OpenForms.Cast<Form>().ToArray();
            foreach (Form f in forms)
            {
                if (f is AuthorizeForm) continue;
                f.Close();
            }
            Form author = forms.Where(f => f is AuthorizeForm).ToArray()[0];
            author.Visible = true;
            if (Actionless.LastForm != null) {; }
            else {; }
        }
    }
}
