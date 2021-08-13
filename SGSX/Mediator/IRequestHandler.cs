namespace SGSX.Mediator
{
    public interface IRequestHandler<in TCommand> : MediatR.IRequestHandler<TCommand,FluentResults.Result> where TCommand : IRequest
    {

    }

    public interface IRequestHandler<in TCommand, TReturn> : MediatR.IRequestHandler<TCommand,FluentResults.Result<TReturn>> where TCommand : IRequest<TReturn>
    {

    }
}
