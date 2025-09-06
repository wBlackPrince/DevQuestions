using FluentValidation;
using Questions.Contracts.Dto;

namespace Questions.Application.Features.AddAnswerCommand;

public partial class AddAnswerValidator: AbstractValidator<AddAnswerDto>
{
    public AddAnswerValidator()
    {
        this.RuleFor(x => x.Text)
            .NotEmpty().WithMessage("Текст не может быть пустым")
            .MaximumLength(5000).WithMessage("Текст не валиден");
    }
}