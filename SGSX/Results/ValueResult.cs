using SGSX.Results.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SGSX.Results
{
    public sealed class Result<T> : Result, IResult<T>
    {
        public Result() : base()
        {
        }

        public Result(T value) : base()
        {
            Value = value;
        }

        public Result(T value,bool isSucces,params string[] messages) : base(isSucces,messages)
        {
            Value = value;
        }


        public T Value { get; private set; }

        public override IResult<T> WithErrorMessage(string error)
        {
            if (string.IsNullOrEmpty(error) == true)
            {
                throw new ArgumentNullException(nameof(error), "The error message value cannot be null or empty!");
            }
            if (IsSuccess == true)
            {
                throw new InvalidOperationException("Cannot add Error message to successfull result!");
            }
            else
            {
                Errors = AddAndNew(error, Errors);
            }
            return this;
        }
        public override IResult<T> WithErrorMessage(IEnumerable<string> errors)
        {
            if (errors is null || errors?.Any() == false)
            {
                throw new ArgumentNullException(nameof(errors), "The error list cannot be null or contain no elements!");
            }
            if (IsSuccess == true)
            {
                throw new InvalidOperationException("Cannot add Error messages to successfull result!");
            }
            else
            {
                Errors = AddAndNew(errors, Errors);
            }
            return this;
        }

        public override IResult<T> WithSuccessMessage(string success)
        {
            if (string.IsNullOrEmpty(success) == true)
            {
                throw new ArgumentNullException(nameof(success), "The success message value cannot be null or empty!");
            }
            if (IsFailure == true)
            {
                throw new InvalidOperationException("Cannot add Success message to Failed result!");
            }
            else
            {
                Successes = AddAndNew(success, Successes);
            }
            return this;
        }

        public override IResult<T> WithSuccessMessage(IEnumerable<string> successes)
        {
            if (successes is null || successes?.Any() == false)
            {
                throw new ArgumentNullException(nameof(successes), "The success list cannot be null or contain no elements!");
            }
            if (IsFailure == true)
            {
                throw new InvalidOperationException("Cannot add Success messages to failed result!");
            }
            else
            {
                Successes = AddAndNew(successes, Successes);
            }
            return this;
        }

        public override IResult<T> CopyResult()
        {
            var newResult = new Result<T>();
            if (IsFailure == true)
            {
                newResult.IsFailure = true;
                if (Errors is not null && Errors.Any() == true)
                {
                    newResult.Errors = Errors;
                }
                return newResult;
            }
            else if (IsSuccess == true)
            {
                newResult.IsSuccess = true;
                if (Successes is not null && Successes.Any() == true)
                {
                    newResult.Successes = Successes;
                }
                return newResult;
            }
            return newResult;
        }

        public IResult<T> WithValue(T value)
        {
            Value = value;
            return this;
        }

        public override IResult<U> ToValueResult<U>(U value)
        {
            IResult<U> result = new Result<U>(value);
            if (IsFailure == true && IsSuccess == false)
            {
                result.Failed();
                if (Errors.Any() == true)
                {
                    result.WithErrorMessage(Errors);
                }
                return result;
            }
            if (IsSuccess == true && IsFailure == false)
            {
                result.Success();
                if (Successes.Any() == true)
                {
                    result.WithSuccessMessage(Successes);
                }
                return result;
            }
            return result;
        }

        public IResult ToResult()
        {
            IResult result = new Result();
            if (IsFailure == true && IsSuccess == false)
            {
                result.Failed();
                if (Errors.Any() == true)
                {
                    result.WithErrorMessage(Errors);
                }
                return result;
            }
            if (IsSuccess == true && IsFailure == false)
            {
                result.Success();
                if (Successes.Any() == true)
                {
                    result.WithSuccessMessage(Successes);
                }
                return result;
            }
            return result;
        }

    }
}
