using MediatR;

namespace CQRS_Sample.Infraestructure.Commands
{
    public record DeleteTask(int Id) : IRequest<Boolean>;
}
