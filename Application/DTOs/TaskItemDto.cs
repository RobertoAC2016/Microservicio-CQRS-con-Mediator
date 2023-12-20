using CQRS_Sample.Domain;

namespace CQRS_Sample.Application.DTOs
{
    public class TaskItemDto : TaskItem
    {
        public DateTime Creation { get; set; } = DateTime.Now;
    }
}
