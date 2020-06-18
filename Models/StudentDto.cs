using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HIS.Models
{
    public class StudentDto
    {
        public IEnumerable<SelectListItem> classlist { get; set; }
        public IEnumerable<SelectListItem> sublist { get; set; }
        public IEnumerable<SelectListItem> studentlist { get; set; }
        //public Student studentobj { get; set; }
        public StudentRegistration StudentRegistrationObj { get; set; }
        public StudentSubject studentobj { get; set; }
        public List<StudentList> studentlistdata { get; set; }

    }
}