using CQRS_Sample.Application.DTOs;
using CQRS_Sample.Infraestructure;
using CQRS_Sample.Infraestructure.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Sample.Application.Handlers
{
    public class GetAllTaskHandler : IRequestHandler<GetAllTask, IEnumerable<TaskItemDto>>
    {
        private readonly ApplicationDbContext _dbContext;
        public GetAllTaskHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<TaskItemDto>> Handle(GetAllTask request, CancellationToken cancellationToken)
        {
            var tasks = await _dbContext.TaskItems.ToListAsync(cancellationToken);
            return tasks.Select(task => new TaskItemDto {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                IsCompleted = task.IsCompleted,
            });
        }
    }
}
