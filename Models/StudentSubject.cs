using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HIS.Models
{
    public class StudentSubject
    {
        [Key]
        public int Id { get; set; }
        public int StudentRegId { get; set; }
        //public int classid { get; set; }
        public int SubjectId { get; set; }
        [Required(ErrorMessage = "You Can Not Leave It Blank")]
        [RegularExpression(@"(\S)+", ErrorMessage = "White Space It Not Allowed")]
        public decimal Marks { get; set; }
        public string SubjectName { get; set; }
    }
}