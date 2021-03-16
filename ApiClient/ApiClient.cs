using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace ApiClient
{
    public class ApiClientBase
    {
        protected static string Get(string searchUrl)
        {
            return new System.Net.Http.HttpClient().GetStringAsync(searchUrl).GetAwaiter().GetResult();
        }
        protected static T Get<T>(string searchUrl)
        {
            var resultJson = Get(searchUrl);
            return JsonSerializer.Deserialize<T>(resultJson);
        }

    }
}
