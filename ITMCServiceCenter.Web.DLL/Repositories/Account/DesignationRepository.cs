using ITMCServiceCenter.Web.Database;
using ITMCServiceCenter.Web.Domain;
using System.Collections.Generic;
using System.Linq;

namespace ITMCServiceCenter.Web.DLL
{
    public class DesignationRepository
    {
        /// <summary>
        /// Gets a list of designations from database
        /// </summary>
        /// <returns>List of designations</returns>
        public List<tbl_Entity_DTO> GetDesignations()
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                return (from designation in itmcContext.tbl_Entity
                        join typemaster in itmcContext.tbl_TypeMaster
                        on designation.TypeMasterId equals typemaster.Id
                        select new tbl_Entity_DTO()
                        {
                            Id = designation.Id,
                            Name = designation.Name
                        }).ToList();
            }
        }

        /// <summary>
        /// Gets a single designation from database
        /// </summary>
        /// <param name="designationId">The designation id</param>
        /// <returns>Designation if designationId found, otherwise an empty string</returns>
        public string GetDesignation(short designationId)
        {
            var designationDto = GetDesignations();
            return designationDto.Find(d => d.Id == designationId).Name;
        }
    }
}