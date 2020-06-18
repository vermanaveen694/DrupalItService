using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HIS.Models;
namespace HIS.Controllers
{
    public class StudentController : Controller
    {
        StudentDbContext objDataContext = new StudentDbContext();
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        // GET: Student
        public ActionResult AddSubject()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSubject(SubjectMaster objsubect)
        {

            try
            {
                objDataContext.subjectMasters.Add(objsubect);
                objDataContext.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;

            }
            ViewBag.Message = "Subject Added";
            return View();
        }


        public ActionResult AddClass()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddClass(ClassMaster objclass)
        {
            try
            {
                objDataContext.classMasters.Add(objclass);
                objDataContext.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            ViewBag.Message = "Class Added";
            return View();
        }
        [HttpGet]
        public ActionResult StudentRegistration()
        {
            StudentDto ObjStudentViewModel = new StudentDto();
            ObjStudentViewModel.classlist = objDataContext.classMasters.ToList().Select(d => new SelectListItem
            {
                Value = d.Classid.ToString(),
                Text = d.ClassName,
            });
            return View(ObjStudentViewModel);
        }
        [HttpPost]
        public ActionResult StudentRegistration(StudentDto obj)
        {


            try
            {
                objDataContext.studentRegistrations.Add(obj.StudentRegistrationObj);
                objDataContext.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            obj = new StudentDto();
            obj.classlist = objDataContext.classMasters.ToList().Select(d => new SelectListItem
            {
                Value = d.Classid.ToString(),
                Text = d.ClassName,
            });
            ViewBag.Message = "Student Registration Added";
            return View(obj);
        }

        [HttpGet]
        public ActionResult AddStudentSubject()
        {
            StudentDto ObjStudentViewModel = new StudentDto();
            ObjStudentViewModel.sublist = objDataContext.subjectMasters.ToList().Select(d => new SelectListItem
            {
                Value = d.SubjectId.ToString(),
                Text = d.SubjectName,
            });
           
            ObjStudentViewModel.studentlist = objDataContext.studentRegistrations.ToList().Select(d => new SelectListItem
            {
                Value = d.StudentRegId.ToString(),
                Text = d.FirstName,
            });
            return View(ObjStudentViewModel);
        }
        [HttpPost]
        public ActionResult AddStudent(StudentDto ObjStudentViewModel)
        {
            try
            {
                objDataContext.studentSubjects.Add(ObjStudentViewModel.studentobj);
                objDataContext.SaveChanges();
                ViewBag.Message = "Student Subject Added";
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            ObjStudentViewModel.sublist = objDataContext.subjectMasters.ToList().Select(d => new SelectListItem
            {
                Value = d.SubjectId.ToString(),
                Text = d.SubjectName,
            });
            ObjStudentViewModel.classlist = objDataContext.classMasters.ToList().Select(d => new SelectListItem
            {
                Value = d.Classid.ToString(),
                Text = d.ClassName,
            });
            ObjStudentViewModel.studentlist = objDataContext.studentRegistrations.ToList().Select(d => new SelectListItem
            {
                Value = d.StudentRegId.ToString(),
                Text = d.FirstName,
            });
            return View(ObjStudentViewModel);
        }

        [HttpGet]
        public ActionResult StudentList()
        {
            StudentDto ObjStudentViewModel = new StudentDto();

            var resultdata = (from s in objDataContext.studentRegistrations
                              join ssubject in objDataContext.studentSubjects
                              on s.StudentRegId equals ssubject.StudentRegId
                              join c in objDataContext.classMasters
                              on s.classid equals c.Classid
                              join subjecmaster in objDataContext.subjectMasters
                              on ssubject.SubjectId equals subjecmaster.SubjectId
                              select new
                              {
                                  FirstName = s.FirstName,
                                  SecondName = s.SecondName,
                                  ClassName = c.ClassName,
                                  SubjectId = ssubject.SubjectId,
                                  Marks = ssubject.Marks,
                                  StudentRegId = s.StudentRegId,
                                  SubjectName = subjecmaster.SubjectName,
                                  classid = s.classid,
                                  Id = ssubject.Id
                              }).ToList().Select(x => new StudentList()
                              {
                                  FirstName = x.FirstName,
                                  SecondName = x.SecondName,
                                  ClassName = x.ClassName,
                                  SubjectId = x.SubjectId,
                                  Marks = x.Marks,
                                  StudentRegId = x.StudentRegId,
                                  SubjectName = x.SubjectName,
                                  classid = x.classid,
                                  Id = x.Id
                              }
                         ); ;
            ObjStudentViewModel.studentlistdata = resultdata.OrderBy(n => n.StudentRegId).ThenBy(p => p.classid).ToList();
            return View(ObjStudentViewModel);
        }




        [HttpGet]
        public ActionResult StudentSubjectEdit(string Id)
        {

            int ssubjectid = Convert.ToInt32(Id);
          
            StudentDto ObjStudentViewModel = new StudentDto();

            var emp = objDataContext.studentSubjects.Find(ssubjectid);

            var result = (from s in objDataContext.studentSubjects where s.Id == ssubjectid select s).First();
            ObjStudentViewModel.sublist = objDataContext.subjectMasters.ToList().Select(d => new SelectListItem
            {
                Value = d.SubjectId.ToString(),
                Text = d.SubjectName,
            });

            ObjStudentViewModel.studentlist = objDataContext.studentRegistrations.ToList().Select(d => new SelectListItem
            {
                Value = d.StudentRegId.ToString(),
                Text = d.FirstName,
            });
            ObjStudentViewModel.studentobj = result;
            return View(ObjStudentViewModel);
        }

        [HttpPost]
        public ActionResult StudentSubjectEdit(string Id, StudentDto ObjStudentViewModel)
        {
            try
            {

                var emp = objDataContext.studentSubjects.Find(ObjStudentViewModel.studentobj.Id);
                if (emp != null)
                {


                    StudentSubject s = new StudentSubject();
                    s= objDataContext.studentSubjects.Find(ObjStudentViewModel.studentobj.Id);

                    s.SubjectId = ObjStudentViewModel.studentobj.SubjectId;
                    s.Marks = ObjStudentViewModel.studentobj.Marks;


                    objDataContext.SaveChanges();

                }



                ViewBag.Message = "Student Update ";
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            ObjStudentViewModel.sublist = objDataContext.subjectMasters.ToList().Select(d => new SelectListItem
            {
                Value = d.SubjectId.ToString(),
                Text = d.SubjectName,
            });
            ObjStudentViewModel.classlist = objDataContext.classMasters.ToList().Select(d => new SelectListItem
            {
                Value = d.Classid.ToString(),
                Text = d.ClassName,
            });
            ObjStudentViewModel.studentlist = objDataContext.studentRegistrations.ToList().Select(d => new SelectListItem
            {
                Value = d.StudentRegId.ToString(),
                Text = d.FirstName,
            });
            return View(ObjStudentViewModel);

        }

        }
}