using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Core.Models
{
    public class User : BaseEntity 
    {

        [Required(ErrorMessage = "Firstname required!")]
        [StringLength(20)]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Lastname required!")]
        [StringLength(20)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email required!")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Phone { get; set; }

        [Required(ErrorMessage = "Password required!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        public DateTime dateCreated { get; set; }
        public double score { get;set; }
        public bool Admin { get; set; }


    }
}
