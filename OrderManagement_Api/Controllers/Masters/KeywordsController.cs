using Newtonsoft.Json;
using OrderManagement_Api.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;

namespace OrderManagement_Api.Controllers.Masters
{
    public class KeywordsController : ApiController
    {
        [HttpGet]
        [ActionName("GetKeywords")]
        public IHttpActionResult GetKeywords()
        {
            var dictionary = new Dictionary<string, object>()
            {
                {"@Trans" , "SELECT" }
            };
            DataTable dtKeywords = DbExecute.GetMultipleRecordByParam("usp_Vendor_Keywords", dictionary);
            return Ok(dtKeywords);
        }
        [HttpPost]
        [ActionName("Add")]
        public IHttpActionResult AddKeywords(dynamic data)
        {
            if (data == null) return BadRequest();
            var dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(data));
            var id = DbExecute.ExecuteSPForScalar("usp_Vendor_Keywords", dictionary);
            if (Convert.ToInt32(id) > 0) return Ok();
            return NotFound();
        }
        [HttpPut]
        [ActionName("Update")]
        public IHttpActionResult UpdateKeywords(dynamic data)
        {
            if (data == null) return BadRequest();
            var dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(data));
            var count = DbExecute.ExecuteSPForCRUD("usp_Vendor_Keywords", dictionary);
            if (Convert.ToInt32(count) > 0) return Ok();
            return NotFound();
        }
        [HttpDelete]
        [ActionName("Delete")]
        public IHttpActionResult DeleteKeywords(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var dictionary = new Dictionary<string, object>()
            {
                {"@Trans","DELETE" },
                { "@KeywordId",id }
            };
            var count = DbExecute.ExecuteSPForCRUD("usp_Vendor_Keywords", dictionary);
            if (Convert.ToInt32(count) > 0) return Ok();
            return NotFound();
        }
    }
}
