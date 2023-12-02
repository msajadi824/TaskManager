using Domain.Enums;

namespace Application.Dtos
{
    public class GetTaskDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskStatusEnum Status { get; set; }
    }
}
