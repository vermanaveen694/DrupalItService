using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using HIS.Models;
using HIS.Repository;
namespace HIS.Repository
{
    public class LoginData : ILogin
    {
        SqlHelper ObjDa = new SqlHelper();
        public DataSet ValidateUsers(string Userid, string Password)
        {
            var para = new List<SqlParameter>();
            para.Add(ObjDa.CreateParameter("@Userid", 100, Userid, DbType.String));
            para.Add(ObjDa.CreateParameter("@Password", 100, Password, DbType.String));
            DataSet ds = new DataSet();
            ds = ObjDa.GetDataSet("Sp_UserLogin", CommandType.StoredProcedure, para.ToArray());
            return ds;
        }
    }
}