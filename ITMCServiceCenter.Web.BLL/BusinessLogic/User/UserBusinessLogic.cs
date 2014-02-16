using ITMCServiceCenter.Web.Domain;
using System.Collections.Generic;
using System.Linq;

namespace ITMCServiceCenter.Web.BLL
{
    public class UserBusinessLogic
    {
        #region Data Members
        private static List<tbl_UserMaster_DTO> AllUsers { get; set; }
        #endregion

        #region Static Methods
        /// <summary>
        /// Calls the service and gets all users from database
        /// </summary>
        /// <returns>List of issues</returns>
        public static List<tbl_UserMaster_DTO> GetUsers()
        {
            return AllUsers ?? _GetAllUsers();
        }

        /// <summary>
        /// Calls the service and gets a single user by id from database
        /// </summary>
        /// <param name="actionId">User id</param>
        /// <returns>User</returns>
        public static tbl_UserMaster_DTO GetUser(int id)
        {
            var allUsers = AllUsers ?? _GetAllUsers();
            return allUsers.Find(user => user.Id == id);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Calls the service and gets all users with specified designation from database
        /// </summary>
        /// <param name="userName">Designation Id</param>
        /// <returns>List of users</returns>
        public List<tbl_UserMaster_DTO> GetUsersByDesignationId(int designationId)
        {
            var userlist = new List<tbl_UserMaster_DTO>();
            var userDetails = ServiceReference.ITMCServiceClient.GetUsersByDesignationId(designationId);
            if (userDetails.Success)
            {
                userlist = userDetails.Value.ToList();
            }
            return userlist;
        }
        
        /// <summary>
        /// Calls the service and gets all users with specified role from database
        /// </summary>
        /// <param name="userName">User name</param>
        /// <returns>User</returns>
        public List<tbl_UserMaster_DTO> GetUsersByRoleId(int roleId)
        {
            var userlist = new List<tbl_UserMaster_DTO>();
            var userDetails = ServiceReference.ITMCServiceClient.GetUsersByRoleId(roleId);
            if (userDetails.Success)
            {
                userlist = userDetails.Value.ToList();
            }
            return userlist;
        }
        
        /// <summary>
        /// Calls the service and gets a single user by user name from database
        /// </summary>
        /// <param name="userName">User name</param>
        /// <returns>User</returns>
        public tbl_UserMaster_DTO GetUserByUserName(string userName)
        {
            var userlist = new tbl_UserMaster_DTO();
            var userDetails = ServiceReference.ITMCServiceClient.GetUserByUserName(userName);
            if (userDetails.Success)
            {
                userlist = userDetails.Value;
            }
            return userlist;
        }
        
        /// <summary>
        /// Calls the service and saves a new user into the database
        /// </summary>
        /// <param name="tbl_UserMaster_DTO">User to save</param>
        /// <returns>Returns the number of records afffected, i.e. 1 if the user was sucessfully saved, otherwise 0</returns>
        public int SaveUser(tbl_UserMaster_DTO tbl_UserMaster_DTO)
        {
            var userId = -1;
            var userDetails = ServiceReference.ITMCServiceClient.SaveUser(tbl_UserMaster_DTO);
            if (userDetails.Success)
            {
                AllUsers.Add(tbl_UserMaster_DTO);
                userId = userDetails.Value;
            }
            return userId;
        }
        
        /// <summary>
        /// Calls the service and updates an exsisting user in the database
        /// </summary>
        /// <param name="tbl_UserMaster_DTO">User instance with updated values</param>
        /// <returns>Returns true if the user was sucessfully updated, otherwise false</returns>
        public bool UpdateUser(tbl_UserMaster_DTO tbl_UserMaster_DTO)
        {
            var isUpdated = false;
            var userDetails = ServiceReference.ITMCServiceClient.UpdateUser(tbl_UserMaster_DTO);
            if (userDetails.Success)
            {
                AllUsers.Remove(AllUsers.Find(user => user.Id == tbl_UserMaster_DTO.Id));
                AllUsers.Add(tbl_UserMaster_DTO);
                isUpdated = userDetails.Value;
            }
            return isUpdated;
        }
        
        /// <summary>
        /// Calls the service and deletes an exsisting user in the database
        /// </summary>
        /// <param name="tbl_UserMaster_DTO">The user id</param>
        /// <returns>Returns true if the user was sucessfully deleted, otherwise false</returns>
        public bool DeleteUser(int userId)
        {
            var isDeleted = false;
            var userDetails = ServiceReference.ITMCServiceClient.DeleteUser(userId);
            if (userDetails.Success)
            {
                isDeleted = userDetails.Value;
                if (isDeleted)
                {
                    AllUsers.Remove(AllUsers.Find(user => user.Id == userId));
                }
            }
            return isDeleted;
            
        }
        
        /// <summary>
        /// Validates user
        /// </summary>
        /// <param name="userDTO">User</param>
        /// <returns>User with additional error data, if present</returns>
        private tbl_UserMaster_DTO Validate(tbl_UserMaster_DTO userDTO)
        {
            if (userDTO == null)
            {
                userDTO = new tbl_UserMaster_DTO();
            }
            return userDTO;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Returns list of users from web service.
        /// </summary>
        /// <returns></returns>
        private static List<tbl_UserMaster_DTO> _GetAllUsers()
        {
            List<tbl_UserMaster_DTO> result = new List<tbl_UserMaster_DTO>();
            var userDetails = ServiceReference.ITMCServiceClient.GetUsers();
            if (userDetails.Success)
            {
                result = userDetails.Value.ToList();
                if (AllUsers == null && result.Count > 0)
                {
                    AllUsers = result;
                }
            }
            return result;
        }
        #endregion
    }
}
