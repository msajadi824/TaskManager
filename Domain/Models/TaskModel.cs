using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [AllowNull]
        public string? Description { get; set; }
        [EnumDataType(typeof(Enums.TaskStatusEnum))]
        public Enums.TaskStatusEnum Status { get; set; } = Enums.TaskStatusEnum.Pending;
    }
}