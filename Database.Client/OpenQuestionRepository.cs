﻿namespace GameDb.Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using GameDb.Models;
    using GameDb.Entities;

    public class OpenQuestionRepository: IOpenQuestionRepository
    {
        GameContext context = new GameContext();

        public OpenQuestionRepository(GameContext context)
        {
            this.context = context;
        }

        public IQueryable<OpenQuestion> All
        {
            get
            {
                return context.OpenQuestions;
            }
        }

        public void Insert(string question)
        {
            if (!context.OpenQuestions.Any(x => x.Question == question))
            {
                context.OpenQuestions.Add(new OpenQuestion() { Question = question});

            }
            Save();
        }

        public void InsertAll(IEnumerable<OpenQuestion> questions)
        {
            foreach(var question in questions)
            {
                if (!context.OpenQuestions.Any(x => x.Question == question.Question))
                {
                    context.OpenQuestions.Add(question);
                }
            }
            Save();
        }

        public bool UpdateAnswers(string question, int answer)
        {
            if (context.OpenQuestions.Any(x => x.Question == question))
            {
                var openQuestion = context.OpenQuestions.Find(question);
                openQuestion.CorrectAnswer = answer;
                Save();
                return true;
            }
            return false;
        }

        public bool Delete(string name)
        {
            if (context.OpenQuestions.Any(x => x.Question == name))
            {
                var openQuestion = context.OpenQuestions.Find(name);
                context.OpenQuestions.Remove(openQuestion);
                Save();
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}