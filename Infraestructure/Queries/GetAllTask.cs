using CQRS_Sample.Application.DTOs;
using MediatR;

namespace CQRS_Sample.Infraestructure.Queries
{
    public record GetAllTask : IRequest<IEnumerable<TaskItemDto>>;
}
