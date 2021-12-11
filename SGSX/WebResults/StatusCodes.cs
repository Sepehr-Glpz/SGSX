using System.Collections.Generic;
using System.Linq;
using System.Collections.Immutable;
namespace SGSX.WebResults
{
    public static partial class StatusCodes
    {
        public const short Ok = 200;

        public const short Created = 201;

        public const short Accepted = 202;

        public const short Non_Authoritative_Information = 203;

        public const short No_Content = 204;

        public const short Reset_Content = 205;

        public const short Partial_Content = 206;

        public const short Bad_Request = 400;

        public const short Unauthorized = 401;

        public const short Forbidden = 403;

        public const short Not_Found = 404;

        public const short Method_Not_Allowed = 405;

        public const short Not_Acceptable = 406;

        public const short Proxy_Authentication_Required = 407;

        public const short Request_Timeout = 408;

        public const short Conflict = 409;

        public const short Gone = 410;

        public const short Length_Required = 411;

        public const short Precondition_Failed = 412;

        public const short Payload_Too_Large= 413;

        public const short URI_Too_Long = 414;

        public const short Unsupported_Media_Type = 415;

        public const short Range_Not_Satisfiable = 416;

        public const short Expectation_Failed = 417;

        public const short Im_a_teapot = 418;

        public const short Too_Early = 425;

        public const short Upgrade_Required = 426;

        public const short Precondition_Required = 428;

        public const short Too_Many_Requests = 429;

        public const short Request_Header_Fields_Too_Large = 431;

        public const short Unavailable_For_Legal_Reasons = 451;

        public const short Internal_Server_Error = 500;

        public const short Not_Implemented = 501;

        public const short Bad_Gateway = 502;

        public const short Service_Unavailable = 503;

        public const short Gateway_Timeout = 504;

        public const short HTTP_Version_Not_Supported = 505;

        public const short Variant_Also_Negotiates = 506;

        public const short Not_Extended = 510;

        public const short Network_Authentication_Required = 511;

        private static object _syncRoot = new object();
        private static ImmutableDictionary<short, string> _statusCodes;
        public static ImmutableDictionary<short, string> StatusCodes
        {
            get
            {
                lock(_syncRoot)
                {

                }


                return _statusCodes;
            }
        }



        //private static Dictionary<short, string> _statusCodes;
        public static Dictionary<short,string> StatusCodesDictionary
        {
            get
            {
                if (_statusCodes is null)
                {
                    var fields =
                        typeof(StatusCodes).GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);

                    var statuses = fields.Where(current => current.IsLiteral)
                    .Select(x => new { Value = (short)x.GetRawConstantValue(), Name = x.Name }).ToList();

                    _statusCodes = new Dictionary<short, string>();
                    foreach(var item in statuses)
                    {
                        _statusCodes.Add(item.Value, item.Name.Replace('_',' '));
                    }
                }
                return _statusCodes;
            }
        }
    }
}
