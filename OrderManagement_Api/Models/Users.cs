using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace OrderManagement_Api.Models
{
   [System.ComponentModel.DataAnnotations.Schema.Table("Tbl_User")]
    public class Users
    {   [Key]
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
        public int Shift_Type_Id { get; set; }
        public int Branch_ID { get; set; }
        public int Main_id { get; set; }
        public string Mobileno { get; set; }

        public decimal Salary { get; set; }

        public Nullable<DateTime> Last_login { get; set; }

    }
}