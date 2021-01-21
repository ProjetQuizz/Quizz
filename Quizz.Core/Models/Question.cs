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
        public string Title { get; set; }

        public int Survey { get; set; }

    }
}
