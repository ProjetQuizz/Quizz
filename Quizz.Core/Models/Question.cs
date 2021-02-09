using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Core.Models
{
    public class Question : BaseEntity
    {
        [Required(ErrorMessage = "Title required")]
        public string Title { get; set; }
        public string Category { get; set; }
        public List<Answer> Answer { get; set; }
    }
}

