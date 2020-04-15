using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace cleverBotApi.Api.Message
{
    /// <summary>
    /// Класс где можно прописать различные кодировки для каждого языка
    /// Для анлийского языка не требуется кодировка
    /// </summary>

    public class EncodingMessage
    {
        /// <summary>
        /// RUS Language
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string GetRusEncode(string text)
        {
            string octal = null;
            string[] mass = new string[text.Length];
            for (int i = 0; i < text.Length; i++)
            {
                mass[i] = text.Substring(i, 1);
                long charNumber = Convert.ToChar(mass[i]);
                if (charNumber != 32)
                {
                    octal += "|0" + Convert.ToString(charNumber, 16).ToUpper();
                }
                else
                {
                    octal += " ";
                }
            }
            var urlText = HttpUtility.UrlEncode(octal).ToUpper().Replace("+", "%20");
            return urlText;
        }
    }
}
