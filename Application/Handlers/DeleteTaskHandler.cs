using CQRS_Sample.Application.DTOs;
using CQRS_Sample.Infraestructure;
using CQRS_Sample.Infraestructure.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Sample.Application.Handlers
{
    public class DeleteTaskHandler : IRequestHandler<DeleteTask, Boolean>
    {
        private readonly ApplicationDbContext _dbContext;
        public DeleteTaskHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Handle(DeleteTask request, CancellationToken cancellationToken)
        {
            var task = await _dbContext.TaskItems.FindAsync(new object[] { request.Id }, cancellationToken);
            if (task == null) return false;
            _dbContext.TaskItems.Remove(task);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
