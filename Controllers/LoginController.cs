using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HIS.Models;
using HIS.Repository;

namespace HIS.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login

        SqlHelper ObjDa = new SqlHelper();
        ILogin objLoginData;
        public LoginController()
        {
            objLoginData = new LoginData();
        }
        public ActionResult Index()
        {
            Session.Abandon();
            return View();
        }

        //Login Controler Where Work and Get Detail of Valid User  
       
        [HttpPost]
        public ActionResult Index(UserMaster user)
        {
            try
            {
                return View();
            }
            catch (Exception ex) {

                Response.Write(ex.Message);
                return View();
            }

        }

    }
}