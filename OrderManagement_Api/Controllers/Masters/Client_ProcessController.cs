using Newtonsoft.Json;
using OrderManagement_Api.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;

namespace OrderManagement_Api.Controllers.Masters
{
    public class Client_ProcessController : ApiController
    {
        SqlConnection con;
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
                var value = JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(data));
                using (con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[1].ConnectionString))
                {
                    con.Open();
                    using (SqlBulkCopy sqlbulk = new SqlBulkCopy(con))
                    {
                        sqlbulk.ColumnMappings.Add("Client", "Client");
                        sqlbulk.ColumnMappings.Add("Sub_Client", "Sub_Client");
                        sqlbulk.ColumnMappings.Add("Project_Type", "Project_Type");
                        sqlbulk.ColumnMappings.Add("Department_Type", "Department_Type");
                        sqlbulk.BulkCopyTimeout = 3000;
                        sqlbulk.BatchSize = 10000;
                        sqlbulk.DestinationTableName = "Tbl_Process_Settings";
                        sqlbulk.WriteToServer(value);
                        return Ok(value);
                    }
                }
                
            }
            catch (HttpResponseException ex)
            {
                return StatusCode(ex.Response.StatusCode);
            }
        }
    }
}
