using ITMCServiceCenter.Web.Database;
using ITMCServiceCenter.Web.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITMCServiceCenter.Web.DLL
{
    public class EngineerRepository
    {
        #region Data Members
        private UserUtility userUtility = new UserUtility();
        private TypeUtility typeUtility = new TypeUtility();
        private EntityUtility entityUtility = new EntityUtility();
        #endregion

        #region Methods
        /// <summary>
        /// Gets all change requests for a given project from databse
        /// </summary>
        /// <param name="projectId">Project id</param>
        /// <returns>List of change requests</returns>
        public List<tbl_Engineer_DTO> GetEngineers(Types type, int typeId)
        {
            return GetEngineers(typeUtility.GetTypeByEnum(type).Id, typeId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tbl_Team_DTO"></param>
        /// <param name="tbl_TeamMember_DTOList"></param>
        /// <returns></returns>
        public bool SaveEngineers(List<tbl_Engineer_DTO> newEngineers, Types type, int typeId)
        {
            var engineerTypeMasterId = (from engineer in newEngineers
                                        select engineer.RelateTypeId).Distinct().ToList();
            var engineerTypeId = (from engineer in newEngineers
                                  select engineer.RelatedToId).Distinct().ToList();
            if (engineerTypeId.Count == 0 && engineerTypeMasterId.Count == 0)
            {
                return DeleteAllEngineers(typeUtility.GetTypeByEnum(type).Id, typeId);
            }
            else if (engineerTypeMasterId.Count == engineerTypeId.Count)
            {
                using (var itmcContext = new ITMCServiceCenter_SQLServer())
                {
                    var oldEngineers = GetEngineers(engineerTypeMasterId.First(), engineerTypeId.First());

                    var comparer = new EngineersEqualityComparer();
                    var keepThem = oldEngineers.Intersect(newEngineers, comparer);
                    var removeThem = oldEngineers.Except(keepThem, comparer);
                    var addThem = newEngineers.Except(keepThem, comparer);
                    tbl_Engineer currentEngineer;
                    foreach (tbl_Engineer_DTO memberToRemove in removeThem)
                    {
                        currentEngineer = itmcContext.tbl_Engineer.Where(row => row.RelatedToId == memberToRemove.RelatedToId
                                                                                    && row.RelateTypeId == memberToRemove.RelateTypeId 
                                                                                        && row.UserId == memberToRemove.UserId).FirstOrDefault();
                        itmcContext.tbl_Engineer.Remove(currentEngineer);
                    }
                    foreach (tbl_Engineer_DTO memberToAdd in addThem)
                    {
                        itmcContext.tbl_Engineer.Add(memberToAdd.ToEntity());
                    }
                    return itmcContext.SaveChanges() > 0;
                }
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Private Methods
        private List<tbl_Engineer_DTO> GetEngineers(byte typeMasterId, int typeId)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result = (
                                from engineer in itmcContext.tbl_Engineer
                                where engineer.RelatedToId == typeId
                                    && engineer.RelateTypeId == typeMasterId
                                select new tbl_Engineer_DTO()
                                {
                                    RelatedToId = engineer.RelatedToId,
                                    RelateTypeId = engineer.RelateTypeId,
                                    UserId = engineer.UserId,
                                }
                              ).ToList();
                FillAllEngineers(result);
                return result;
            }
        }

        private bool DeleteAllEngineers(byte type, int typeId)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var engineers = GetEngineers(type, typeId);
                tbl_Engineer engineerEntity;
                foreach (tbl_Engineer_DTO engineer in engineers)
                {
                    engineerEntity = itmcContext.tbl_Engineer.Where(row => row.RelatedToId == engineer.RelatedToId
                                                                                    && row.RelateTypeId == engineer.RelateTypeId
                                                                                        && row.UserId == engineer.UserId).FirstOrDefault();
                    itmcContext.tbl_Engineer.Remove(engineerEntity);
                }
                return itmcContext.SaveChanges() > 0;
            }
        } 

        private void FillAllEngineers(List<tbl_Engineer_DTO> engineeers)
        {
            foreach (tbl_Engineer_DTO engineer in engineeers)
            {
                //Fill User Fulll Names
                engineer.UserFullName = userUtility.GetUserFullName(engineer.UserId);
            }
        }
        #endregion
    }
}
