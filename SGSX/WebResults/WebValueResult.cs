using System.Collections.Generic;
namespace SGSX.WebResults
{
    public class WebResult<T> : WebResult
    {
        //Class constructors
        #region Constructors
        public WebResult() : base()
        {
        }
        public WebResult(T value) : this()
        {
            Value = value;
        }
        public WebResult(short statusCode) : base(statusCode)
        {
        }
        public WebResult(params ValidationMessage[] validationMessages) : base(validationMessages)
        {
        }
        public WebResult(IEnumerable<ValidationMessage> validationMessages) : base(validationMessages)
        {
        }
        public WebResult(params string[] validationMessages) : base(validationMessages)
        {
        }
        public WebResult(IEnumerable<string> validationMessages) : base(validationMessages)
        {
        }
        public WebResult(short statusCode, IEnumerable<ValidationMessage> validationMessages) : base(statusCode, validationMessages)
        {
        }
        public WebResult(short statusCode, IEnumerable<string> validationMessages) : base(statusCode, validationMessages)
        {
        }
        public WebResult(T value, short? statusCode, IEnumerable<ValidationMessage> validationMessages) : base(statusCode,validationMessages)
        {
            Value = value;
        }
        #endregion /Constructors

        public T Value { get; private set; }

        public bool IsDefaultValue { get => Value.Equals(default(T)); }

        public WebResult ToResult()
        {
            return new WebResult(StatusCode, ValidationMessages);
        }

        public WebResult<T> WithValue(T value)
        {
            Value = value;
            return this;
        }

        public override sealed WebResult<T> WithStatusCode(short statusCode)
        {
            StatusCode = statusCode;
            return this;
        }

        public override sealed WebResult<T> WithValidationMessage(ValidationMessage validationMessage)
        {
            base.WithValidationMessage(validationMessage);
            return this;
        }

        public override sealed WebResult<T> WithValidationMessage(string message)
        {
            base.WithValidationMessage(message);
            return this;
        }

        public override sealed WebResult<T> WithValidationMessage(IEnumerable<string> validationMessages)
        {
            base.WithValidationMessage(validationMessages);
            return this;
        }

        public override sealed WebResult<T> WithValidationMessage(IEnumerable<ValidationMessage> validationMessages)
        {
            base.WithValidationMessage(validationMessages);
            return this;
        }

        public override string ToString()
        {
            var stringBuilder = new System.Text.StringBuilder();
            stringBuilder.Append("Value:")
                .AppendLine(Value.ToString())
                .Append("Result Status:")
                .Append(StatusCode.ToString())
                .Append(' ')
                .AppendLine(StatusCodeName)
                .AppendLine("Messages:");
            foreach (var message in ValidationMessages)
            {
                stringBuilder.AppendLine(message.Message);
            }
            return stringBuilder.ToString();
        }
    }
}
