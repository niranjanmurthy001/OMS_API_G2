using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderManagement_Api.Models
{
    public class Validate_Users
    {

        public Users Validate(string UserName, string Password)
        {

            using (var context = new DBContext())
            {

                try
                {

                    return context.Users.FirstOrDefault(U => U.DRN_Emp_Code.Equals(UserName, StringComparison.OrdinalIgnoreCase) && U.Password.Equals(Password));
                }
                catch (Exception ex)
                {

                    return null;

                }
            }
            
        }
    }
}