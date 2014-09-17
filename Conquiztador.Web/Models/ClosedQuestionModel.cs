namespace Conquiztador.Web.Models
{
    using GameDb.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web;

    public class ClosedQuestionModel
    {
        public static Expression<Func<ClosedQuestion, ClosedQuestionModel>> FromQuestion
        {
            get
            {
                return q => new ClosedQuestionModel
                {
                    Id = q.Id,
                    Question = q.Question,
                    AnswerA = q.AnswerA,
                    AnswerB = q.AnswerB,
                    AnswerC = q.AnswerC,
                    AnswerD = q.AnswerD,
                    CorrectAnswer = q.CorrectAnswer
                };
            }
        }

        public int Id { get; set; }

        public string Question { get; set; }

        public string AnswerA { get; set; }

        public string AnswerB { get; set; }

        public string AnswerC { get; set; }

        public string AnswerD { get; set; }

        public string CorrectAnswer { get; set; }
    }
}