using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FreelancerWebAPI.BAL;
using FreelancerWebAPI.Models;


namespace FreelancerWebAPI.Controllers
{
    public class UserController : ApiController
    {
        #region Variable 
        HttpResponseMessage response;
        UserBAL userBL;
        #endregion
        # region Public Method  
        ///<summary>  
        /// This method is used to get User list  
        ///</summary>  
        ///<returns></returns>  
        [HttpGet, ActionName("GetUserList")]
        public HttpResponseMessage GetUserList()
        {
            Skillset result;
            userBL = new UserBAL();
            try
            {
                var userList = userBL.GetUserList();
                if (!object.Equals(userList, null))
                {
                    response = Request.CreateResponse<List<Users>>(HttpStatusCode.OK, userList);
                }
            }
            catch (Exception ex)
            {
                result = new Skillset();
                result.Status = 0;
                result.Message = ex.Message;
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, result);
            }
            return response;
        }
        /// This method is used to get User list by id  
        ///</summary>  
        ///<returns></returns>  
        [HttpGet, ActionName("GetUserInfoById")]
        public HttpResponseMessage GetUserInfoById(int userId)
        {
            Skillset result;
            userBL = new UserBAL();
            try
            {
                var userList = userBL.GetUserDetailsById(userId);
                if (!object.Equals(userList, null))
                {
                    response = Request.CreateResponse<List<Users>>(HttpStatusCode.OK, userList);
                }
            }
            catch (Exception ex)
            {
                result = new Skillset();
                result.Status = 0;
                result.Message = ex.Message;
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, result);
            }
            return response;
        }

        /// This method is used to get User list by id  
        ///</summary>  
        ///<returns></returns>  
        [HttpGet, ActionName("GetUserInfoByUserName")]
        public HttpResponseMessage GetUserInfoByUserName(string userName,string eMail)
        {
            Skillset result;
            userBL = new UserBAL();
            try
            {
                var userList = userBL.GetUserInfoByUserName(userName,eMail);
                if (!object.Equals(userList, null))
                {
                    response = Request.CreateResponse<List<Users>>(HttpStatusCode.OK, userList);
                }
            }
            catch (Exception ex)
            {
                result = new Skillset();
                result.Status = 0;
                result.Message = ex.Message;
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, result);
            }
            return response;
        }

        ///<summary>  
        /// This method is used to add user info in the database.  
        ///</summary>  
        ///<returns></returns>  
        [HttpPost, ActionName("AddUserInfo")]
        public HttpResponseMessage AddUserInfo(Users user)
        {
            Skillset ObjResult;
            int result;
            userBL = new UserBAL();
            try
            {
                result = userBL.AddUserInfo(user);
                if (result > 0)
                {
                   
                        ObjResult = new Skillset();
                        ObjResult.Status = result;
                        ObjResult.Message = "Record Inserted Successfully!!";
                        response = Request.CreateResponse<Skillset>(HttpStatusCode.OK, ObjResult);
                }  
            else {
                    ObjResult = new Skillset();
                    ObjResult.Status = result;
                    ObjResult.Message = "Record Not Added!!";
                    response = Request.CreateResponse<Skillset>(HttpStatusCode.OK, ObjResult);
                }
            }
            catch (Exception ex)
            {
                ObjResult = new Skillset();
                ObjResult.Status = 0;
                ObjResult.Message = ex.Message;
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ObjResult);
            }
            return response;
        }

        ///<summary>  
        /// This method is used to update user info in the database.  
        ///</summary>  
        ///<returns></returns>  
        [HttpPut, ActionName("UpdateUserInfo")]
        public HttpResponseMessage UpdateUserInfo(Users user)
        {
            Skillset ObjResult;
            int result;
            userBL = new UserBAL();
            try
            {
                result = userBL.UpdateUserInfo(user);
                if (result > 0)
                {

                    ObjResult = new Skillset();
                    ObjResult.Status = result;
                    ObjResult.Message = "Record Updated Successfully!!";
                    response = Request.CreateResponse<Skillset>(HttpStatusCode.OK, ObjResult);
                }
                else
                {
                    ObjResult = new Skillset();
                    ObjResult.Status = result;
                    ObjResult.Message = "Record Not Updated!!";
                    response = Request.CreateResponse<Skillset>(HttpStatusCode.OK, ObjResult);
                }
            }
            catch (Exception ex)
            {
                ObjResult = new Skillset();
                ObjResult.Status = 0;
                ObjResult.Message = ex.Message;
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ObjResult);
            }
            return response;
        }

        ///<summary>  
        /// This method is used to delete the cricketer info  
        ///</summary>  
        ///<param name="CricketerId"></param>  
        ///<returns></returns>  
        [HttpDelete, ActionName("DeleteUserInfo")]
        public HttpResponseMessage DeleteUserInfo(int userId)
        {
            Skillset ObjResult;
            int result;
            userBL = new UserBAL();

            try
            {
                Users user = new Users();
                user.UserId = userId;

                result = userBL.DeleteUserInfo(user);
                if (result > 0)
                {
                    if (result == 2)
                    {
                        ObjResult = new Skillset();
                        ObjResult.Status = result;
                        ObjResult.Message = "Record Deleted Successfully!!";
                        response = Request.CreateResponse<Skillset>(HttpStatusCode.OK, ObjResult);
                    }
                    else 
                    {
                        ObjResult = new Skillset();
                        ObjResult.Status = result;
                        ObjResult.Message = "Record not found!!";
                        response = Request.CreateResponse<Skillset>(HttpStatusCode.NotFound, ObjResult);
                    }
                  
                }
            }
            catch (Exception ex)
            {
                ObjResult = new Skillset();
                ObjResult.Status = 0;
                ObjResult.Message = ex.Message;
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ObjResult);
            }
            return response;
        }

        #endregion
    }
}
