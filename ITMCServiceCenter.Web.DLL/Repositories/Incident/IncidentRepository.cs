using ITMCServiceCenter.Web.Database;
using ITMCServiceCenter.Web.Domain;
using System.Collections.Generic;
using System.Linq;

namespace ITMCServiceCenter.Web.DLL
{
    public class IncidentRepository
    {
        #region Data Members
        private UserUtility userUtility = new UserUtility();
        private TypeUtility typeUtility = new TypeUtility();
        private EntityUtility entityUtility = new EntityUtility();
        private ProjectRepository projectRepository = new ProjectRepository();
        #endregion

        #region Methods
        /// <summary>
        /// get list of all incidents from database
        /// </summary>
        /// <returns></returns>
        public List<tbl_Incident_DTO> GetIncidents()
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result = (from incident in itmcContext.tbl_Incident
                            select new tbl_Incident_DTO()
                            {
                                CreatedBy = incident.CreatedBy,
                                CreatedOn = incident.CreatedOn,
                                Description = incident.Description,
                                EndDate = incident.EndDate,
                                EstimatedHours = incident.EstimatedHours,                            
                                Id = incident.Id,
                                IncidentOn = incident.IncidentOn,
                                LevelId = incident.LevelId,
                                ModifiedBy = incident.ModifiedBy,
                                ModifiedOn = incident.ModifiedOn,
                                PercentComplete = incident.PercentComplete,
                                ProjectId = incident.ProjectId,
                                RequestedBy = incident.RequestedBy,
                                StartDate = incident.StartDate,
                                StatusId = incident.StatusId,
                                Title = incident.Title
                            }
                    ).ToList();
                FillAllIncidents(result);
                return result;
            }
        }
        
        /// <summary>
        /// get details of specific incident based on incident id.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public tbl_Incident_DTO GetIncident(int id)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result = (from incident in itmcContext.tbl_Incident
                              where incident.Id == id
                              select new tbl_Incident_DTO()
                              {
                                  CreatedBy = incident.CreatedBy,
                                  CreatedOn = incident.CreatedOn,
                                  Description = incident.Description,
                                  EndDate = incident.EndDate,
                                  EstimatedHours = incident.EstimatedHours,
                                  Id = incident.Id,
                                  IncidentOn = incident.IncidentOn,
                                  LevelId = incident.LevelId,
                                  ModifiedBy = incident.ModifiedBy,
                                  ModifiedOn = incident.ModifiedOn,
                                  PercentComplete = incident.PercentComplete,
                                  ProjectId = incident.ProjectId,
                                  RequestedBy = incident.RequestedBy,
                                  StartDate = incident.StartDate,
                                  StatusId = incident.StatusId,
                                  Title = incident.Title
                              }
                    ).ToList();
                FillAllIncidents(result);
                return result.FirstOrDefault();
            }
        }
        
        /// <summary>
        /// get list of all incidents based on project Id
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public List<tbl_Incident_DTO> GetIncidentByProjectId(short projectId)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result = (from incident in itmcContext.tbl_Incident
                              where incident.ProjectId == projectId
                              select new tbl_Incident_DTO()
                              {
                                  CreatedBy = incident.CreatedBy,
                                  CreatedOn = incident.CreatedOn,
                                  Description = incident.Description,
                                  EndDate = incident.EndDate,
                                  EstimatedHours = incident.EstimatedHours,
                                  Id = incident.Id,
                                  IncidentOn = incident.IncidentOn,
                                  LevelId = incident.LevelId,
                                  ModifiedBy = incident.ModifiedBy,
                                  ModifiedOn = incident.ModifiedOn,
                                  PercentComplete = incident.PercentComplete,
                                  ProjectId = incident.ProjectId,
                                  RequestedBy = incident.RequestedBy,
                                  StartDate = incident.StartDate,
                                  StatusId = incident.StatusId,
                                  Title = incident.Title
                              }
                    ).ToList();
                FillAllIncidents(result);
                return result;
            }
        }
        
        /// <summary>
        /// Saves a new incident into the database
        /// </summary>
        /// <param name="tbl_Incident_DTO">incident to save</param>
        /// <returns>Returns the number of records affected, i.e. 1 if the incident was sucessfully saved, otherwise 0</returns>
        public int SaveIncident(tbl_Incident_DTO tbl_Incident_DTO)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var incidentEntity = tbl_Incident_DTO.ToEntity();
                itmcContext.tbl_Incident.Add(incidentEntity);
                var isSaved = itmcContext.SaveChanges() > 0;
                if (isSaved)
                {
                    return incidentEntity.Id;
                }
                else
                {
                    return -1;
                }
            }
        }
        
        /// <summary>
        /// Updates an exsisting incident in the database
        /// </summary>
        /// <param name="tbl_Incident_DTO">incident instance with updated values</param>
        /// <returns>Returns true if the incident was sucessfully updated, otherwise false</returns>
        public bool UpdateIncident(tbl_Incident_DTO tbl_Incident_DTO)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                itmcContext.Entry(tbl_Incident_DTO.ToEntity()).State = System.Data.EntityState.Modified;
                return itmcContext.SaveChanges() > 0;
            }
        }
       
        /// <summary>
        /// Deletes an exsisting incident in the database
        /// </summary>
        /// <param name="tbl_Incident_DTO">The incident id</param>
        /// <returns>Returns true if the incident was sucessfully deleted, otherwise false</returns>
        public bool DeleteIncident(int IncidentId)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var currentIncident = itmcContext.tbl_Incident.Find(IncidentId);
                itmcContext.tbl_Incident.Remove(currentIncident);
                return itmcContext.SaveChanges() > 0;
            }
        }
        #endregion

        #region Private Methods
        private void FillAllIncidents(List<tbl_Incident_DTO> incidents)
        {
            foreach (tbl_Incident_DTO incident in incidents)
            {
                // Fill users
                incident.RequestedByName = userUtility.GetUserFullName(incident.RequestedBy);

                //Get Project Title
                incident.ProjectTitle = projectRepository.GetProject(incident.ProjectId).Title;
                // Fill Entities
                incident.Level = entityUtility.GetEntityName(incident.LevelId);
                incident.Status = entityUtility.GetEntityName(incident.StatusId);
            }
        }
        #endregion
    }
}
