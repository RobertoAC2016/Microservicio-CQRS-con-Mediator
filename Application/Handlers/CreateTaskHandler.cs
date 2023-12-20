using CQRS_Sample.Application.DTOs;
using CQRS_Sample.Domain;
using CQRS_Sample.Infraestructure;
using CQRS_Sample.Infraestructure.Commands;
using MediatR;

namespace CQRS_Sample.Application.Handlers
{
    public class CreateTaskHandler : IRequestHandler<CreateTask, TaskItemDto>
    {
        private readonly ApplicationDbContext _dbContext;
        public CreateTaskHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<TaskItemDto> Handle(CreateTask request, CancellationToken cancellationToken)
        {
            var task = new TaskItem {
                Title = request.Title,
                Description = request.Description,
            };
            _dbContext.TaskItems.Add(task);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return new TaskItemDto {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                IsCompleted = task.IsCompleted,
            };
        }
    }
}
