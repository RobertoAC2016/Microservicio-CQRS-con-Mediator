using CQRS_Sample.Application.DTOs;
using MediatR;

namespace CQRS_Sample.Infraestructure.Queries
{
    public record GetTaskById(int Id) : IRequest<TaskItemDto>;
}
