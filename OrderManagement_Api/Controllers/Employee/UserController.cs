﻿using Newtonsoft.Json;
using OrderManagement_Api.Models;
using System.Collections.Generic;
using System.Data;
using System.Net;
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
                            Role = row["Emp_Job_Role"],
                            Reporting = row["Reporting"],
                            Shift = row["Shift_Type_Name"],
                            LoginTime = row["Login_Time"],
                            Theme = row["Theme"]
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
            else return BadRequest();
        }
        [HttpPost]
        [ActionName("Timings")]
        public IHttpActionResult GetTimings(dynamic data)
        {
            if (data == null) return BadRequest();
            try
            {
                var dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(data));
                DataTable dt = DbExecute.GetMultipleRecordByParam("Sp_Production_Reports", dictionary);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return Ok(dt);
                }
                return NotFound();
            }
            catch (HttpResponseException ex)
            {
                return StatusCode(ex.Response.StatusCode);
            }
        }
        [HttpPost]
        [ActionName("Attendance")]
        public IHttpActionResult GetAttendance(dynamic data)
        {
            if (data == null) return BadRequest();
            try
            {
                var dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(data));
                DataTable dt = DbExecute.GetMultipleRecordByParam("SP_User_Login_Details", dictionary);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return Ok(dt);
                }
                return NotFound();
            }
            catch (HttpResponseException ex)
            {
                return StatusCode(ex.Response.StatusCode);
            }
        }
        [HttpPut]
        [ActionName("ChangePassword")]
        public IHttpActionResult ChangePassword(dynamic data)
        {
            if (data == null) return BadRequest();
            try
            {
                var dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(data));
                int result = DbExecute.ExecuteSPForCRUD("Sp_User", dictionary);
                if (result > 0)
                {
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (HttpResponseException ex)
            {
                return StatusCode(ex.Response.StatusCode);
            }
        }      
        [HttpPost]
        [ActionName("Theme")]
        public IHttpActionResult SetTheme(dynamic data)
        {
            if (data == null) return BadRequest();
            try
            {
                var dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(data));
                int result = DbExecute.ExecuteSPForCRUD("Sp_User", dictionary);
                if (result > 0)
                {
                    return Ok();
                }
                else
                {
                    return StatusCode(HttpStatusCode.NotModified);
                }
            }
            catch (HttpResponseException e)
            {
                return StatusCode(e.Response.StatusCode);
            }
        }
        [HttpPost]
        [ActionName("Errors")]
        public IHttpActionResult Errors(dynamic data)
        {
            if (data == null) return BadRequest();
            try
            {
                var dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(data));
                DataTable dt = DbExecute.GetMultipleRecordByParam("Sp_Error_Dashboard", dictionary);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return Ok(dt);
                }
                return NotFound();
            }
            catch (HttpResponseException ex)
            {
                return StatusCode(ex.Response.StatusCode);
            }
        }
    }
}
