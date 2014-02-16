using ITMCServiceCenter.Web.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITMCServiceCenter.Web.BLL
{
    public class EngineersBusinessLogic
    {
        #region Data Members
        private TypeUtility typeUtility = new TypeUtility();
        private UserBusinessLogic userBusinessLogic = new UserBusinessLogic();
        #endregion

        #region Static Methods
        /// <summary>
        /// Gets all change requests for a given project from databse
        /// </summary>
        /// <param name="projectId">Project id</param>
        /// <returns>List of change requests</returns>
        public static List<int> GetEngineersId(Types type, int typeId)
        {
            var engineers = GetEngineers(type, typeId);
            return (from engineer in engineers
                    select engineer.UserId
                    ).ToList();
        }

        /// <summary>
        /// Gets all change requests for a given project from databse
        /// </summary>
        /// <param name="projectId">Project id</param>
        /// <returns>List of change requests</returns>
        public static List<tbl_Engineer_DTO> GetEngineers(Types type, int typeId)
        {
            List<tbl_Engineer_DTO> result = new List<tbl_Engineer_DTO>();
            if (typeId > 0)
            {
                var engineersDetails = ServiceReference.ITMCServiceClient.GetEngineers(type, typeId);
                if (engineersDetails.Success)
                {
                    //  Validate all engineers
                    result = (from engineer in engineersDetails.Value.ToList()
                              select Validate(engineer)).ToList();
                }
            }
            return result;
        }
        #endregion

        #region Methods
        public bool SaveEngineers(List<int> selectedEngineersId, Types relateType, int relateToId)
        {
            List<tbl_Engineer_DTO> engineers;
            engineers = GetEngineers(selectedEngineersId);
            foreach (tbl_Engineer_DTO engineer in engineers)
            {
                engineer.RelatedToId = relateToId;
                engineer.RelateTypeId = typeUtility.GetTypeIdByEnum(relateType);
            }

            //  Validate all engineers
            engineers = (from engineer in engineers
                         select Validate(engineer)).ToList();
            var result = false;
            if (relateType != null && relateToId > 0)
            {
                var engineerDetails = ServiceReference.ITMCServiceClient.SaveEngineers(engineers.ToArray(), relateType, relateToId);
                if (engineerDetails.Success)
                {
                    result = engineerDetails.Value;
                }
            }
            return result;
        }
        #endregion

        #region Private Methods
        private List<tbl_Engineer_DTO> GetEngineers(List<int> memberIdList)
        {
            List<tbl_Engineer_DTO> newEngineers = new List<tbl_Engineer_DTO>();
            tbl_Engineer_DTO newMember;
            foreach (int memberId in memberIdList)
            {
                newMember = GetNewEngineerByUserId(memberId);
                if (newMember == null)
                {
                    continue;
                }
                else
                {
                    newEngineers.Add(newMember);
                }
            }
            return newEngineers;
        }

        private tbl_Engineer_DTO GetNewEngineerByUserId(int memberId)
        {
            tbl_Engineer_DTO validEngineer = null;
            var validUser = UserBusinessLogic.GetUser(memberId);
            if (validUser != null)
            {
                validEngineer = new tbl_Engineer_DTO();
                validEngineer.UserId = validUser.Id;
                validEngineer.UserFullName = validUser.UserFullName;
            }
            return validEngineer;
        }

        private static tbl_Engineer_DTO Validate(tbl_Engineer_DTO tbl_Engineer_DTO)
        {
            if (tbl_Engineer_DTO == null)
            {
                tbl_Engineer_DTO = new tbl_Engineer_DTO();
            }
            else 
            {
                if (tbl_Engineer_DTO.RelatedToId <= 0)
                {
                    //todo: Validate RelatedToId <= 0
                }
                if (tbl_Engineer_DTO.RelateTypeId <= 0)
                {
                    //todo: Validate RelatedTypeId <= 0
                }
            }
            return tbl_Engineer_DTO;
        }
        #endregion
    }
}
