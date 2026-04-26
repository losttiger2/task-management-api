using FluentValidation;
using TaskManagement.Application.DTOs;

namespace TaskManagement.Application.Validators
{
    public class TaskCreateValidator : AbstractValidator<TaskCreateDTO>
    {
        public TaskCreateValidator() 
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required")
                .MaximumLength(100);

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required");
        }
    }
}
