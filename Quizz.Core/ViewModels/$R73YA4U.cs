using Quizz.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Core.ViewModels
{
    public class QuestionCategoryViewModel
    {
        public Question Question { get; set; }
        public IEnumerable<QuestionCategory> QuestionCategories { get; set; }
    }
}
