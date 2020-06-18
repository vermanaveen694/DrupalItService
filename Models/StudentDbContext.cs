using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HIS.Models
{
    public class StudentDbContext : DbContext
    {
        public DbSet<StudentSubject> studentSubjects { get; set; }
        public DbSet<ClassMaster> classMasters { get; set; }
        public DbSet<SubjectMaster> subjectMasters { get; set; }
        public DbSet<StudentRegistration> studentRegistrations { get; set; }
    }
}