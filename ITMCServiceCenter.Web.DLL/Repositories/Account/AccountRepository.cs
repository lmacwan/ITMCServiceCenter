using System.Linq;
using ITMCServiceCenter.Web.Database;
using ITMCServiceCenter.Web.Domain;


namespace ITMCServiceCenter.Web.DLL
{
    public class AccountRepository
    {
        /// <summary>
        /// Authenticates the user by matching the credentials against the database
        /// </summary>
        /// <param name="userToAuthenticate">UserMaster instance that conatins the user credentials to validate</param>
        /// <returns>UserMaster instance on sucessfull authentication, otherwise null</returns>
        public tbl_UserMaster_DTO AuthenticateUser(tbl_UserMaster_DTO userToAuthenticate)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result = (from user in itmcContext.tbl_UserMaster
                              where user.UserName ==
                                  userToAuthenticate.UserName &&
                                  user.Password == userToAuthenticate.Password
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
    }
}
