using System;
using System.Collections.Generic;
using System.Text;

namespace cleverBotApi.Api
{
    public enum HttpVerb
    {
        GET,
        POST,
        PUT,
        DELETE
    }

    /// <summary>
    /// Настройки бота (язык)
    /// </summary>
    public enum Language
    {
        ru,
        en
     //.....//
    }
    /// <summary>
    /// Настройки запроса (метод запроса)
    /// </summary>
    public class SettingsBot
    {
        public HttpVerb HttpMethod { get; set; }
    }
}
