using SGSX.Results.Interfaces;
namespace SGSX.Mediator
{
    public interface IRequestHandler<in TCommand> : MediatR.IRequestHandler<TCommand,IResult> where TCommand : IRequest
    {

    }

    public interface IRequestHandler<in TCommand, TReturn> : MediatR.IRequestHandler<TCommand,IResult<TReturn>> where TCommand : IRequest<TReturn>
    {

    }
}
