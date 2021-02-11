using Quizz.Core.Logic;
using Quizz.Core.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Quizz.DataAccess.SQL
{
    public class SQLRepository<T> : IRepository<T> where T : BaseEntity //le type T est lié au dbset
    {
        internal MyContext DataContext;
        internal DbSet<T> dbSet;

               
        public SQLRepository(MyContext dataContext)
        {
            this.DataContext = dataContext;
            dbSet = dataContext.Set<T>();
        }

        public IQueryable<T> Collection()
        {
           return dbSet;
        }

        public List<Question> FindAll()
        { 
            return DataContext.Questions.AsNoTracking().ToList();
        }
       
        public void Delete(int id)
        {
            T t = FindById(id);
            if (DataContext.Entry(t).State == EntityState.Detached)
            {
                dbSet.Attach(t);//attach permet de charger l'objet dans le context
            }
            dbSet.Remove(t);
        }

        public T FindById(int id)
        {
            return dbSet.Find(id);
        }


        public void Insert(T t)
        {
            dbSet.Add(t);
        }

        public void SaveChanges()
        {
            DataContext.SaveChanges();
        }

        public void Update(T t)
        {
            dbSet.Attach(t);
            DataContext.Entry(t).State = EntityState.Modified;
        }
      

        public List<Answer> AllAnswersByQuestion(int questionId)
        {
            return DataContext.Answers.AsNoTracking().Where(r => r.QuestionId == questionId ).ToList();
        }

    }
}
