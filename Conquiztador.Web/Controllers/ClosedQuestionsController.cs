using Conquiztador.Web.Models;
using GameDb.Entities.Repositories;
using GameDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Conquiztador.Web.Controllers
{
    public class ClosedQuestionsController : ApiController
    {
        private IGameData data;

        public ClosedQuestionsController()
            :this(new GameData())
        {
        }

        public ClosedQuestionsController(IGameData context)
        {
            this.data = context;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var closedQuestions = this.data
                .ClosedQuestions
                .All()
                .Select(ClosedQuestionModel.FromQuestion);

            return Ok(closedQuestions);
        }

        [HttpGet]
        public IHttpActionResult ById(int id)
        {
            var question = this.data
                .ClosedQuestions
                .All()
                .Where(q => q.Id == id)
                .Select(ClosedQuestionModel.FromQuestion)
                .FirstOrDefault();

            return Ok(question);
        }

        [HttpPost]
        public IHttpActionResult Create(ClosedQuestionModel closedQst)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newQuestion = new ClosedQuestion
            {
                Question = closedQst.Question,
                AnswerA = closedQst.AnswerA,
                AnswerB = closedQst.AnswerB,
                AnswerC = closedQst.AnswerC,
                AnswerD = closedQst.AnswerD,
                CorrectAnswer = closedQst.CorrectAnswer
            };


            this.data.ClosedQuestions.Add(newQuestion);
            this.data.SaveChanges();

            closedQst.Id = newQuestion.Id;
            return Ok(closedQst);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var existingQuestion = this.data.ClosedQuestions
                                            .All()
                                            .Where(q => q.Id == id)
                                            .FirstOrDefault();

            if (existingQuestion == null)
            {
                return BadRequest("Such question does not exists!");
            }

            this.data.ClosedQuestions.Delete(existingQuestion);
            this.data.SaveChanges();

            return Ok();
        }
    }
}