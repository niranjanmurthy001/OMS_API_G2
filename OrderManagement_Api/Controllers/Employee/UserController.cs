using Newtonsoft.Json;
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
        [Authorize]
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
                            EmployeeImage=row["User_Photo"],
                            EmployeeName = row["User_Name"],
                            Code = row["DRN_Emp_Code"],
                            Branch = row["Branch_Name"],
                            Role = row["Emp_Job_Role"],
                            Reporting = row["Reporting"],
                            Shift = row["Shift_Type_Name"],
                            LoginTime = row["Login_Time"],
                            Theme = row["Theme"],
                            OperationId = row["Operation_Id"]
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

        [HttpPost]
        [ActionName("OrdersCount")]
        public IHttpActionResult Processing_Order_Count(dynamic data)
        {
            if (data == null) return BadRequest();
            try
            {
                var dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(data));
                DataTable dt = DbExecute.GetMultipleRecordByParam("Usp_Order_Processing_Scoreboard", dictionary);
                if (dt != null && dt.Rows.Count > 0)
                {
                    var ordersCount = new
                    {
                        LiveOrders = dt.Rows[0]["L_Order_Count"],
                        ReworkOrders = dt.Rows[0]["R_Order_Count"],
                        SuperQcOrders = dt.Rows[0]["S_Order_Count"]
                    };
                    return Ok(ordersCount);
                }
                else
                {
                    var ordersCount = new
                    {
                        LiveOrders = 0,
                        ReworkOrders = 0,
                        SuperQcOrders = 0
                    };
                    return Ok(ordersCount);
                }
            }
            catch (HttpResponseException ex)
            {
                return StatusCode(ex.Response.StatusCode);
            }

        }
        [HttpPost]
        [ActionName("UpdateLoginDate")]
        public IHttpActionResult UpdateLoginDate(dynamic data)
        {
            if (data == null) return BadRequest();
            try
            {
                var dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(data));
                var val = DbExecute.ExecuteSPForCRUD("Sp_User", dictionary);
                return Ok(val);
            }
            catch (HttpResponseException e) { return StatusCode(e.Response.StatusCode); }
        }
        #region Idle Time
        [HttpPost]
        [ActionName("TimeDifference")]
        public IHttpActionResult TimeDifference(dynamic data)
        {
            if (data == null) return BadRequest();
            try
            {
                var dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(data));
                DataTable dt = DbExecute.GetMultipleRecordByParam("Sp_User_Order_Ideal_Timings", dictionary);
                return Ok(dt);
            }
            catch (HttpResponseException e) { return StatusCode(e.Response.StatusCode); }
        }
        [HttpPost]
        [ActionName("GetMaxIdleTimeId")]
        public IHttpActionResult GetMaxIdleTimeId(dynamic data)
        {
            if (data == null) return BadRequest();
            try
            {
                var dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(data));
                DataTable dt = DbExecute.GetMultipleRecordByParam("Sp_User_Order_Ideal_Timings", dictionary);
                return Ok(dt);
            }
            catch (HttpResponseException e) { return StatusCode(e.Response.StatusCode); }
        }
        [HttpPost]
        [ActionName("InsertIdleTime")]
        public IHttpActionResult InsertIdleTime(dynamic data)
        {
            if (data == null) return BadRequest();
            try
            {
                var dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(data));
                var val = DbExecute.ExecuteSPForScalar("Sp_User_Order_Ideal_Timings", dictionary);
                return Ok(val);
            }
            catch (HttpResponseException e) { return StatusCode(e.Response.StatusCode); }
        }
        [HttpPost]
        [ActionName("UpdateIdleTime")]
        public IHttpActionResult UpdateIdleTime(dynamic data)
        {
            if (data == null) return BadRequest();
            try
            {
                var dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(data));
                var val = DbExecute.ExecuteSPForCRUD("Sp_User_Order_Ideal_Timings", dictionary);
                return Ok(val);
            }
            catch (HttpResponseException e) { return StatusCode(e.Response.StatusCode); }
        }
        #endregion
        #region Production Time        
        [HttpPost]
        [ActionName("ProductionTimeDifference")]
        public IHttpActionResult ProductionTimeDifference(dynamic data)
        {
            if (data == null) return BadRequest();
            try
            {
                var dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(data));
                DataTable dt = DbExecute.GetMultipleRecordByParam("Sp_User_Production_Timing", dictionary);
                return Ok(dt);
            }
            catch (HttpResponseException e) { return StatusCode(e.Response.StatusCode); }
        }
        [HttpPost]
        [ActionName("GetMaxProductionTimeId")]
        public IHttpActionResult GetMaxProdTimeId(dynamic data)
        {
            if (data == null) return BadRequest();
            try
            {
                var dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(data));
                DataTable dt = DbExecute.GetMultipleRecordByParam("Sp_User_Production_Timing", dictionary);
                return Ok(dt);
            }
            catch (HttpResponseException e) { return StatusCode(e.Response.StatusCode); }
        }
        [HttpPost]
        [ActionName("InsertProductionTime")]
        public IHttpActionResult InsertProductionTime(dynamic data)
        {
            if (data == null) return BadRequest();
            try
            {
                var dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(data));
                var val = DbExecute.ExecuteSPForScalar("Sp_User_Production_Timing", dictionary);
                return Ok(val);
            }
            catch (HttpResponseException e) { return StatusCode(e.Response.StatusCode); }
        }
        [HttpPost]
        [ActionName("UpdateProductionTime")]
        public IHttpActionResult UpdateProductionTime(dynamic data)
        {
            if (data == null) return BadRequest();
            try
            {
                var dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(data));
                var val = DbExecute.ExecuteSPForCRUD("Sp_User_Production_Timing", dictionary);
                return Ok(val);
            }
            catch (HttpResponseException e) { return StatusCode(e.Response.StatusCode); }
        }
        #endregion
    }
}

