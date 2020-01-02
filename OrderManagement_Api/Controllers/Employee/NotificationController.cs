using Newtonsoft.Json;
using OrderManagement_Api.Models;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;

namespace OrderManagement_Api.Controllers.Employee
{
    public class NotificationController : ApiController
    {
        [HttpPost]
        [ActionName("OrderNotification")]
        public IHttpActionResult Ordernotification(dynamic data)
        {
            if (data == null) return BadRequest("Not Found");
            try
            {
                var value = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(data));
                DataTable dt = DbExecute.GetMultipleRecordByParam("usp_Message_Notification", value);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return Ok(dt);
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
        [ActionName("Order_Notification")]
        public IHttpActionResult Order_Notification(dynamic data)
        {
            if (data == null) return BadRequest("Not Found");
            try
            {
                var value = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(data));
                DataTable dt = DbExecute.GetMultipleRecordByParam("usp_Message_Notification", value);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return Ok(dt);
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
        [ActionName("Count")]
        public IHttpActionResult Notification_Count(dynamic data)
        {
            if (data == null) return BadRequest("Not Found");
            try
            {
                var value = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(data));
                DataTable dt = DbExecute.GetMultipleRecordByParam("usp_Message_Notification", value);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return Ok(dt);
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
        [ActionName("Create")]
        public IHttpActionResult InsertData(dynamic data)
        {
            if (data == null) return BadRequest("Please Provide the Valid Details ");
            try
            {
                var item = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(data));
                int dt = System.Convert.ToInt32(DbExecute.ExecuteSPForCRUD("usp_Message_Notification", item));
                if (dt > 0)
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
