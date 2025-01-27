using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Configuration;
using System.Reflection;
using FreelancerWebAPI.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;

namespace FreelancerWebAPI.DAL
{
    public class UserDAL
    {
        /// Specify the Database variable    
        Database objDB;
        /// Specify the static variable    
        static string ConnectionString;
       
        /// This constructor is used to get the connectionstring from the config file      
        public UserDAL()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["Constr"].ToString();
        }
        #region Database Method  
        public List<T> ConvertTo<T>(DataTable datatable) where T : new()
        {
            List<T> Temp = new List<T>();
            try
            {
                List<string> columnsNames = new List<string>();
                foreach (DataColumn DataColumn in datatable.Columns)
                    columnsNames.Add(DataColumn.ColumnName);
                Temp = datatable.AsEnumerable().ToList().ConvertAll<T>(row => getObject<T>(row, columnsNames));
                return Temp;
            }
            catch
            {
                return Temp;
            }
        }

        public T getObject<T>(DataRow row, List<string> columnsName) where T: new() {  
            T obj = new T();  
            try {  
                string columnname = "";
                    string value = "";
                    PropertyInfo[] Properties;
                    Properties = typeof (T).GetProperties();  
                            foreach(PropertyInfo objProperty in Properties) {  
                                columnname = columnsName.Find(name => name.ToLower() == objProperty.Name.ToLower());  
                                if (!string.IsNullOrEmpty(columnname)) {  
                                    value = row[columnname].ToString();  
                                    if (!string.IsNullOrEmpty(value)) {  
                                        if (Nullable.GetUnderlyingType(objProperty.PropertyType) != null) {  
                                            value = row[columnname].ToString().Replace("$", "").Replace(",", "");
                    objProperty.SetValue(obj, Convert.ChangeType(value, Type.GetType(Nullable.GetUnderlyingType(objProperty.PropertyType).ToString())), null);  
                                        } else {  
                                            value = row[columnname].ToString();
                    objProperty.SetValue(obj, Convert.ChangeType(value, Type.GetType(objProperty.PropertyType.ToString())), null);  
                            }  
                        }  
                    }  
                }  
                return obj;  
            }   
            catch (Exception ex) {  
                return obj;  
            }  
        }
        #endregion

        #region CricketerProfile  
        ///<summary>  
        /// This method is used to get the User data      
        ///</summary>  
        ///<returns></returns>  
        public List<Users> GetUserList()
        {
            List<Users> objGetUsers = null;
            objDB = new SqlDatabase(ConnectionString);
            using (DbCommand objcmd = objDB.GetStoredProcCommand("SP_GetAll_User"))
            {
                try
                {
                    using (DataTable dataTable = objDB.ExecuteDataSet(objcmd).Tables[0])
                    {
                        objGetUsers = ConvertTo<Users>(dataTable);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                    return null;
                }
            }
            return objGetUsers;
        }

        ///<summary>  
        /// This method is used to get User details by User id    
        ///</summary>  
        ///<returns></returns>  
        //public List<Users> GetUserDetailsById(int Id)
        //{
        //    List<Users> objUserDetails = null;
        //    objDB = new SqlDatabase(ConnectionString);
        //    using (DbCommand objcmd = objDB.GetStoredProcCommand("SP_Search_User"))
        //    {
        //        try
        //        {
        //            objDB.AddInParameter(objcmd, "@UserId", DbType.Int64, Id);
        //            using (DataTable dataTable = objDB.ExecuteDataSet(objcmd).Tables[0])
        //            {
        //                objUserDetails = ConvertTo<Users>(dataTable);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //            return null;
        //        }
        //    }
        //    return objUserDetails;
        //}

        public List<Users> GetUserDetailsById(int Id)
        {
            List <Users> objUserDetails = null;
            objDB = new SqlDatabase(ConnectionString);
            using (DbCommand objcmd = objDB.GetStoredProcCommand("SP_Search_User"))
            {
                try
                {
                    objDB.AddInParameter(objcmd, "@UserId", DbType.Int64, Id);
                    using (DataTable dataTable = objDB.ExecuteDataSet(objcmd).Tables[0])
                    {
                        objUserDetails = ConvertTo<Users>(dataTable);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                    return null;
                }
            }
            return objUserDetails;
        }

        public List<Users> GetUserInfoByUserName(string userName, string email)
        {
            List<Users> objUserDetails = null;
            objDB = new SqlDatabase(ConnectionString);
            using (DbCommand objcmd = objDB.GetStoredProcCommand("SP_Search_UserByName"))
            {
                try
                {
                    objDB.AddInParameter(objcmd, "@UserName", DbType.String, userName);
                    objDB.AddInParameter(objcmd, "@Email", DbType.String, email);
                    using (DataTable dataTable = objDB.ExecuteDataSet(objcmd).Tables[0])
                    {
                        objUserDetails = ConvertTo<Users>(dataTable);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                    return null;
                }
            }
            return objUserDetails;
        }
        ///<summary>  
        /// This method is used to add User info  
        ///</summary>  
        ///<returns></returns>  
        public int AddUserInfo(Users User)
        {
            int result = 0;
            objDB = new SqlDatabase(ConnectionString);
            using (DbCommand objCMD = objDB.GetStoredProcCommand("SP_Create_User"))
            {
               // objDB.AddInParameter(objCMD, "@Id", DbType.Int32, User.Id);

                objDB.AddInParameter(objCMD, "@UserName", DbType.String, User.UserName);
                objDB.AddInParameter(objCMD, "@Email", DbType.String, User.Email);
                objDB.AddInParameter(objCMD, "@ContactNo", DbType.Int64, User.ContactNo);
                objDB.AddInParameter(objCMD, "@SkillSet", DbType.String, User.SkillSet);
                objDB.AddInParameter(objCMD, "@Hobbies", DbType.String, User.Hobbies);
                try
                {
                    result= objDB.ExecuteNonQuery(objCMD);
                    //result = Convert.ToInt32(objDB.GetParameterValue(objCMD, "@Status"));
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return result;
        }

        ///<summary>  
        /// This method is used to add User info  
        ///</summary>  
        ///<returns></returns>  
        public int UpdateUserInfo(Users User)
        {
            int result = 0;
            objDB = new SqlDatabase(ConnectionString);
            using (DbCommand objCMD = objDB.GetStoredProcCommand("SP_Update_User"))
            {
                objDB.AddInParameter(objCMD, "@UserId", DbType.Int64, User.UserId);
                objDB.AddInParameter(objCMD, "@Id", DbType.Int64, User.Id);
                objDB.AddInParameter(objCMD, "@UserName", DbType.String, User.UserName);
                objDB.AddInParameter(objCMD, "@Email", DbType.String, User.Email);
                objDB.AddInParameter(objCMD, "@ContactNo", DbType.Int64, User.ContactNo);
                objDB.AddInParameter(objCMD, "@SkillSet", DbType.String, User.SkillSet);
                objDB.AddInParameter(objCMD, "@Hobbies", DbType.String, User.Hobbies);
                try
                {
                    result = objDB.ExecuteNonQuery(objCMD);
                    //result = Convert.ToInt32(objDB.GetParameterValue(objCMD, "@Status"));
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return result;
        }

        ///<summary>  
        /// This method is used to delete user info  
        ///</summary>  
        ///<returns></returns>  
        
        public int DeleteUserInfo(Users user)
        {
            int result = 0;
            objDB = new SqlDatabase(ConnectionString);
            using (DbCommand objCMD = objDB.GetStoredProcCommand("SP_Delete_User"))
            {
                objDB.AddInParameter(objCMD, "@UserId", DbType.Int64, user.UserId);
                try
                {
                    result = objDB.ExecuteNonQuery(objCMD);
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return result;
        }

        #endregion
    }
}