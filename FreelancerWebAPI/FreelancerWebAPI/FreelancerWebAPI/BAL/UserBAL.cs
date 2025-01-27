using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FreelancerWebAPI.Models;
using FreelancerWebAPI.DAL;

namespace FreelancerWebAPI.BAL
{
    public class UserBAL
    {
        ///<summary>  
        /// This method is used to get the User list  
        ///</summary>  
        ///<returns></returns>  
        public List<Users> GetUserList()
        {
            List<Users> ObjUsers = null;
            try
            {
                ObjUsers = new UserDAL().GetUserList();
            }
            catch (Exception)
            {
                throw;
            }
            return ObjUsers;
        }
        ///<summary>  
        /// This method is used to get Users details by User id    
        ///</summary>  
        ///<returns></returns>  
        public List<Users> GetUserDetailsById(int Id)
        {
            List<Users> ObjUserDetails = null;
            try
            {
                ObjUserDetails = new UserDAL().GetUserDetailsById(Id);
            }
            catch (Exception)
            {
                throw;
            }
            return ObjUserDetails;
        }

        ///<summary>  
        /// This method is used to get Users details by User id    
        ///</summary>  
        ///<returns></returns>  
        public List<Users> GetUserInfoByUserName(string userName,string email)
        {
            List<Users> ObjUserDetails = null;
            try
            {
                ObjUserDetails = new UserDAL().GetUserInfoByUserName(userName,email);
            }
            catch (Exception)
            {
                throw;
            }
            return ObjUserDetails;
        }

        ///<summary>  
        /// This method is used to add  User info  
        ///</summary>  
        ///<param name="User"></param>  
        ///<returns></returns>  
        public int AddUserInfo(Users User)
        {
            int result = 0;
            try
            {
                result = new UserDAL().AddUserInfo(User);
            }
            catch (Exception)
            {
                return 0;
            }
            return result;
        }
        ///<summary>  
        /// This method is used to add  User info  
        ///</summary>  
        ///<param name="User"></param>  
        ///<returns></returns>  
        public int UpdateUserInfo(Users User)
        {
            int result = 0;
            try
            {
                result = new UserDAL().UpdateUserInfo(User);
            }
            catch (Exception)
            {
                return 0;
            }
            return result;
        }
        ///<summary>  
        /// This method is used to delete User info  
        ///</summary>  
        ///<param name="User"></param>  
        ///<returns></returns>  
        public int DeleteUserInfo(Users User)
        {
            int result = 0;
            try
            {
                result = new UserDAL().DeleteUserInfo(User);
            }
            catch (Exception)
            {
                return 0;
            }
            return result;
        }
    }
}