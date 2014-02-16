using ITMCServiceCenter.Web.Database;
using ITMCServiceCenter.Web.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITMCServiceCenter.Web.DLL
{
    public class UserRepository
    {
        #region Methods
        /// <summary>
        /// Gets all users with specified designation from database
        /// </summary>
        /// <param name="userName">Designation Id</param>
        /// <returns>List of users</returns>
        public List<tbl_UserMaster_DTO> GetUsersByDesignationId(int designationId)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result = (from user in itmcContext.tbl_UserMaster
                              join roleEntity in itmcContext.tbl_Entity
                                  on user.RoleId equals roleEntity.Id
                              join desigEntity in itmcContext.tbl_Entity
                                  on user.DesignationId equals desigEntity.Id
                              where user.DesignationId == designationId       // filter by designationId
                              select new tbl_UserMaster_DTO()
                              {
                                  Id = user.Id,
                                  FirstName = user.FirstName,
                                  LastName = user.LastName,
                                  DesignationId = user.DesignationId,
                                  IsClient = user.IsClient,
                                  IsDisable = user.IsDisable,
                                  Password = user.Password,
                                  RoleId = user.RoleId,
                                  UserName = user.UserName,
                                  Role = roleEntity.Name,
                                  Designation = desigEntity.Name
                              }).ToList();
                return result;
            }
        }

        /// <summary>
        /// Gets all users with specified role from database
        /// </summary>
        /// <param name="userName">User name</param>
        /// <returns>User</returns>
        public List<tbl_UserMaster_DTO> GetUsersByRoleId(int roleId)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result = (from user in itmcContext.tbl_UserMaster
                              join roleEntity in itmcContext.tbl_Entity
                                  on user.RoleId equals roleEntity.Id
                              join desigEntity in itmcContext.tbl_Entity
                                  on user.DesignationId equals desigEntity.Id
                              where user.RoleId == roleId       // filter by roleid
                              select new tbl_UserMaster_DTO()
                              {
                                  Id = user.Id,
                                  FirstName = user.FirstName,
                                  LastName = user.LastName,
                                  DesignationId = user.DesignationId,
                                  IsClient = user.IsClient,
                                  IsDisable = user.IsDisable,
                                  Password = user.Password,
                                  RoleId = user.RoleId,
                                  UserName = user.UserName,
                                  Role = roleEntity.Name,
                                  Designation = desigEntity.Name
                              }).ToList();
                return result;
            }
        }

        /// <summary>
        /// Gets a single user by user name from database
        /// </summary>
        /// <param name="userName">User name</param>
        /// <returns>User</returns>
        public tbl_UserMaster_DTO GetUserByUserName(string userName)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result = (from user in itmcContext.tbl_UserMaster
                              where user.UserName ==
                                  userName      // filter by userName
                              join roleEntity in itmcContext.tbl_Entity
                                  on user.RoleId equals roleEntity.Id
                              join desigEntity in itmcContext.tbl_Entity
                                  on user.DesignationId equals desigEntity.Id
                              select new tbl_UserMaster_DTO()
                              {
                                  Id = user.Id,
                                  FirstName = user.FirstName,
                                  LastName = user.LastName,
                                  DesignationId = user.DesignationId,
                                  IsClient = user.IsClient,
                                  IsDisable = user.IsDisable,
                                  Password = user.Password,
                                  RoleId = user.RoleId,
                                  UserName = user.UserName,
                                  Role = roleEntity.Name,
                                  Designation = desigEntity.Name
                              }).FirstOrDefault();
                return result;
            }
        }

        /// <summary>
        /// Gets a single user by id from database
        /// </summary>
        /// <param name="actionId">User id</param>
        /// <returns>User</returns>
        public tbl_UserMaster_DTO GetUser(int id)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result = (from user in itmcContext.tbl_UserMaster
                              where user.Id ==
                                  id    // filter by id
                              join roleEntity in itmcContext.tbl_Entity
                                  on user.RoleId equals roleEntity.Id
                              join desigEntity in itmcContext.tbl_Entity
                                  on user.DesignationId equals desigEntity.Id
                              select new tbl_UserMaster_DTO()
                              {
                                  Id = user.Id,
                                  FirstName = user.FirstName,
                                  LastName = user.LastName,
                                  DesignationId = user.DesignationId,
                                  IsClient = user.IsClient,
                                  IsDisable = user.IsDisable,
                                  Password = user.Password,
                                  RoleId = user.RoleId,
                                  UserName = user.UserName,
                                  Role = roleEntity.Name,
                                  Designation = desigEntity.Name
                              }).FirstOrDefault();
                return result;
            }
        }

        /// <summary>
        /// Gets all users from database
        /// </summary>
        /// <returns>List of issues</returns>
        public List<tbl_UserMaster_DTO> GetUsers()
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result = (from user in itmcContext.tbl_UserMaster
                              join roleEntity in itmcContext.tbl_Entity
                                  on user.RoleId equals roleEntity.Id
                              join desigEntity in itmcContext.tbl_Entity
                                  on user.DesignationId equals desigEntity.Id
                              select new tbl_UserMaster_DTO()
                              {
                                  Id = user.Id,
                                  FirstName = user.FirstName,
                                  LastName = user.LastName,
                                  DesignationId = user.DesignationId,
                                  IsClient = user.IsClient,
                                  IsDisable = user.IsDisable,
                                  Password = user.Password,
                                  RoleId = user.RoleId,
                                  UserName = user.UserName,

                                  //joins
                                  Role = roleEntity.Name,
                                  Designation = desigEntity.Name
                              }).ToList();
                return result;
            }
        }

        /// <summary>
        /// Saves a new user into the database
        /// </summary>
        /// <param name="tbl_UserMaster_DTO">User to save</param>
        /// <returns>Returns the number of records afffected, i.e. 1 if the user was sucessfully saved, otherwise 0</returns>
        public int SaveUser(tbl_UserMaster_DTO tbl_UserMaster_DTO)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var userEntity = tbl_UserMaster_DTO.ToEntity();
                itmcContext.tbl_UserMaster.Add(userEntity);
                if (itmcContext.SaveChanges() > 0)
                {
                    return userEntity.Id;
                }
                else
                {
                    return -1;
                }
            }
        }

        /// <summary>
        /// Updates an exsisting user in the database
        /// </summary>
        /// <param name="tbl_UserMaster_DTO">User instance with updated values</param>
        /// <returns>Returns true if the user was sucessfully updated, otherwise false</returns>
        public bool UpdateUser(tbl_UserMaster_DTO tbl_UserMaster_DTO)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                itmcContext.Entry(tbl_UserMaster_DTO.ToEntity()).State = System.Data.EntityState.Modified;
                return itmcContext.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// Deletes an exsisting user in the database
        /// </summary>
        /// <param name="tbl_UserMaster_DTO">The user id</param>
        /// <returns>Returns true if the user was sucessfully deleted, otherwise false</returns>
        public bool DeleteUser(int userId)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var currentUser = itmcContext.tbl_UserMaster.Find(userId);
                itmcContext.tbl_UserMaster.Remove(currentUser);
                return itmcContext.SaveChanges() > 0;
            }
        }
        #endregion


        public List<tbl_UserMaster_DTO> Managed
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
