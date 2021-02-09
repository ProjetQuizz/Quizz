using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Quizz.Core.Logic;
using Quizz.Core.Models;
using Quizz.Core.ViewModels;
using Quizz.DataAccess.SQL;

namespace Quizz.WebUi.Controllers
{
    //A REVOIR DE FONTE EN COMBLE DEPUIS LE MODELE ET REVOIR LES BESOINS 
    public class AnswerManagerController : Controller
    {
        IRepository<Answer> context;

        MyContext db = new MyContext();

        public AnswerManagerController()
        {
            context = new SQLRepository<Answer>(new MyContext());
        }

        public AnswerManagerController(IRepository<Answer> context)
        {
            this.context = context;
        
        }

        // GET: AnswerManager
        public ActionResult Index()
        {
            List<Answer> answers = context.Collection().ToList();
            return View(answers);
        }

        public ActionResult Create()
        {
            //List<Question> lst = db.Questions.OrderByDescending(x => x.Title).ToList();
            List<Question> lst = db.Questions.ToList();
            ViewBag.list = new SelectList(lst, "Title ", "Title");


            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Answer answer)//elle est sensée recevoir le contenu du formulaire soit un objet de type product
        {
            if (!ModelState.IsValid) //si l'état du model est valid
            {
                return View(answer);//on reste sur la même page avec le meme objet
            }
            else
            {
                context.Insert(answer);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                Answer a = context.FindById(id);
                if (a == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View(a);
                }
            }
            catch (Exception)
            {

                return HttpNotFound();
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Answer Answer, int id)
        {
            try
            {
                Answer qToEdit = context.FindById(id);
                if (qToEdit == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    if (!ModelState.IsValid)
                    {
                        return View(Answer);
                    }
                    else
                    {
                        qToEdit.Name = Answer.Name;
                        qToEdit.Question = Answer.Question;

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

        public ActionResult Delete(int id)//la view est sensée afficher un formulaire pour effacer un produit
        {
            try
            {
                Answer q = context.FindById(id);
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
                Answer answerToDelete = context.FindById(id);

                if (answerToDelete == null)
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
