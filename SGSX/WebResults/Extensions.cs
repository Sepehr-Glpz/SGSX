using System.Net.Http;
using System.Text.Json;
namespace SGSX.WebResults
{
    public static class Extensions
    {
        public static WebResult<T> ToResult<T>(this T value)
        {
            return new WebResult<T>(value);
        }

        public static WebResult CreateWebResult(this HttpResponseMessage response)
        {
            if(response is null)
            {
                return null;
            }


        }

        public static WebResult<T> CreateWebResult<T>(this HttpResponseMessage response,string bodyValuePath = null,JsonSerializerOptions jsonSerializerOptions = null)
        {
            if(response is null)
            {
                return null;
            }
            if(response.IsSuccessStatusCode == false)
            {
                
            }
            WebResult<T> result = null;
            if(string.IsNullOrWhiteSpace(bodyValuePath) == false)
            {
                using var body = response.Content.ReadAsStream();
                using var json = JsonDocument.Parse(body);
                var path = bodyValuePath.Split(':');
                
            }
            else
            {

            }
            return result;
        }

        private static JsonElement GetJsonElementSection(JsonElement jsonElement,string property)
        {
            if(jsonElement.ValueKind == JsonValueKind.Null)
            {
                return default(JsonElement);
            }
        }

    }
}
