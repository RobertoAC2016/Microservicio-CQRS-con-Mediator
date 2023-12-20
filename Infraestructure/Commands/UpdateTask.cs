using CQRS_Sample.Application.DTOs;
using MediatR;

namespace CQRS_Sample.Infraestructure.Commands
{
    public record UpdateTask(int Id, String Title, String Description, Boolean IsCompleted)
        : IRequest<TaskItemDto>;
}
