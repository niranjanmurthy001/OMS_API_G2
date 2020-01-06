using Newtonsoft.Json;
using OrderManagement_Api.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace OrderManagement_Api.Controllers.Master
{
    public class Order_Check_ListController : ApiController
    {

        [HttpPost]
        [ActionName("OrderCheckList")]
        public IHttpActionResult Orderchecklist(dynamic data)
        {
            if (data == null) return NotFound();
            try
            {
                var value = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(data));
                var dt = DbExecute.GetMultipleRecordByParam("SP_Checklist_Detail_Report", value);
                if(dt!=null && dt.Rows.Count > 0)
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
