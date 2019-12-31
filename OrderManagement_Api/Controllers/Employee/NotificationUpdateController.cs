using Newtonsoft.Json;
using OrderManagement_Api.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace OrderManagement_Api.Controllers.Employee
{
    public class NotificationUpdateController : ApiController
    {
        [HttpPost]
        [ActionName("Create")]
        public IHttpActionResult InsertData(dynamic data)
        {
            if (data == null) return BadRequest("Please Provide the Valid Details ");
            try
            {
                var item = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(data));
                int dt = Convert.ToInt32(DbExecute.ExecuteSPForCRUD("usp_Message_Notification_Update", item));
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
