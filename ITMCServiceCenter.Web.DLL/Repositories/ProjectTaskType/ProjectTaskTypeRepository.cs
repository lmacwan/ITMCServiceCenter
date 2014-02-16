using ITMCServiceCenter.Web.Database;
using ITMCServiceCenter.Web.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITMCServiceCenter.Web.DLL
{
    public class ProjectTaskTypeRepository
    {
        /// <summary>
        /// Save new Project Task Type into database
        /// </summary>
        /// <param name="tbl_ProjectTaskType_DTO"></param>
        /// <returns></returns>
        public int SaveProjectTaskType(tbl_ProjectTaskType_DTO tbl_ProjectTaskType_DTO)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var projectTaskTypeEntity = tbl_ProjectTaskType_DTO.ToEntity();
                itmcContext.tbl_ProjectTaskType.Add(projectTaskTypeEntity);
                var isSaved = itmcContext.SaveChanges() > 0;
                if (isSaved)
                {
                    return projectTaskTypeEntity.Id;
                }
                else
                {
                    return -1;
                }
            }
        }
    }
}
