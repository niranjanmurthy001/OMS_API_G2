using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderManagement_Api.Models
{
    public class Users
    {
        public int User_id { get; set; }
        public int User_RoleId { get; set; }
        public string Employee_Name { get; set; }
        public string User_Name { get; set; }
        public string Password { get; set; }
        public int Job_Role_Id { get; set; }
        public int Application_Login_Type { get; set; }
        public string DRN_Emp_Code { get; set; }
        public string Image_File_Name { get; set; }
        public string Employee_Type { get; set; }

    }
}