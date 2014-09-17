namespace Conquiztador.Web.Controllers
{
    using GameDb.Entities.Repositories;
    using GameDb.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Http;

    public class OpenQuestionsController : ApiController
    {
        private IGameData data;

        public OpenQuestionsController()
            :this(new GameData())
        {
        }

        public OpenQuestionsController(IGameData context)
        {
            this.data = context;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var openQuestions = this.data
                .OpenQuestions
                .All();

            return Ok(openQuestions);
        }

        [HttpGet]
        public IHttpActionResult ById(int id)
        {
            var question = this.data
                .OpenQuestions
                .All()
                .Where(q => q.Id == id)
                .FirstOrDefault();

            return Ok(question);
        }

        [HttpPost]
        public IHttpActionResult Create(OpenQuestion openQst)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            this.data.OpenQuestions.Add(openQst);
            this.data.SaveChanges();

            return Ok(openQst);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var existingQuestion = this.data.OpenQuestions
                                            .All()
                                            .Where(q => q.Id == id)
                                            .FirstOrDefault();

            if (existingQuestion == null)
            {
                return BadRequest("Such question does not exists!");
            }

            this.data.OpenQuestions.Delete(existingQuestion);
            this.data.SaveChanges();

            return Ok();
        }
    }
}