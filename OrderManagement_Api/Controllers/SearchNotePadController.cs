using Newtonsoft.Json;
using OrderManagement_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OrderManagement_Api.Controllers
{
    public class SearchNotePadController : ApiController
    {
        [HttpPost]
        [ActionName("Bind")]
        public IHttpActionResult BindData(dynamic data)
        {
            if (data == null) return BadRequest("Not Found");
            try
            {
                var value = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(data));
                var dt = DbExecute.GetMultipleRecordByParam("Sp_Order_Search_Note_Pad", value);
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
        [ActionName("Create")]
        public IHttpActionResult InsertData(dynamic data)
        {
            if (data == null) return BadRequest("Please Provide the Valid Details ");
            try
            {
                var item = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(data));
                int dt = Convert.ToInt32(DbExecute.ExecuteSPForCRUD("Sp_Document_Upload", item));
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
        [HttpPost]
        [ActionName("Load")]
        public IHttpActionResult LoadData(dynamic data)
        {
            if (data == null) return BadRequest("Records Not Found");
            try
            {
                var value = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(data));
                var dt = DbExecute.GetMultipleRecordByParam("Sp_Order", value);
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
        [ActionName("DataBind")]
        public IHttpActionResult BindMultipleData(dynamic data)
        {
            if (data == null) return BadRequest("Not Found");
            try
            {
                var value = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(data));
                var dt = DbExecute.GetMultipleRecordByParam("Sp_Order_Search_Note_Pad", value);
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
        [ActionName("Check")]
        public IHttpActionResult CheckData(dynamic data)
        {
            if (data == null) return BadRequest("Not Found");
            try
            {
                var value = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(data));
                var dt = DbExecute.GetMultipleRecordByParam("Sp_Order_Search_Note_Pad", value);
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
        [ActionName("Get")]
        public IHttpActionResult GetLastUpdatedOrderRecord(dynamic data)
        {
            if (data == null) return BadRequest("Not Found");
            try
            {
                var value = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(data));
                var dt = DbExecute.GetMultipleRecordByParam("Sp_Order_Search_Note_Pad", value);
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
        [ActionName("Insert")]
        public IHttpActionResult SearchNotePadInsertData(dynamic data)
        {
            if (data == null) return BadRequest("Please Provide the Valid Details ");
            try
            {
                var item = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(data));
                int dt = Convert.ToInt32(DbExecute.ExecuteSPForCRUD("Sp_Order_Search_Note_Pad", item));
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
        public IHttpActionResult SearchNotePadUpdateData(dynamic data)
        {
            if (data == null) return BadRequest("Please Provide the Valid Details ");
            try
            {
                var item = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(data));
                int dt = Convert.ToInt32(DbExecute.ExecuteSPForCRUD("Sp_Order_Search_Note_Pad", item));
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
