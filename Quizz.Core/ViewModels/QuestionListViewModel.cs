using Quizz.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Core.ViewModels
{
    public class QuestionListViewModel
    {
        public List<Question> Questions { get; set; }
        public List<QuestionCategory> QuestionCategories { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
