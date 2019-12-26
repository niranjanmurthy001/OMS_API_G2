using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using OrderManagement_Api.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OrderManagement_Api.Controllers.Comment
{
    public class CommentController : ApiController
    {
        [HttpPost]
        [ActionName("Ordercomment")]
        public IHttpActionResult Ordercomment(dynamic data)
        {
            if (data == null) return BadRequest("Not Found");
            try
            {
                var value = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(data));               
                DataTable dt = DbExecute.GetMultipleRecordByParam("usp_Order_Comments", value);              
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
    }
}
