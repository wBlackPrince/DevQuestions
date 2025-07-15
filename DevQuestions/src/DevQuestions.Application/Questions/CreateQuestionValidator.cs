using DevQuestionsContract.Questions;
using FluentValidation;

namespace DevQuestions.Application.Questions;

public class CreateQuestionValidator: AbstractValidator<CreateQuestionDto>
{
    public CreateQuestionValidator()
    {
        this.RuleFor(x => x.Title).NotEmpty().MaximumLength(500).WithMessage("Заголовок невалидный");
        this.RuleFor(x => x.Text).NotEmpty().MaximumLength(5000).WithMessage("Текст невалидный");
        this.RuleFor(x => x.UserId).NotEmpty();
        this.RuleForEach(x => x.TagIds).NotEmpty();
    }
}