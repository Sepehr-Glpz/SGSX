using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
namespace SGSX.WebResults
{
    public class WebResult : object
    {
        public WebResult() : base()
        {
            _validationMessages = new List<ValidationMessage>();
        }
        public WebResult(short? statusCode) : this()
        {
            StatusCode = statusCode;
        }
        public WebResult(params ValidationMessage[] validationMessages) : this()
        {
            _validationMessages.AddRange(validationMessages);
        }
        public WebResult(IEnumerable<ValidationMessage> validationMessages) : this()
        {
            _validationMessages.AddRange(validationMessages);
        }
        public WebResult(params string[] validationMessages) : this()
        {
            _validationMessages.AddRange(validationMessages.Select(s => new ValidationMessage(s)));
        }
        public WebResult(IEnumerable<string> validationMessages) : this()
        {
            _validationMessages.AddRange(validationMessages.Select(s => new ValidationMessage(s)));
        }
        public WebResult(short? statusCode, IEnumerable<ValidationMessage> validationMessages) : this(validationMessages)
        {
            StatusCode = statusCode;
        }
        public WebResult(short? statusCode, IEnumerable<string> validationMessages) : this(validationMessages)
        {
            StatusCode = statusCode;
        }
        private short? _statusCode;
        public short? StatusCode { get => _statusCode; set => DecideStatusCode(value); }

        public string StatusCodeName { get; protected set; }

        private void DecideStatusCode(short? code)
        {
            _statusCode = code;
            if (code is null || code.HasValue == false)
            {
                return;
            }
            StatusCodeName = StatusCodes.StatusCodesDictionary.GetValueOrDefault(code.Value);
        }

        public bool IsSuccessfulStatusCode
        {
            get
            {
                if (StatusCode is null)
                {
                    return false;
                }
                return (StatusCode < 400);
            }
        }

        public WebResult<T> ToValueResult<T>(T value)
        {
            return new WebResult<T>(value, StatusCode, _validationMessages);
        }
        
        private readonly List<ValidationMessage> _validationMessages;
        public ReadOnlyCollection<ValidationMessage> ValidationMessages { get => _validationMessages.AsReadOnly(); }

        public virtual WebResult WithValidationMessage(ValidationMessage validationMessage)
        {
            _validationMessages.Add(validationMessage);
            return this;
        }
        public virtual WebResult WithValidationMessage(string message)
        {
            _validationMessages.Add(message);
            return this;
        }
        public virtual WebResult WithValidationMessage(IEnumerable<ValidationMessage> validationMessages)
        {
            _validationMessages.AddRange(validationMessages);
            return this;
        }
        public virtual WebResult WithValidationMessage(IEnumerable<string> validationMessages)
        {
            _validationMessages.AddRange(validationMessages.Select(s => new ValidationMessage(s)));
            return this;
        }
        public virtual WebResult WithStatusCode(short statusCode)
        {
            StatusCode = statusCode;
            return this;
        }

        public static bool operator ==(WebResult left, bool right)
        {
            return (left?.IsSuccessfulStatusCode == right);
        }
        public static bool operator !=(WebResult left,bool right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj is null)
            {
                return false;
            }

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            var stringBuilder = new System.Text.StringBuilder();
            stringBuilder.Append("Result Status:")
                .Append(StatusCode.ToString())
                .Append(' ')
                .AppendLine(StatusCodeName)
                .AppendLine("Messages:");
            foreach(var message in ValidationMessages)
            {
                stringBuilder.AppendLine(message.Message);
            }
            return stringBuilder.ToString();
        }

    }
}
