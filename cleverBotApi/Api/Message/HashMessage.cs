using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace cleverBotApi.Api.Message
{
    public class HashMessage
    {
        /// <summary>
        /// 1)На сервера проверка "anti-api" и приходится Хешировать сообщения
        /// 2)Если текст является русским то кодируем EncodeURL 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public static HttpContent GetContent(string text, string language)
        {
            
            if (language.ToLower() == "ru")
            {
                text = EncodingMessage.GetRusEncode(text);
            }
            string input = $"stimulus={text}.&cb_settings_language={language}&cb_settings_scripting=no&islearning=1&icognoid=wsf&icognocheck=";
            string hash;
            using (MD5 md5Hash = MD5.Create())
            {
                var source = GetInputHash(input);
                hash = GetMd5Hash(md5Hash, source);
            }
            HttpContent content = new StringContent($"stimulus={text}.&cb_settings_language={language}&cb_settings_scripting=no&islearning=1&icognoid=wsf&icognocheck={hash}");
            return content;
        }

        /// <summary>
        /// Генерация хеш-код для обхода запрета
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static string GetInputHash(string input)
        {
            return input.Substring(7, 26);
        }
        /// <summary>
        /// Метод Хеширование
        /// </summary>
        /// <param name="md5Hash"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        private static string GetMd5Hash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}
