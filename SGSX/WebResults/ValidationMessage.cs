using System.Collections.Generic;
using System.Linq;
using System;
namespace SGSX.WebResults
{
    public class ValidationMessage : object
    {
        public ValidationMessage() : base()
        {
        }
        public ValidationMessage(string message) : this()
        {
            Message = message;
        }
        public ValidationMessage(Exception exception, string message)
        {
            Exception = exception;
            Message = message;
        }

        public string Message { get; }

        public Exception Exception { get; }

        public static implicit operator ValidationMessage(string value)
        {
            return new ValidationMessage(message: value);
        }
    }
}
