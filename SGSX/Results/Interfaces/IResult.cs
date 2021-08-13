namespace SGSX.Results.Interfaces
{
    public interface IResult
    {
        bool IsSuccess { get; }
        bool IsFailure { get; }
        System.Collections.Generic.IReadOnlyList<string> Errors { get; }
        System.Collections.Generic.IReadOnlyList<string> Successes { get; }
        IResult WithErrorMessage(string error);
        IResult WithErrorMessage(System.Collections.Generic.IEnumerable<string> errors);
        IResult WithSuccessMessage(string success);
        IResult WithSuccessMessage(System.Collections.Generic.IEnumerable<string> successes);
        void Success();
        void Failed();
        IResult CopyResult();
        IResult<T> ToValueResult<T>(T value);
    }

    public interface IResult<T> : IResult
    {
        T Value { get; }
        IResult<T> WithValue(T value);
    }

}
