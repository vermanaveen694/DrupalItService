using HIS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HIS.Repository
{
    public class EmpData : IEmp
    {
        SqlHelper objDa = new SqlHelper();

        public DataTable GetAllEmp()
        {
            DataTable dt = new DataTable();
            var para = new List<SqlParameter>();
            para.Add(objDa.CreateParameter("@Action", 100, "SelectAll", DbType.String));
            dt = objDa.GetDataTable("Sp_EmpGet", CommandType.StoredProcedure, para.ToArray());
            return dt;
        }
        
        public DataTable InsertEmpData(string Name,int id)
        {
            DataTable dt = new DataTable();
            var para = new List<SqlParameter>();
            para.Add(objDa.CreateParameter("@Action", 100, "save", DbType.String));
            para.Add(objDa.CreateParameter("@Name", 100, Name, DbType.String));
            para.Add(objDa.CreateParameter("@Cid", 100, id, DbType.String));
            dt = objDa.GetDataTable("Sp_CrudEmp", CommandType.StoredProcedure, para.ToArray());
            return dt;
        }
    }
}