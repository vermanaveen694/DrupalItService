using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HIS.Models
{
    public class StudentRegistration
    {
        [Key]
        public int StudentRegId { get; set; }
        [Required(ErrorMessage = "You Can Not Leave It Blank")]
        [RegularExpression(@"(\S)+", ErrorMessage = "White Space It Not Allowed")]
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public int classid { get; set; }
    }
}