using Quizz.Core.Logic;
using Quizz.Core.Models;
using Quizz.DataAccess.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quizz.WebUi.Controllers
{
    public class QuestionCategoryController : Controller
    {

        IRepository<QuestionCategory> context;


        //bonne pratique on crée un contructeur
        public QuestionCategoryController()
        {
            context = new SQLRepository<QuestionCategory>(new MyContext());
            //context = new InMemoryRepository<ProductCategory>();
        }

        //step1  la méthode index est sensée  afficher une list de category
        // GET: ProductManager  
        public ActionResult Index()
        {
            List<QuestionCategory> questionsCategories = context.Collection().ToList();
            return View(questionsCategories); //el transmet cette liste à la vue
        }

        public ActionResult Create()
        {
            QuestionCategory q = new QuestionCategory();
            return View(q);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(QuestionCategory product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            else
            {
                context.Insert(product);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                QuestionCategory q = context.FindById(id);
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
        [ValidateAntiForgeryToken] //j'aurai besoin de faire une valisation
        public ActionResult Edit(QuestionCategory question, int id)
        {

            try

            {

                //context.update(product); ce n'est pas un context EntityFramework
                QuestionCategory questToEdit = context.FindById(id);

                if (questToEdit == null)
                {
                    return HttpNotFound();
                }
                else
                { //ici je recois un formulaire

                    if (!ModelState.IsValid)
                    {
                        return View(question);
                    }
                    else
                    {
                        questToEdit.Category = question.Category;

                        context.SaveChanges();
                        return RedirectToAction("Index");
                    }

                }


            }
            catch (Exception)
            {
                return HttpNotFound();
            }

        }

        public ActionResult Delete(int id)
        {
            try
            {
                QuestionCategory q = context.FindById(id);
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
                QuestionCategory questToDelete = context.FindById(id);

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