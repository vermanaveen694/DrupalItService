using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HIS.Models
{
    public class ClassMaster
    {
        [Key]
        public int Classid { get; set; }
        [Required(ErrorMessage = "You Can Not Leave It Blank")]
        [RegularExpression(@"(\S)+", ErrorMessage = "White Space It Not Allowed")]
        public string ClassName { get; set; }
    }
}