using System.Collections.Generic;
using System.Linq;
namespace SGSX.WebResults
{
    public class ValidationMessage : object
    {
        public ValidationMessage() : base()
        {
            _messages = new List<string>();
        }

        public ValidationMessage(string message) : base()
        {
            Message = message;
        }

        private List<string> _messages;
        public string Message { get => string.Join(System.Environment.NewLine,_messages); set => _messages.Add(value); }

        private short? _statusCode;
        public short? StatusCode { get => _statusCode; set => DecideStatusCode(value); }

        public string StatusCodeName { get; protected set; }

        private void DecideStatusCode(short? code)
        {
            _statusCode = code;
            if (code is null)
            {
                return;
            }
            StatusCodeName = StatusCodes.StatusCodesDictionary.Where(current => current.Key == code.Value).FirstOrDefault().Value;
        }
    }
}
