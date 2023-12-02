using Application.Dtos;
using Domain.Enums;
using Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class CreateTaskValidator : AbstractValidator<CreateTaskDto>
    {
        public CreateTaskValidator()
        {
            RuleFor(TaskModel => TaskModel.Title).NotEmpty().WithMessage("عنوان نمی‌تواند خالی باشد");
        }
    }
}
