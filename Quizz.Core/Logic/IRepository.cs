using Quizz.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace Quizz.Core.Logic
{
    public interface IRepository<T> where T : BaseEntity
    {

       IQueryable<T> Collection();
           
        List<Question> FindAll(); //je vais avoir besoin d'une liste de question et une liste de answer
                                  //list<T> FindAll(); (?)

        //List<Answer> FindAllAnswer(); //list de question => sans intérêt

        List<Answer> AllAnswersByQuestion(int questionId);// lister les questions par rapport à une question
        void Delete(int id);
       
        // void Delete(T obj);
        T FindById(int id);

        void Insert(T t);

        void SaveChanges();

        void Update(T t);
    }
}
