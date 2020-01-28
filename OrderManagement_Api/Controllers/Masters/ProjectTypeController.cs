using Newtonsoft.Json;
using OrderManagement_Api.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace OrderManagement_Api.Controllers.Masters
{
    public class ProjectTypeController : ApiController
    {
        [HttpPost]
        [ActionName("BindProjectType")]
        public IHttpActionResult ProjectType(dynamic data)
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
    }
}
