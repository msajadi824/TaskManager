using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Application.Dtos
{
    public class GetTaskDto
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "عنوان تسک")]
        public string Title { get; set; }
        [Display(Name = "شرح تسک")]
        public string Description { get; set; }
        [Display(Name = "وضعیت تسک")]
        public TaskStatusEnum Status { get; set; }
    }
}
