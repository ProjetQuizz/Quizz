using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Core.Models
{
    public class Survey : BaseEntity
    {

        public DateTime Timer { get; set; }

        public int Score { get; set; }
        public DateTime Date { get; set; }
        public string User { get; set; }

        public string Category { get; set; }
    }
}
