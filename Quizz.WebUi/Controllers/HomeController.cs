using Quizz.Core.Logic;
using Quizz.Core.Models;
using Quizz.Core.ViewModels;
using Quizz.DataAccess.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace Quizz.WebUi.Controllers
{
   
           public class HomeController : Controller
        {
        IRepository<Question> context;
            IRepository<QuestionCategory> CategoryContext;
            IRepository<Answer> AnswerContext;

        public HomeController()
            {
                context = new SQLRepository<Question>(new MyContext());
                CategoryContext = new SQLRepository<QuestionCategory>(new MyContext());
                AnswerContext = new SQLRepository<Answer>(new MyContext());
                //context = new InMemoryRepository<Product>();
                //CategoryContext = new InMemoryRepository<ProductCategory>();

            
            }

            public HomeController(IRepository<Question> context, IRepository<QuestionCategory> categoryContext)
            {
                this.context = context;
                CategoryContext = categoryContext;
            }

                              //Parameter(string Category = null)
            public ActionResult Index()
            {
                // List<Question> questions;
                // List<QuestionCategory> categories = CategoryContext.Collection().ToList();
                // if (Category == null)
                // {
                //     questions = context.Collection().ToList();
                // }
                // else
                // {
                //     questions = context.Collection().Where(p => p.Category == Category).ToList();
                // }
                //
                // QuestionListViewModel viewModel = new QuestionListViewModel();
                // viewModel.Questions = questions;
                // viewModel.QuestionCategories = categories;
                //
                // return View(viewModel);
                return View();
            }
         
           public ActionResult QuestionByCategory(string Category = null, string Question = null)
            {
                List<Question> questions;
                List<QuestionCategory> categories = CategoryContext.Collection().ToList();
                List<Answer> answers = AnswerContext.Collection().ToList();
                
                if (Category == null)
                {
                    questions = context.Collection().ToList();
                   
                }
                else
                {
                    questions = context.Collection().Where(p => p.Category == Category).ToList();
                    if (Question != null)
                    {
                        answers = AnswerContext.Collection().Where(a =>a.QuestionObj == Question).ToList();
                    }
                }



                QuestionListViewModel viewModel = new QuestionListViewModel();
                viewModel.Questions = questions;
                viewModel.QuestionCategories = categories;
                viewModel.Answers = answers;

                return View(viewModel);
            }
          
            public ActionResult Contact()
            {
                ViewBag.Message = "Your contact page.";

                return View();
            }
        }
}
