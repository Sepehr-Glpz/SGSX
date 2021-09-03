namespace SGSX.WebResults
{
    public enum ResultState : byte
    {
        Failure = 0,
        Success = 1,
        NotFound = 2,
        BadRequest = 3,
        UnAuthorized = 4,
        Forbidden = 5,
        InternalServerError = 6,
    }
}
