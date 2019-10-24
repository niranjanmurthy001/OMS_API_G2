using Newtonsoft.Json;
using OrderManagement_Api.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OrderManagement_Api.Controllers.Employee
{
    public class AccuracyController : ApiController
    {
        [HttpPost]
        [ActionName("AccuracySummary")]
        public HttpResponseMessage Post(dynamic data)
        {
            try
            {
                var dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(data));
                DataTable dt = DbExecute.GetMultipleRecordByParam("Sp_Accuracy_Details", dictionary);
                if (dt != null && dt.Rows.Count > 0)
                {
                    var accuracyList = dt.AsEnumerable().Select(row => new
                    {
                        Date = row["Date"],
                        CompletedOrders = row["No_of_Completed_orders"],
                        Errors = row["No_Of_Errors"],
                        Accuracy = row["Accuracy"]
                    }).ToList();
                    return Request.CreateResponse(HttpStatusCode.OK, accuracyList);
                }
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            catch (HttpResponseException e)
            {
                return Request.CreateResponse(e.Response.StatusCode);
            }
        }
        [HttpPost]
        [ActionName("CompletedOrders")]
        public HttpResponseMessage AccuracyDetails(dynamic data)
        {
            try
            {
                var dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(data));
                DataTable dt = DbExecute.GetMultipleRecordByParam("Sp_Employee_Production_Score_Board", dictionary);
                if (dt != null && dt.Rows.Count > 0)
                {
                    var completedOrdersList = dt.AsEnumerable().Select(row => new
                    {
                        Client_Order_Number = row["Client_Order_Number"],
                        Client_Number = row["Client_Number"],
                        Subprocess_Number = row["Subprocess_Number"],
                        Date = row["Date"],
                        Order_Type = row["Order_Type"],
                        Order_Source_Type_Name = row["Order_Source_Type_Name"],
                        Order_Type_Abrivation = row["Order_Type_Abrivation"],
                        Borrower_Name = row["Borrower_Name"],
                        Address = row["Address"],
                        Client_Order_Ref = row["Client_Order_Ref"],
                        County_Type = row["County_Type"],
                        State = row["State"],
                        County = row["County"],
                        Order_Status = row["Order_Status"],
                        Progress_Status = row["Progress_Status"],
                        Employee_Name = row["Employee_Name"],
                        Shift_Type_Name = row["Shift_Type_Name"],
                        Order_Production_Date = row["Order_Production_Date"],
                        Order_ID = row["Order_ID"],
                        Branch_Name = row["Branch_Name"],
                        Reporting_To_1 = row["Reporting_To_1"],
                        Reporting_To_2 = row["Reporting_To_2"]
                    }).ToList();
                    return Request.CreateResponse(HttpStatusCode.OK, completedOrdersList);
                }
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            catch (HttpResponseException e)
            {
                return Request.CreateResponse(e.Response.StatusCode);
            }
        }
        [HttpPost]
        [ActionName("UpdateTempTable")]
        public HttpResponseMessage UpdateTempTable(dynamic data)
        {
            try
            {
                var dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(data));
                DataTable dt = DbExecute.GetMultipleRecordByParam("Sp_Employee_Production_Score_Board", dictionary);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (HttpResponseException e)
            {
                return Request.CreateResponse(e.Response.StatusCode);
            }
        }
        [HttpPost]
        [ActionName("Errors")]
        public HttpResponseMessage ErrorDetails(dynamic data)
        {
            try
            {
                var dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(data));
                DataTable dt = DbExecute.GetMultipleRecordByParam("Sp_Accuracy_Details", dictionary);
                if (dt != null && dt.Rows.Count > 0)
                {
                    var errorsList = dt.AsEnumerable().Select(row => new
                    {
                        Client_Order_Number = row["Client_Order_Number"],
                        Work_Type = row["Work_Type"],
                        New_Error_Type = row["New_Error_Type"],
                        Error_Type = row["Error_Type"],
                        Error_description = row["Error_description"],
                        Comments = row["Comments"],
                        Error_On_Task = row["Error_On_Task"],
                        Error_On_User_Name = row["Error_On_User_Name"],
                        Error_Entered_From_Task = row["Error_Entered_From_Task"],
                        Error_Entered_From = row["Error_Entered_From"],
                        Entered_Date = row["Entered_Date"],
                        Error_Entered_Task_From_Id = row["Error_Entered_Task_From_Id"],
                        Error_Entered_From_User_Id = row["Error_Entered_From_User_Id"],
                        ErrorInfo_ID = row["ErrorInfo_ID"],
                        Order_Id = row["Order_Id"],
                        Branch_Name = row["Branch_Name"],
                        Reporting_1 = row["Reporting_1"],
                        Reporting_2 = row["Reporting_2"],
                        Production_Date = row["Production_Date"]
                    }).ToList();
                    return Request.CreateResponse(HttpStatusCode.OK, errorsList);
                }
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            catch (HttpResponseException e)
            {
                return Request.CreateResponse(e.Response.StatusCode);
            }
        }
    }
}
