using System;
using System.Collections.Generic;
using System.Linq;
using ITMCServiceCenter.Web.Database;
using ITMCServiceCenter.Web.Domain;

namespace ITMCServiceCenter.Web.DLL
{
    public class RoleRepository
    {
        /// <summary>
        /// Gets a list of roles from database
        /// </summary>
        /// <returns>List of roles</returns>
        public List<tbl_Entity_DTO> GetRoles()
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                return (from role in itmcContext.tbl_Entity
                        join typemaster in itmcContext.tbl_TypeMaster
                        on role.TypeMasterId equals typemaster.Id
                        select new tbl_Entity_DTO()
                        {
                            Id = role.Id,
                            Name = role.Name
                        }).ToList();
            }
        }

        /// <summary>
        /// Gets a single role from database
        /// </summary>
        /// <param name="designationId">The role id</param>
        /// <returns>Role if roleId found, otherwise an empty string</returns>
        public String GetRole(short roleId)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result = (from role in itmcContext.tbl_Entity
                              where role.Id == roleId
                              join typemaster in itmcContext.tbl_TypeMaster
                              on role.TypeMasterId equals typemaster.Id
                              select new tbl_Entity_DTO()
                              {
                                  Id = role.Id,
                                  Name = role.Name
                              }).FirstOrDefault();
                return result == null ? String.Empty : result.Name;
            }
        }
    }
}