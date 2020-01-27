using Newtonsoft.Json;
using OrderManagement_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OrderManagement_Api.Controllers.Order
{
    public class EmailSettingsController : ApiController
    {
        [HttpPost]
        [ActionName("BindData")]
        public IHttpActionResult GetEmailDetails(dynamic data)
        {
            if (data == null) return BadRequest("Not Found");
            try
            {
                var value = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(data));
                var dt = DbExecute.GetMultipleRecordByParam("Sp_EmailVerify", value);
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
        public IHttpActionResult EmailInsert(dynamic data)
        {
            if (data == null) return BadRequest("Not Found");
            try
            {
                var value = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(data));
                var dt = Convert.ToInt32(DbExecute.ExecuteSPForScalar("Sp_EmailVerify", value));
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

        [HttpPut]
        [ActionName("Update")]
        public IHttpActionResult EmailUpdate(dynamic data)
        {
            if (data == null) return BadRequest("Not Found");
            try
            {
                var value = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(data));
                var dt = Convert.ToInt32(DbExecute.ExecuteSPForScalar("Sp_EmailVerify", value));
                if (dt != null )
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
        [ActionName("Check")]
        public IHttpActionResult CheckEmailDetails(dynamic data)
        {
            if (data == null) return BadRequest("Not Found");
            try
            {
                var value = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(data));
                var dt = DbExecute.GetMultipleRecordByParam("Sp_EmailVerify", value);
                if (dt != null)
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
        [ActionName("Select")]
        public IHttpActionResult GetEmailRecords(dynamic data)
        {
            if (data == null) return BadRequest("Not Found");
            try
            {
                var value = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(data));
                var dt = DbExecute.GetMultipleRecordByParam("Sp_EmailVerify", value);
                if (dt != null)
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
        [ActionName("Delete")]
        public IHttpActionResult DeleteSelectedEmail(dynamic data)
        {
            if (data == null) return BadRequest("Not Found");
            try
            {
                var value = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(data));
                var dt = DbExecute.GetMultipleRecordByParam("Sp_EmailVerify", value);
                if (dt !=null)
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
