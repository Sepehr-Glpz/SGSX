using SGSX.Results.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SGSX.Results
{
    public class Result : IResult
    {
        //Ctors
        #region Constructors
        public Result()
        {
            Initializer();
            IsSuccess = false;
            IsFailure = false;
        }
        public Result(bool success, params string[] messages)
        {
            Initializer();
            if (success == false)
            {
                IsSuccess = false;
                IsFailure = true;
                if (messages is null || messages.Any(current => string.IsNullOrEmpty(current)))
                {
                    throw new System.ArgumentNullException(nameof(messages), "The error message value cannot be null or empty!");
                }
                Errors = AddAndNew(messages, Errors);
            }
            else
            {
                IsSuccess = true;
                IsFailure = false;
                if (messages is null || messages.Any(current => string.IsNullOrEmpty(current)))
                {
                    throw new System.ArgumentNullException(nameof(messages), "The success message value cannot be null or empty!");
                }
                Successes = AddAndNew(messages, Successes);
            }
        }
        protected void Initializer()
        {
            Errors = new List<string>().AsReadOnly();
            Successes = new List<string>().AsReadOnly();
        }
        #endregion /Constructors

        public bool IsSuccess { get; protected set; }

        public bool IsFailure { get; protected set; }

        public IReadOnlyList<string> Errors { get; protected set; }

        public IReadOnlyList<string> Successes { get; protected set; }

        public void Failed()
        {
            IsSuccess = false;
            IsFailure = true;
        }

        public void Success()
        {
            IsSuccess = true;
            IsFailure = false;
        }

        public virtual IResult<T> ToValueResult<T>(T value)
        {
            var valueResult = new Result<T>(value);
            if (IsFailure == true)
            {
                valueResult.Failed();
                if (Errors.Any() == true)
                {
                    valueResult.WithErrorMessage(Errors);
                }
                return valueResult;
            }
            if (IsSuccess == true)
            {
                valueResult.Success();
                if (Successes.Any() == true)
                {
                    valueResult.WithSuccessMessage(Successes);
                }
                return valueResult;
            }
            return valueResult;
        }

        public virtual IResult WithErrorMessage(string error)
        {
            if (string.IsNullOrEmpty(error) == true)
            {
                throw new System.ArgumentNullException(nameof(error), "The error message value cannot be null or empty!");
            }
            if (IsSuccess == true)
            {
                throw new System.InvalidOperationException("Cannot add Error message to successfull result!");
            }
            else
            {
                Errors = AddAndNew(error, Errors);
            }
            return this;
        }

        public virtual IResult WithErrorMessage(IEnumerable<string> errors)
        {
            if (errors is null || errors?.Any() == false)
            {
                throw new System.ArgumentNullException(nameof(errors), "The error list cannot be null or contain no elements!");
            }
            if (IsSuccess == true)
            {
                throw new System.InvalidOperationException("Cannot add Error messages to successfull result!");
            }
            else
            {
                Errors = AddAndNew(errors, Errors);
            }
            return this;
        }

        public virtual IResult WithSuccessMessage(string success)
        {
            if (string.IsNullOrEmpty(success) == true)
            {
                throw new System.ArgumentNullException(nameof(success), "The success message value cannot be null or empty!");
            }
            if (IsFailure == true)
            {
                throw new System.InvalidOperationException("Cannot add Success message to Failed result!");
            }
            else
            {
                Successes = AddAndNew(success, Successes);
            }
            return this;
        }

        public virtual IResult WithSuccessMessage(IEnumerable<string> successes)
        {
            if (successes is null || successes?.Any() == false)
            {
                throw new System.ArgumentNullException(nameof(successes), "The success list cannot be null or contain no elements!");
            }
            if (IsFailure == true)
            {
                throw new System.InvalidOperationException("Cannot add Success messages to failed result!");
            }
            else
            {
                Successes = AddAndNew(successes, Successes);
            }
            return this;
        }

        public virtual IResult CopyResult()
        {
            var newResult = new Result();
            if (IsFailure == true)
            {
                newResult.IsFailure = true;
                if (Errors.Any() == true)
                {
                    newResult.WithErrorMessage(Errors);
                }
                return newResult;
            }
            else if (IsSuccess == true)
            {
                newResult.IsSuccess = true;
                if (Successes.Any() == true)
                {
                    newResult.WithSuccessMessage(Successes);
                }
                return newResult;
            }
            return newResult;
        }

        protected IReadOnlyList<string> AddAndNew(string message, IReadOnlyList<string> list)
        {
            var currentList = list.ToList();
            currentList.Add(message);
            return currentList.AsReadOnly();
        }
        protected IReadOnlyList<string> AddAndNew(IEnumerable<string> messages, IReadOnlyList<string> list)
        {
            var currentList = list.ToList();
            currentList.AddRange(currentList);
            return currentList.AsReadOnly();
        }

    }
}
