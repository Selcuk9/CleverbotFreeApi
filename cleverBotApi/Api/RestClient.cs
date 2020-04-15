using cleverBotApi.Api.Message;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace cleverBotApi.Api
{
    public class RestClient
    {
        public HttpVerb HttpMethod { get; set; }
        public Language LanguageBot { get; set; } = Language.en;
        private string message = "";
        List<string> messages;

        public RestClient(){}
        public RestClient(Language language = Language.en)
        {
            LanguageBot = language;
        }


        public async Task<string> SendMessage(string currentMessage)
        {
            string language = LanguageBot.ToString();
            string result = "";
            messages = new List<string>();
            message = currentMessage + "." + message;
            if (language == "ru")
            {
                currentMessage = EncodingMessage.GetRusEncode(currentMessage);
            }
            result = await SendRequest(message, language);
            messages.Add(currentMessage);
            messages.Add(result);
            message = "";
            for (int i = 0; i < messages.Count; i++)
            {
                message = $"&vText{messages.Count + 1 - i}={messages[i]}{message}";
            }
            return result;
        }
        //public string SendMessageAsync()
        //{
        //}

        private async Task<string> SendRequest(string message, string language)
        {
            HttpClient client = new HttpClient();
            var content = HashMessage.GetContent(message, language);
            content.Headers.Add("Cookie", "XVIS=TEI939AFFIAGAYQZ");
            var response = await client.PostAsync(RequestsUrl.BaseUrl + RequestsUrl.ChatUrl, content);
            var responseBody = await response.Content.ReadAsStringAsync();
            int endAnswerIndex = responseBody.IndexOf("\r");
            var answerBot = responseBody.Substring(0, endAnswerIndex);
            return answerBot;
        }
    }
}
