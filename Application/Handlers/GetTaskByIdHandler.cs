using CQRS_Sample.Application.DTOs;
using CQRS_Sample.Infraestructure;
using CQRS_Sample.Infraestructure.Queries;
using MediatR;

namespace CQRS_Sample.Application.Handlers
{
    public class GetTaskByIdHandler : IRequestHandler<GetTaskById, TaskItemDto>
    {
        private readonly ApplicationDbContext _dbContext;
        public GetTaskByIdHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<TaskItemDto> Handle(GetTaskById request, CancellationToken cancellationToken)
        {
            var task = await _dbContext.TaskItems.FindAsync(new object[] { request.Id }, cancellationToken);
            if (task == null) return null;
            return new TaskItemDto {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                IsCompleted = task.IsCompleted,  
            };
        }
    }
}
