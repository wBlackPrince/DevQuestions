using DevQuestionsContract.Questions;
using FluentValidation;

namespace DevQuestions.Application.Questions.CreateQuestion;

public class CreateQuestionValidator: AbstractValidator<CreateQuestionDto>
{
    public CreateQuestionValidator()
    {
        this.RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Заголовок не может быть пустым")
            .MaximumLength(500).WithMessage("Заголовок невалидный");
        this.RuleFor(x => x.Text)
            .NotEmpty().WithMessage("Текст не может быть пустым")
            .MaximumLength(5000).WithMessage("Текст невалидный");
        this.RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("Идентфиикатор пользователя не может быть пустым");
        this.RuleFor(x => x.TagIds)
            .NotEmpty().WithMessage("Список тегов не может быть пустым");
    }
}

