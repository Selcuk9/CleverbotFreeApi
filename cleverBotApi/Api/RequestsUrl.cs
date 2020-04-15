using System;
using System.Collections.Generic;
using System.Text;

namespace cleverBotApi.Api
{
    public static class RequestsUrl
    {
        public static string BaseUrl { get; } = "https://www.cleverbot.com";
        public static string ChatUrl { get; } = "/webservicemin?uc=UseOfficialCleverbotAPI&";
    }
}
