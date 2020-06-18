using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HIS.Models;
namespace HIS.Repository
{
    interface ILogin
    {
        DataSet ValidateUsers(string Userid,string Password);
    }
}
