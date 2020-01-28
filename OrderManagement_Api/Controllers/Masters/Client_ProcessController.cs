using Newtonsoft.Json;
using OrderManagement_Api.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace OrderManagement_Api.Controllers.Masters
{
    public class Client_ProcessController : ApiController
    {
        [HttpPost]
        [ActionName("BindData")]
        public IHttpActionResult GetClientData(dynamic data)
        {
            if (data == null) return BadRequest("Not Found");
            try
            {
                var value = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(data));
                var dt = DbExecute.GetMultipleRecordByParam("usp_Master_Client_Process", value);
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
        [ActionName("Insert")]
        public IHttpActionResult ClientInsert(dynamic data)
        {
            if (data == null) return BadRequest("Not Found");
            try
            {
                var value = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(data));
                var dt = Convert.ToInt32(DbExecute.ExecuteSPForCRUD("usp_Master_Client_Process", value));
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
