using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HIS.Models
{
    public class StudentList
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ClassName { get; set; }
        public int SubjectId { get; set; }
        public decimal Marks { get; set; }
        public int StudentRegId { get; set; }
        
        public int classid { get; set; }
        public string SubjectName { get; set; }
        public int Id { get; set; }


    }
}