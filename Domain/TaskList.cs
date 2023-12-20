namespace CQRS_Sample.Domain
{
    public class TaskItem
    {
        public int Id { get; set; }
        public String? Title { get; set; }
        public String? Description { get; set; }
        public Boolean IsCompleted { get; set;}
    }
}
