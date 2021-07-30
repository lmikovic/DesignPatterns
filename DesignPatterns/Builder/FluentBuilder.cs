using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public class FluentBuilder
    {
        Question question = new QuestionBuilder()
                            .WithQuestionText("What is your name?")
                            .WithAnswers(new List<Answer>
                            {
                                new AnswerBuilder()
                                    .WithAnswerText("Matheus")
                                    .WithCorrect(true),
                                new AnswerBuilder()
                                    .WithAnswerText("Robert")
                            });
    }

    public class Question
    {
        public string DifficultyLevel { get; set; }
        public string QuestionText { get; set; }
        public List<Answer> Answers { get; set; }
        public Question(string difficultyLevel, string questionText, List<Answer> answers)
        {
            DifficultyLevel = difficultyLevel;
            QuestionText = questionText;
            Answers = answers;
        }
    }

    public class QuestionBuilder
    {
        private string _questionText = "Easy";
        private string _difficultyLevel = "Question?";
        private List<Answer> _answers = new List<Answer> { new AnswerBuilder() };
        public Question Build()
        {
            return new Question(_difficultyLevel, _questionText, _answers);
        }
        public QuestionBuilder WithDifficultyLevel(string difficultyLevel)
        {
            _difficultyLevel = difficultyLevel;
            return this;
        }
        public QuestionBuilder WithQuestionText(string questionText)
        {
            _questionText = questionText;
            return this;
        }
        public QuestionBuilder WithAnswers(List<Answer> answers)
        {
            _answers = answers;
            return this;
        }
        public static implicit operator Question(QuestionBuilder instance)
        {
            return instance.Build();
        }
    }

    public class AnswerBuilder
    {
        private string _answerText = "Yes";
        private bool _isCorrect = false;

        public Answer Build()
        {
            return new Answer(_answerText, _isCorrect);
        }
        public AnswerBuilder WithAnswerText(string answerText)
        {
            _answerText = answerText;
            return this;
        }
        public AnswerBuilder WithCorrect(bool isCorrect)
        {
            _isCorrect = isCorrect;
            return this;
        }
        public static implicit operator Answer(AnswerBuilder instance)
        {
            return instance.Build();
        }
    }

    public class Answer
    {
        public string AnswerText { get; set; }
        public bool IsCorrect { get; set; }
        public Answer(string difficultyLevel, bool isCorrect)
        {
            AnswerText = difficultyLevel;
            IsCorrect = isCorrect;
        }
    }
}
