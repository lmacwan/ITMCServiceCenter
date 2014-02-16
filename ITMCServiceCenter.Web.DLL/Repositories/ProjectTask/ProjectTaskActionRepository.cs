using ITMCServiceCenter.Web.Database;
using ITMCServiceCenter.Web.Domain;
using System.Collections.Generic;
using System.Linq;

namespace ITMCServiceCenter.Web.DLL
{
    public class ProjectTaskActionRepository
    {
        #region Methods
        /// <summary>
        /// get list of all project task actions from database
        /// </summary>
        /// <returns></returns>
        public List<tbl_ProjectTaskAction_DTO> GetProjectTaskActions()
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result = (

                    from projecttaskaction in itmcContext.tbl_ProjectTaskAction
                    join projecttask in itmcContext.tbl_ProjectTask
                      on projecttaskaction.ProjectTaskId equals projecttask.Id

                    select new tbl_ProjectTaskAction_DTO()
                    {
                        Id = projecttaskaction.Id,
                        ProjectTaskId = projecttaskaction.ProjectTaskId,
                        CreatedBy = projecttaskaction.CreatedBy,
                        Action = projecttaskaction.Action,
                        CreatedOn = projecttaskaction.CreatedOn,
                    }).ToList();

                return result;
            }
        }

        /// <summary>
        /// get list of project task actions from database based on Project Task id provided
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        public List<tbl_ProjectTaskAction_DTO> GetProjectTaskActionsByTaskId(int taskId)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result = (

                    from projecttaskaction in itmcContext.tbl_ProjectTaskAction
                    where projecttaskaction.ProjectTaskId == taskId
                    join projecttask in itmcContext.tbl_ProjectTask
                      on projecttaskaction.ProjectTaskId equals projecttask.Id

                    select new tbl_ProjectTaskAction_DTO()
                    {
                        Id = projecttaskaction.Id,
                        ProjectTaskId = projecttaskaction.ProjectTaskId,
                        CreatedBy = projecttaskaction.CreatedBy,
                        Action = projecttaskaction.Action,
                        CreatedOn = projecttaskaction.CreatedOn,

                    }).ToList();

                return result;
            }
        }

        /// <summary>
        /// get details of specific project task action based on project task action id provided. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public tbl_ProjectTaskAction_DTO GetProjectTaskAction(int id)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result = (

                    from projecttaskaction in itmcContext.tbl_ProjectTaskAction
                    where projecttaskaction.Id == id
                    join projecttask in itmcContext.tbl_ProjectTask
                      on projecttaskaction.ProjectTaskId equals projecttask.Id

                    select new tbl_ProjectTaskAction_DTO()
                    {
                        Id = projecttaskaction.Id,
                        ProjectTaskId = projecttaskaction.ProjectTaskId,
                        CreatedBy = projecttaskaction.CreatedBy,
                        Action = projecttaskaction.Action,
                        CreatedOn = projecttaskaction.CreatedOn,

                    }).FirstOrDefault();

                return result;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionDto"></param>
        /// <returns></returns>
        public int SaveProjectTaskAction(tbl_ProjectTaskActionDTO actionDto)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var entity = actionDto.ToEntity();
                itmcContext.tbl_ProjectTaskAction.Add(entity);
                if (itmcContext.SaveChanges() > 0)
                {
                    return entity.Id;
                }
                return -1;
            }
        }
        #endregion
    }
}
