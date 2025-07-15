﻿using DevQuestionsContract.Questions;

namespace DevQuestions.Application.Questions;

public interface IQuestionsService
{
    Task<Guid> Create(CreateQuestionDto questionDto, CancellationToken cancellationToken);
}