using Quizz.Core.Logic;
using Quizz.Core.Models;
using Quizz.Core.ViewModels;
using Quizz.DataAccess.SQL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quizz.WebUi.Controllers
{
    public class QuestionManagerController : Controller
    {

       // MyContext db = new MyContext();

        IRepository<Question> context;
 
        IRepository<QuestionCategory> contextCategory;

        public QuestionManagerController()
        {
            context = new SQLRepository<Question>(new MyContext());
            contextCategory = new SQLRepository<QuestionCategory>(new MyContext());
        }

        public QuestionManagerController(IRepository<Question> context, IRepository<QuestionCategory> contextCategory)
        {
            this.context = context;
            this.contextCategory = contextCategory;
        }

        // GET: QuestionManager
        public ActionResult Index()
        {
            //return context.Employees.Include(em => em.Posts).ToList(); //on va récupérer tous les employee
            //List< Question> q = db.Questions.Include(em => em.Answer).ToList();
            //List< Question> questions= context..Include(em => em.Answer).ToList();
           
           List<Question> questions = context.Collection().ToList();
            return View(questions);
        }

        public ActionResult Create()
        {
            QuestionCategoryViewModel viewModel = new QuestionCategoryViewModel();
            viewModel.Question = new Question();
            viewModel.QuestionCategories = contextCategory.Collection();

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Question question)//elle est sensée recevoir le contenu du formulaire soit un objet de type product
        {
            if (!ModelState.IsValid) //si l'état du model est valid
            {
                return View(question);//on reste sur la même page avec le meme objet
            }
            else
            {
                context.Insert(question);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(int id)//la view est sensée afficher un formulaire pour modifier un produit
        {
            try
            {
               Question q = context.FindById(id);

                if (q == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    QuestionCategoryViewModel viewModel = new QuestionCategoryViewModel();
                    viewModel.Question = q;
                    viewModel.QuestionCategories = contextCategory.Collection();
                    return View(viewModel);
                }
            }
            catch (Exception)
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //j'aurai besoin de faire une valisation
        public ActionResult Edit(Question question,int id)
        {
           
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(question);
                }
                else
                {
                    context.Update(question);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {
                return HttpNotFound();
            }
        }

        public ActionResult Delete(int id)//la view est sensée afficher un formulaire pour effacer un produit
        {
            try
            {
                Question q = context.FindById(id);
                if (q == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View(q);
                }
            }
            catch (Exception)
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            try
            {
                Question questToDelete = context.FindById(id);

                if (questToDelete == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    context.Delete(id);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {
                return HttpNotFound();
            }
        }

    }
}