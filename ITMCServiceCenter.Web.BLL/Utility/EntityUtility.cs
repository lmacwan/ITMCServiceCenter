using ITMCServiceCenter.Web.Domain;
using System.Collections.Generic;
using System.Linq;

namespace ITMCServiceCenter.Web.BLL
{
    public class EntityUtility
    {
        #region Methods
        public List<tbl_Entity_DTO> GetEntitiesByType(Types entityType)
        {
            List<tbl_Entity_DTO> entity = null;
            var userDetails = ServiceReference.ITMCServiceClient.GetEntitiesByType(entityType);
            if (userDetails.Success)
            {
                entity = userDetails.Value.ToList();
            }
            return entity;
        }

        public static List<tbl_ProjectTaskType_DTO> GetAllProjectTaskTypes()
        {
            List<tbl_ProjectTaskType_DTO> projectTaskTypelist = null;
            var userDetails = ServiceReference.ITMCServiceClient.GetAllProjectTaskTypes();
            if (userDetails.Success)
            {
                projectTaskTypelist = userDetails.Value.ToList();
            }
            return projectTaskTypelist;
        }
        
        public static List<tbl_ProjectTaskType_DTO> GetProjectTaskTypesByProjectId(short projectId)
        {
            List<tbl_ProjectTaskType_DTO> projectTaskTypeList = null;
            var userDetails = ServiceReference.ITMCServiceClient.GetProjectTaskTypesByProjectId(projectId);
            if (userDetails.Success)
            {
                projectTaskTypeList = userDetails.Value.ToList();
            }
            return projectTaskTypeList;
        }
        
        public static tbl_ProjectTaskType_DTO GetProjectTaskTypeById(int Id)
        {
            tbl_ProjectTaskType_DTO projectTaskType = null;
            var userDetails = ServiceReference.ITMCServiceClient.GetProjectTaskTypeById(Id);
            if (userDetails.Success)
            {
                projectTaskType = userDetails.Value;
            }
            return projectTaskType;
        }
        #endregion
    }
}
