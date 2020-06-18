using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.Repository
{
    interface IEmp
    {
        DataTable GetAllEmp();
        DataTable InsertEmpData(string Name,int id);
    }
}
