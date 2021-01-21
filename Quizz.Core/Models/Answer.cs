using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Core.Models
{
    public class Answer : BaseEntity
    {
        public string Title { get; set; }

        public bool Value { get; set; }

        public string Question { get; set; } // ensemble de la classe Id

    }
}
