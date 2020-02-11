using Newtonsoft.Json;
using OrderManagement_Api.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace OrderManagement_Api.Controllers.Dashboard
{
    public class ProcessingOrdersController : ApiController
    {
        [HttpPost]
        [ActionName("Processing_Order_Count")]
        public HttpResponseMessage Processing_Order_Count(dynamic Obj)
        {
            try
            {
                var List = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(Obj));

                DataTable dt = DbExecute.GetMultipleRecordByParam("Usp_Order_Processing_Scoreboard", List);

                if (dt != null && dt.Rows.Count > 0)
                {

                    var Order_Count_List = dt.AsEnumerable().Select(row => new
                    {
                        Live_Order_Count = row["L_Order_Count"],
                        Rework_Order_Count = row["R_Order_Count"],
                        Super_Qc_Order_Count = row["S_Order_Count"]
                        //Test_Order_Count= row["Test_Order_Count"]
                    }).ToList();

                    return Request.CreateResponse(HttpStatusCode.OK, Order_Count_List.ToList(), Configuration.Formatters.JsonFormatter);
                }
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            catch (HttpResponseException ex)
            {
                return Request.CreateResponse(ex.Response.StatusCode);
            }

        }

        [HttpPost]
        [ActionName("Work_Type_Wise_Count")]

        public HttpResponseMessage Work_Order_Count(dynamic Obj)
        {
            try
            {
                var List = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(Obj));

                DataTable dt = DbExecute.GetMultipleRecordByParam("Usp_Order_Processing_Scoreboard", List);

                if (dt != null && dt.Rows.Count > 0)
                {
                    var Work_Type_Count_List = dt.AsEnumerable().Select(row =>
                      new
                      {
                          Search = row["Search"],
                          Search_Qc = row["Search_Qc"],
                          Typing = row["Typing"],
                          Typing_Qc = row["Typing_Qc"],
                          Final_Qc = row["Final_Qc"],
                          Exception = row["Exception"],
                          Upload=row["Upload"]

                          
                      }
                    ).ToList();

                    return Request.CreateResponse(HttpStatusCode.OK, Work_Type_Count_List, Configuration.Formatters.JsonFormatter);
                }
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            catch (HttpResponseException ex)
            {
                return Request.CreateResponse(ex.Response.StatusCode);
            }

        }

        [HttpPost]
        [ActionName("Processing_Orders")]
        public HttpResponseMessage Processing_Orders_Details(dynamic Obj)
        {
            try
            {
                var List = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(Obj));
                DataTable dt = DbExecute.GetMultipleRecordByParam("Usp_Order_Processing_Queue", List);

                if (dt != null && dt.Rows.Count > 0)
                {
                    var Processing_Order_List = dt.AsEnumerable().Select(row =>
                      new
                      {
                          Serial_No =row["Serial_No"],
                          Order_ID = row["Order_ID"],
                          Order_Progress_ID = row["Order_Progress_ID"],
                          Client_Order_Number = row["Client_Order_Number"],
                          Order_Number = row["Order_Number"],
                          Order_Type = row["Order_Type"],
                          Order_Status = row["Order_Status"],
                          Progress_Status = row["Progress_Status"],
                          State = row["State"],
                          County = row["County"],
                          Date = row["Date"],
                          Assigned_Date = row["Assigned_Date"],
                          Assigend_Date_In_Time = row["Assigend_Date_In_Time"],
                          Sub_ProcessName = row["Sub_ProcessName"],
                          Subprocess_Number = row["Subprocess_Number"],
                          Client_Name = row["Client_Name"],
                          Client_Number = row["Client_Number"],
                          Employee_Name = row["Employee_Name"],
                          Allocated_Time = row["Allocated_Time"],
                          Allocatd_Time_In_Minutes = row["Allocatd_Time_In_Minutes"],
                          Expidate = row["Expidate"],
                          Target_Time = row["Target_Time"],
                          Tax_Task_Status = row["Tax_Task_Status"],
                          Client_Id = row["Client_Id"],
                          Subprocess_Id = row["Subprocess_Id"],
                          State_Id = row["State_ID"],
                          County_Id = row["County_Id"],
                          Order_Type_Id = row["Order_Type_ID"],
                          OrderType_ABS_Id = row["OrderType_ABS_Id"],
                          Address = row["Address"],
                          Order_Status_ID = row["Order_Status_ID"],
                          OrderStatus = row["Order_Status"]
                      }

                    ).ToList();
                    return Request.CreateResponse(HttpStatusCode.OK, Processing_Order_List, Configuration.Formatters.JsonFormatter);
                }
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            catch (HttpResponseException ex)
            {
                return Request.CreateResponse(ex.Response.StatusCode);
            }
        }

        [HttpPost]
        [ActionName("Get_CheckList_Address")]
        public IHttpActionResult CheckDuplicateAddress(dynamic data)
        {
            if (data == null) return BadRequest();
            try
            {
                Dictionary<string, Dictionary<string, object>> dictionary = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, object>>>(JsonConvert.SerializeObject(data));
                List<string> keys = dictionary.Keys.ToList();
                DataTable dtAddress = DbExecute.GetMultipleRecordByParam(keys[0], dictionary[keys[0]]);
                DataTable dtCheckList = DbExecute.GetMultipleRecordByParam(keys[1], dictionary[keys[1]]);
                if (dtAddress != null && dtCheckList != null)
                {
                    DataSet dtSet = new DataSet();
                    dtSet.Tables.AddRange(new DataTable[] { dtAddress, dtCheckList });
                    return Ok(dtSet);
                }
                return NotFound();
            }
            catch (HttpResponseException ex)
            {
                return StatusCode(ex.Response.StatusCode);
            }
        }

        [HttpPost]
        [ActionName("TimeTrack")]
        public IHttpActionResult GetMaxTimeId(dynamic data)
        {
            if (data == null) return BadRequest();
            try
            {
                //var dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(data));
                Dictionary<string, Dictionary<string, object>> dictionary = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, object>>>(JsonConvert.SerializeObject(data));
                List<string> keys = dictionary.Keys.ToList();
                int result = Convert.ToInt32(DbExecute.ExecuteSPForScalar(keys[0], dictionary[keys[0]]));
                if (result > 0)
                {
                    return Ok(result);
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

        [HttpPost]
        [ActionName("UpdateProgress")]
        public IHttpActionResult UpdateProgress(dynamic data)
        {
            if (data == null) return BadRequest();
            try
            {
                Dictionary<string, Dictionary<string, object>> dictionary = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, object>>>(JsonConvert.SerializeObject(data));
                List<string> keys = dictionary.Keys.ToList();
                int result = DbExecute.ExecuteSPForCRUD(keys[0], dictionary[keys[0]]);
                if (result > 0)
                {
                    return Ok(result);
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
        [HttpPost]
        [ActionName("UpdateAssignment")]
        public IHttpActionResult UpdateAssignment(dynamic data)
        {
            if (data == null) return BadRequest();
            try
            {
                Dictionary<string, Dictionary<string, object>> dictionary = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, object>>>(JsonConvert.SerializeObject(data));
                List<string> keys = dictionary.Keys.ToList();
                int result = DbExecute.ExecuteSPForCRUD(keys[0], dictionary[keys[0]]);
                if (result > 0)
                {
                    return Ok(result);
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

