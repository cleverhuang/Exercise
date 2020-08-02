using System;
using System.Text;

namespace NullableIntroduction
{
    public enum QuestionType
    {
        YesNo,
        Number,
        Text,
    }
    public class SurveyQuestion
    {
        public string QuestionText { get; }
        public QuestionType TypeOfQuestion { get; }
        public SurveyQuestion(QuestionType typeOfQuestion, string text)
        {
            (TypeOfQuestion, QuestionText) = (typeOfQuestion, text);

            //等价于
            //TypeOfQuestion = typeOfQuestion;
            //QuestionText = text;
        }
    }
}
