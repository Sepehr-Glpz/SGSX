namespace SGSX.Mediator
{
    public interface IRequest : MediatR.IRequest<Results.Result>
    {

    }

    public interface IRequest<TValue> : MediatR.IRequest<Results.Result<TValue>>
    {

    }
}
