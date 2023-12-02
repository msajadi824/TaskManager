using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Application.Dtos
{
    public class UpdateTaskDto
    {
        [Required]
        [Display(Name = "عنوان تسک")]
        public string Title { get; set; }
        [AllowNull]
        [Display(Name = "شرح تسک")]
        public string Description { get; set; }
    }
}
