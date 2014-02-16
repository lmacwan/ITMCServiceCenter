using ITMCServiceCenter.Web.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;

namespace ITMCServiceCenter.Web.BLL
{
    public class IncidentBusinessLogic
    {
        #region Static Methods
        /// <summary>
        /// get list of all incidents from web service
        /// </summary>
        /// <returns></returns>
        public static List<tbl_Incident_DTO> GetIncidents()
        {
            List<tbl_Incident_DTO> incidentlist = null;
            var incidentDetails = ServiceReference.ITMCServiceClient.GetIncidents();
            if (incidentDetails.Success)
            {
                incidentlist = incidentDetails.Value.ToList();
            }
            return incidentlist;
        }

        /// <summary>
        /// get details of specific incident based on Incident Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static tbl_Incident_DTO GetIncident(int id)
        {
            tbl_Incident_DTO incident = null;
            if (id <= 0)
            {
                incident = new tbl_Incident_DTO();
            }
            else
            {
                var incidentDetails = ServiceReference.ITMCServiceClient.GetIncident(id);
                if (incidentDetails.Success)
                {
                    incident = incidentDetails.Value;
                }
            }
            return incident;
        }

        /// <summary>
        /// get list of all Incidents based on project Id
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public static List<tbl_Incident_DTO> GetIncidentByProjectId(short projectId)
        {
            List<tbl_Incident_DTO> incidentlist = null;
            var incidentDetails = ServiceReference.ITMCServiceClient.GetIncidentByProjectId(projectId);
            if (incidentDetails.Success)
            {
                incidentlist = incidentDetails.Value.ToList();
            }
            return incidentlist;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Calls the service and saves a new incident into the database
        /// </summary>
        /// <param name="tbl_Incident_DTO">incident to save</param>
        /// <returns>Returns the number of records affected, i.e. 1 if the incident was sucessfully saved, otherwise 0</returns>
        public int SaveIncident(tbl_Incident_DTO tbl_Incident_DTO)
        {
            int result = -1;
            tbl_Incident_DTO.CreatedBy = ITMCServiceCenterApplication.CurrentContextUser.UserFullName;
            tbl_Incident_DTO.RequestedBy = ITMCServiceCenterApplication.CurrentContextUser.Id;
            tbl_Incident_DTO.CreatedOn = DateTime.Now;
            if (Validate(tbl_Incident_DTO).IsValid)
            {
                var IncidentDetails = ServiceReference.ITMCServiceClient.SaveIncident(tbl_Incident_DTO);
                if (IncidentDetails.Success)
                {
                    result = IncidentDetails.Value;
                }
            }
            return result;
        }

        /// <summary>
        /// Calls the service and updates an exsisting incident in the database
        /// </summary>
        /// <param name="tbl_Incident_DTO">incident instance with updated values</param>
        /// <returns>Returns true if the incident was sucessfully updated, otherwise false</returns>
        public int UpdateIncident(tbl_Incident_DTO tbl_Incident_DTO)
        {
            tbl_Incident_DTO.ModifiedBy = ITMCServiceCenterApplication.CurrentContextUser.UserFullName;
            tbl_Incident_DTO.ModifiedOn = DateTime.Now;
            var IncidentDetails = ServiceReference.ITMCServiceClient.UpdateIncident(tbl_Incident_DTO);
            int result = -1;
            if (Validate(tbl_Incident_DTO).IsValid)
            {
                if (IncidentDetails.Success)
                {
                    result = tbl_Incident_DTO.Id;
                }
            }
            return result;
        }

        /// <summary>
        /// Calls the service and deletes an exsisting incident in the database
        /// </summary>
        /// <param name="tbl_Incident_DTO">The incident id</param>
        /// <returns>Returns true if the incident was sucessfully deleted, otherwise false</returns>
        public bool DeleteIncident(int IncidentId)
        {
            var IncidentDetails = ServiceReference.ITMCServiceClient.DeleteIncident(IncidentId);
            bool result = false;
            if (IncidentDetails.Success)
            {
                result = IncidentDetails.Value;
            }
            return result;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// used for validation
        /// </summary>
        /// <param name="incidentDTO"></param>
        /// <returns></returns>
        private static tbl_Incident_DTO Validate(tbl_Incident_DTO incidentDTO)
        {
            if (incidentDTO == null)
            {
                incidentDTO = new tbl_Incident_DTO();
            }
            return incidentDTO;
        }
        #endregion
    }
}
