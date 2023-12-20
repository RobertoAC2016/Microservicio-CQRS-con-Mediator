using CQRS_Sample.Application.DTOs;
using MediatR;

namespace CQRS_Sample.Infraestructure.Commands
{
    public record CreateTask(String Title, String Description) : IRequest<TaskItemDto>;
}
