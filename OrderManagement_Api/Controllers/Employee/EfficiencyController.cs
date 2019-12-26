using Newtonsoft.Json;
using OrderManagement_Api.Models;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;

namespace OrderManagement_Api.Controllers.Employee
{
    public class EfficiencyController : ApiController
    {
        [HttpPost]
        [ActionName("EfficiencySummary")]
        public IHttpActionResult GetEfficiency(dynamic data)
        {
            if (data == null) return BadRequest();
            try
            {
                var dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(data));
                DataTable dt = DbExecute.GetMultipleRecordByParam("Sp_Score_Board_Updated", dictionary);
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
        [ActionName("CompletedOrders")]
        public IHttpActionResult GetCompletedOrders(dynamic data)
        {
            if (data == null) return BadRequest();
            try
            {
                CreateTempTable();

                var dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(data));
                DataTable dt = DbExecute.GetMultipleRecordByParam("Sp_Employee_Production_Score_Board", dictionary);
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

        [NonAction]
        public IHttpActionResult CreateTempTable()
        {

            try
            {
                Dictionary<string, object> dict = new Dictionary<string, object>();
                dict.Add("@Trans", "CREATE_TEMP_TABLE");
                 DataTable dt = DbExecute.GetMultipleRecordByParam("Sp_Employee_Production_Score_Board", dict);
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
