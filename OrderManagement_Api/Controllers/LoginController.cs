using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OrderManagement_Api.ModelsRespository.IRepository;
using OrderManagement_Api.Models;
using OrderManagement_Api.ModelsRespository.Repository;

using System.Data;

namespace OrderManagement_Api.Controllers
{
    public class LoginController : ApiController
    {
        IUser Iuser_reportory = new RUser();
        string _User_Name, _Confirm_User_Name, _Confirm_Password, _Password, _Employee_Name, _Employee_Type,_Image_File_Name;
        int _User_Id, _Branch_Id, _User_Role_Id, _Application_Login_Id ,_ShiftType;


        //[HttpPost]
        //[ActionName("Validate_User")]
        //public Tuple<int,string, List<Users>> post(Users _User)
        //{
        //    return Iuser_reportory.Validate_User(_User);
        //}

        [HttpPost]
        [ActionName("Validate_User")]

        public HttpResponseMessage Post(Users obj_User)
        {
            int _Error = 0;
            string _Error_Message = "";
            List<Users> li_Result = new List<Users>();
            try
            {
                var list_User_Count = new Dictionary<string, object>();
                DataTable dt_User_Count = new DataTable();
                list_User_Count.Add("@Trans", "GET_USER_BY_EMP_CODE");
                list_User_Count.Add("@DRN_Emp_Code", obj_User.DRN_Emp_Code);
                dt_User_Count = DbExecute.GetMultipleRecordByParam("Sp_User", list_User_Count);
                if (dt_User_Count.Rows.Count > 0)
                {
                    if (string.IsNullOrEmpty(dt_User_Count.Rows[0]["DRN_Emp_Code"].ToString().ToUpper()))
                    {
                        _Error = 0;
                        _Error_Message = "User Name Does Not Exist";
                        return Request.CreateResponse(HttpStatusCode.OK, new { _Error = _Error, _Error_Message = _Error_Message, Users = li_Result }, Configuration.Formatters.JsonFormatter);
                    }
                    else
                    {
                        _User_Name = obj_User.DRN_Emp_Code.ToString().ToUpper();
                        _Password = obj_User.Password.Trim();
                        _Confirm_User_Name = dt_User_Count.Rows[0]["DRN_Emp_Code"].ToString().ToUpper();
                        _Confirm_Password = dt_User_Count.Rows[0]["Password"].ToString();
                        _Employee_Name = dt_User_Count.Rows[0]["Employee_Name"].ToString();
                        _User_Id = int.Parse(dt_User_Count.Rows[0]["User_id"].ToString());
                        _Branch_Id = int.Parse(dt_User_Count.Rows[0]["Branch_ID"].ToString());
                        _User_Role_Id = int.Parse(dt_User_Count.Rows[0]["User_RoleId"].ToString());
                        _Application_Login_Id = int.Parse(dt_User_Count.Rows[0]["Application_Login_Type"].ToString());
                        _Image_File_Name = dt_User_Count.Rows[0]["Image_File_Name"].ToString();
                        _Employee_Type = dt_User_Count.Rows[0]["Employee_Type"].ToString();
                        _ShiftType= int.Parse(dt_User_Count.Rows[0]["Shift_Type_Id"].ToString());

                    }
                }
                if (dt_User_Count.Rows.Count > 0 && _Confirm_User_Name == _User_Name && _Confirm_Password == _Password)
                {
                    li_Result.Add(new Users() { User_id = _User_Id, Branch_ID=_Branch_Id, User_Name = _Confirm_User_Name, Employee_Name = _Employee_Name, DRN_Emp_Code = _Confirm_User_Name, User_RoleId = _User_Role_Id, Shift_Type_Id=_ShiftType, Application_Login_Type = _Application_Login_Id, Employee_Type=_Employee_Type, Image_File_Name=_Image_File_Name });
                    _Error = 0;
                    _Error_Message = "Valid User";
                    return Request.CreateResponse(HttpStatusCode.OK, new { _Error = _Error, _Error_Message = _Error_Message, Users = li_Result }, Configuration.Formatters.JsonFormatter);
                }
                else
                {
                    _Error = 1;
                    _Error_Message = "Wrong User Name and Password";
                    return Request.CreateResponse(HttpStatusCode.OK, new { _Error = _Error, _Error_Message = _Error_Message, Users = li_Result }, Configuration.Formatters.JsonFormatter);
                }
            }
            catch (Exception ex)
            {
                _Error = 1;
                _Error_Message = "Exception";
                return Request.CreateResponse(HttpStatusCode.OK, new { _Error = _Error, _Error_Message = _Error_Message, Users = li_Result }, Configuration.Formatters.JsonFormatter);
            }
        }
    }
}
