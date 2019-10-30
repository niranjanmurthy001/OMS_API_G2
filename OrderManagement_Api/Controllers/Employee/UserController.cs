using OrderManagement_Api.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OrderManagement_Api.Controllers.Employee
{
    public class UserController : ApiController
    {
        [HttpGet]
        [ActionName("GetUser")]
        public IHttpActionResult GetUser(int? id = null)
        {
            if (id.HasValue)
            {
                try
                {
                    var user = new Dictionary<string, object>()
                    {
                          { "@User_id",id },
                          { "@Trans","USER_IDWISE" }
                    };
                    var dt = DbExecute.GetMultipleRecordByParam("Sp_User", user);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];
                        var userDetails = new
                        {
                            EmployeeName = row["User_Name"],
                            Code = row["DRN_Emp_Code"],
                            Branch = row["Branch_Name"],
                            Role = row["Role_Name"],
                            Reporting = row["Reporting"],
                            Shift = row["Shift_Type_Name"]
                        };
                        return Ok(userDetails);
                    }
                    return NotFound();
                }
                catch (HttpResponseException ex)
                {
                    return StatusCode(ex.Response.StatusCode);
                }
            }
            else
            {
                return NotFound();
            }
        }
    }
}

