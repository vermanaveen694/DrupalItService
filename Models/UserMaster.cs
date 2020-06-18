using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HIS.Models
{
    public class UserMaster
    {
        public int Uid { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public int Cid { get; set; }
        public DateTime Cdate { get; set; }
        public int Mid { get; set; }
        public DateTime Mdate { get; set; }
        public int Flag { get; set; }
        public int RoleId { get; set; }
        public string Role { get; set; }

    }
}