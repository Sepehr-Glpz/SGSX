using SGSX.Results.Interfaces;
namespace SGSX.Mediator
{
    public interface IRequest : MediatR.IRequest<IResult>
    {

    }

    public interface IRequest<TValue> : MediatR.IRequest<IResult<TValue>>
    {

    }
}
