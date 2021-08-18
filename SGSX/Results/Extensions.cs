namespace SGSX.Results
{
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public static class Extensions
    {
        public static Interfaces.IResult<T> ToResult<T>(this T value)
        {
            var result = new Result<T>(value);
            return result;
        }
    }
}
