using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ADMCrawlHelper
{
    public class BaseHelper
    {
        private static CrawlException ex;

        private string _url { get; set; }
        private string _token { get; set; }

        public BaseHelper(string url, string token)
        {
            this._url = url;
            this._token = token;
        }

        private Token GetAsscessToken()
        {
            var client = new RestClient(_url);
            var request = new RestRequest(Definition.REQUEST_CRAWL_TOKEN, Method.POST);

            request.AddHeader("content-type", "application/json");
            request.AddJsonBody(new
            {
                Token = _token
            });

            var response = client.Execute(request);

            return JsonConvert.DeserializeObject<Token>(response.Content);
        }

        public T SendRequest<T>(string route, Method method, object body, List<Parameter> parameters)
        {
            for (int i = 0; i < 2; i++)
            {
                var client = new RestClient(_url);
                var request = new RestRequest(route, method);
                var token = GetAsscessToken();

                parameters?.ForEach(p =>
                {
                    request.AddParameter(p);
                });

                if (body != null)
                {
                    request.AddJsonBody(body);
                }

                request.AddHeader("content-type", "application/json");

                request.AddHeader("Authorization", "Bearer " + token.AccessToken);

                var response = client.Execute(request);
                var data = JsonConvert.DeserializeObject<T>(response.Content);

                bool unauthorized = response.StatusCode == HttpStatusCode.Unauthorized;

                if (unauthorized)
                {
                    GetAsscessToken();
                    continue;
                }

                if (response.ErrorException != null)
                {
                    ex = JsonConvert.DeserializeObject<CrawlException>(response.Content);

                    if (ex.Message != null)
                    {
                        throw new Exception(ex.Message);
                    }
                    else
                    {
                        throw new Exception(response.StatusDescription);
                    }
                }

                return data;
            }
            return default;
        }
    }

    partial class CrawlException
    {
        public string Message { get; set; }

        public override string ToString()
        {
            return ($"{Message}");
        }
    }
}
