using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;

namespace withings.net.Client
{
    public partial class WithingsClient
    {
        public async Task<T> ExecutePostAsync<T>(string uri, Dictionary<string, string> headers = null, Dictionary<string, string> paramaters = null)
        {
            try
            {
                var client = new RestClient(uri);
                RestRequest request = new RestRequest() { Method = Method.POST };

                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                request.AddHeader("Accept", "application/json");

                if (headers != null)
                    request.AddParamaters(headers, ParameterType.HttpHeader);

                if (paramaters != null)
                    request.AddParamaters(paramaters, ParameterType.QueryString);

                var resp = await client.ExecuteAsync(request);

                return JsonConvert.DeserializeObject<T>(resp.Content);
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        public async Task<T> ExecuteGetAsync<T>(string endpoint, Dictionary<string, string> headers = null, Dictionary<string, string> paramaters = null)
        {
            try
            {
                var request = new RestRequest(endpoint) { Method = Method.GET };
                if (!string.IsNullOrWhiteSpace(_authorization_response?.AccessToken))
                    request.AddHeader("Authorization", $"Bearer {_authorization_response.AccessToken}");

                if (headers != null)
                    request.AddHeaders(headers);

                if (paramaters != null)
                    request.AddParamaters(paramaters, ParameterType.QueryString);

                var resp = await ExecuteAsync(request);

                return JsonConvert.DeserializeObject<T>(resp.Content);
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        public Task<T> ExecuteGetAsync<T>(string endpoint, Dictionary<string, string> paramaters) =>
            ExecuteGetAsync<T>(endpoint, null, paramaters);


    }

    public static class RestUtilities
    {
        public static void AddParamaters(this RestRequest request, IDictionary<string, string> paramaters, ParameterType parameterType)
        {
            foreach (var kvp in paramaters)
            {
                request.AddOrUpdateParameter(kvp.Key, kvp.Value, parameterType);
            }
        }

        public static Dictionary<string, string> ToNullableParamaters(this Dictionary<string, object> paramaters)
        {
            var dictionary = new Dictionary<string, string>();
            foreach (var kvp in paramaters.Where(kvp => kvp.Value != null).Select(kvp => kvp))
            {
                dictionary.Add(kvp.Key, kvp.Value.ToString());
            }

            return dictionary;
        }

    }
}
