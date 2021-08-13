namespace SGSX.Mediator
{
    public interface IRequest : MediatR.IRequest<FluentResults.Result>
    {

    }

    public interface IRequest<TValue> : MediatR.IRequest<FluentResults.Result<TValue>>
    {

    }
}
