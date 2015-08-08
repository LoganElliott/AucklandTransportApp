using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json.Linq;

namespace ApiToAT.HelperClasses
{
    public class Utilities
    {
        internal static IEnumerable<JToken> GetIEnumerableJsonApiResponse(AtApiCredentials atApiCredentials, string parentRequestType, string returnType, string requestName, string requestInput)
        {
            var url = CreateRequestUrl(atApiCredentials,parentRequestType, returnType, requestName, requestInput);
            var json = GetJsonFromUrl(url);
            return json["response"].AsEnumerable();
        }

        private static Uri CreateRequestUrl(AtApiCredentials atApiCredentials, string parentRequestType, string returnType, string requestName, string requestInput)
        {
            var requestUrl = string.Format("{0}/{1}/{2}/{3}/{4}?{5}", atApiCredentials.ApiUrl, parentRequestType, returnType, requestName, requestInput, atApiCredentials.ApiKey);
            return new Uri(requestUrl);
        }

        private static JObject GetJsonFromUrl(Uri url)
        {
            string json;
            using (WebClient wc = new WebClient())
            {
                json = wc.DownloadString(url);
            }

            return JObject.Parse(json);
        }
    }
}
