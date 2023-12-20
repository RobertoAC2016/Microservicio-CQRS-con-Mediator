using CQRS_Sample.Application.DTOs;
using CQRS_Sample.Domain;
using CQRS_Sample.Infraestructure;
using CQRS_Sample.Infraestructure.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Sample.Application.Handlers
{
    public class UpdateTaskHandler : IRequestHandler<UpdateTask, TaskItemDto>
    {
        private readonly ApplicationDbContext _dbContext;
        public UpdateTaskHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<TaskItemDto> Handle(UpdateTask request, CancellationToken cancellationToken)
        {
            var task = await _dbContext.TaskItems.FindAsync(new object[] { request.Id }, cancellationToken);
            if (task == null) return null;
            task.Title = request.Title;
            task.Description = request.Description;
            task.IsCompleted = request.IsCompleted;
            _dbContext.TaskItems.Update(task);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return new TaskItemDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                IsCompleted = task.IsCompleted,
            };
        }
    }
}
