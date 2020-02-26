using Newtonsoft.Json;
using OrderManagement_Api.Models;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;

namespace OrderManagement_Api.Controllers.Masters
{
    public class MasterController : ApiController
    {
        [HttpPost]
        [ActionName("BindClients")]
        public IHttpActionResult BindClients(dynamic data)
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
        [ActionName("BindSubClients")]
        public IHttpActionResult SubClients(dynamic data)
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
        [HttpPost]
        [ActionName("BindDeptType")]
        public IHttpActionResult Departmenttype(dynamic data)
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
        [HttpGet]
        [ActionName("ProcessSettings")]
        public IHttpActionResult GetProcessSettings()
        {
            try
            {
                DataTable processSettings = DbExecute.GetMultipleRecordByParam("usp_Master_Client_Process", new Dictionary<string, object>() { { "@Trans", "SELECT_PROCESS" } });
                if (processSettings != null && processSettings.Rows.Count > 0)
                    return Ok(processSettings);
                return NotFound();
            }
            catch (HttpResponseException ex)
            {
                return StatusCode(ex.Response.StatusCode);
            }
        }
        [HttpGet]
        [ActionName("States")]
        public IHttpActionResult GetStates()
        {
            try
            {
                DataTable dtStates = DbExecute.GetMultipleRecordByParam("usp_Master_Client_Process", new Dictionary<string, object>() { { "@Trans", "SELECT_STATE" } });
                if (dtStates != null && dtStates.Rows.Count > 0)
                    return Ok(dtStates);
                return NotFound();
            }
            catch (HttpResponseException ex)
            {
                return StatusCode(ex.Response.StatusCode);
            }
        }
        [HttpGet]
        [ActionName("Counties")]
        public IHttpActionResult GetCounties(int? id)
        {
            if (!id.HasValue) return BadRequest();
            try
            {
                var dictionary = new Dictionary<string, object>() {
                    { "@Trans", "SELECT_COUNTY" },
                    { "@State_Id",id }
                };
                DataTable dtCounties = DbExecute.GetMultipleRecordByParam("usp_Master_Client_Process", dictionary);
                if (dtCounties != null && dtCounties.Rows.Count > 0) return Ok(dtCounties);
                return NotFound();
            }
            catch (HttpResponseException ex)
            {
                return StatusCode(ex.Response.StatusCode);
            }
        }
    }
}
