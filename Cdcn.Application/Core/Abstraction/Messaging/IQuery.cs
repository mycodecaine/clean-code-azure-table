using MediatR;
namespace Cdcn.Application.Core.Abstraction.Messaging
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}
