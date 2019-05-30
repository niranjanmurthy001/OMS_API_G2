
using OrderManagement_Api.Models;
using OrderManagement_Api.ModelsRespository.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Net;
using System.Web.Http;
namespace OrderManagement_Api.ModelsRespository.Repository
{
    public class RUser : IUser
    {
        DbExecute _dbe = new DbExecute();
        int _Result_Count;
        string _Resukt_Message;
        string _User_Name, _Confirm_User_Name, _Confirm_Password, _Password, _Employee_Name;
        int _User_Id, _Branch_Id, _User_Role_Id, _Application_Login_Id;

        // Constructor
        public RUser()
        {

        }

        public Tuple<int,string, List<Users>> Validate_User(Users objUser)
        {
            List<Users> li_Result = new List<Users>();
            try
            {
            
                var list_User_Count = new Dictionary<string, object>();
                DataTable dt_User_Count = new DataTable();

                list_User_Count.Add("@Trans", "GET_USER_BY_EMP_CODE");
                list_User_Count.Add("@DRN_Emp_Code", objUser.DRN_Emp_Code);

                dt_User_Count = DbExecute.GetMultipleRecordByParam("Sp_User", list_User_Count);

                if (dt_User_Count.Rows.Count > 0)
                {
                    if (string.IsNullOrEmpty(dt_User_Count.Rows[0]["DRN_Emp_Code"].ToString().ToUpper()))
                    {

                        _Result_Count = 0;
                        _Resukt_Message = "User Name Does Not Exist";

                      

                        return new Tuple<int,string,List<Users>>(_Result_Count, _Resukt_Message,null);
                    }
                    else
                    {
                        _User_Name = objUser.DRN_Emp_Code;
                        _Password = objUser.Password;

                        _Confirm_User_Name = dt_User_Count.Rows[0]["DRN_Emp_Code"].ToString().ToUpper();
                        _Confirm_Password = dt_User_Count.Rows[0]["Password"].ToString();
                        _Employee_Name = dt_User_Count.Rows[0]["Employee_Name"].ToString();
                        _User_Id = int.Parse(dt_User_Count.Rows[0]["User_id"].ToString());
                        _Branch_Id = int.Parse(dt_User_Count.Rows[0]["Branch_ID"].ToString());
                        _User_Role_Id = int.Parse(dt_User_Count.Rows[0]["User_RoleId"].ToString());
                        _Application_Login_Id = int.Parse(dt_User_Count.Rows[0]["Application_Login_Type"].ToString());

                    }


                }


                if (dt_User_Count.Rows.Count > 0 && _Confirm_User_Name == _User_Name && _Confirm_Password == _Password)
                {

                 
                    li_Result.Add(new Users() {User_id=_User_Id,User_Name=_User_Name,User_RoleId=_User_Role_Id,Application_Login_Type=_Application_Login_Id });

                    _Result_Count = 1;
                    _Resukt_Message = "Valid User";

                    return new Tuple<int,string,List<Users>>(_Result_Count,_Resukt_Message, li_Result);
                }
                else
                {
                    _Result_Count = 0;
                    _Resukt_Message = "Wrong User Name and Password";
                    return new Tuple<int,string,List<Users>>(_Result_Count, _Resukt_Message, li_Result);
                }



            }
            catch (Exception ex)
            {
                _Result_Count = 0;
                _Resukt_Message = "Error";
                return new Tuple<int,string,List<Users>>(_Result_Count,_Resukt_Message, li_Result);

            }


        }

      




    }
}