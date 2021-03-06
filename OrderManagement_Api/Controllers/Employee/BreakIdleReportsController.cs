﻿using Newtonsoft.Json;
using OrderManagement_Api.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace OrderManagement_Api.Controllers.Master
{
    public class BreakIdleReportsController : ApiController
    {
        [HttpPost]
        [ActionName("BindBreakIdleReports")]
        public IHttpActionResult BreakIdleReports(dynamic data)
        {
            if (data == null) return BadRequest("Not Found");
            try
            {
                var value = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(data));
                var dt = DbExecute.GetMultipleRecordByParam("Sp_Production_Reports", value);
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
