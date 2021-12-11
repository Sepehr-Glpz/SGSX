using System.Net.Http;
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

        public static WebResult<T> CreateWebResult<T>(this HttpResponseMessage response,string bodyValuePath)
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
                var path = bodyValuePath.Split(':');
            }
            else
            {

            }
            return result;
        }



    }
}
