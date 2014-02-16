using ITMCServiceCenter.Web.Database;
using ITMCServiceCenter.Web.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITMCServiceCenter.Web.DLL
{
    public class AssigneeRepository : IManager<tbl_Assignee_DTO>
    {
        #region Data Members
        private static UserUtility userUtility = new UserUtility();
        #endregion

        #region Methods
        public bool Save(List<tbl_Assignee_DTO> assignees, byte typeMasterId, int typeId)
        {
            var assigneeTypeMasterId = (from assignee in assignees
                                        select assignee.RelateTypeId).Distinct().ToList();
            var assigneeTypeId = (from assignee in assignees
                                  select assignee.RelatedToId).Distinct().ToList();
            if (assigneeTypeId.Count == 0 && assigneeTypeMasterId.Count == 0)
            {
                using (var itmcContext = new ITMCServiceCenter_SQLServer())
                {
                    var oldAssignees = GetList(typeMasterId, typeId);
                    tbl_Assignee assigneeEntity;
                    foreach (tbl_Assignee_DTO assignee in oldAssignees)
                    {
                        assigneeEntity = itmcContext.tbl_Assignee.Where(row => row.RelatedToId == assignee.RelatedToId
                                                                                        && row.RelateTypeId == assignee.RelateTypeId
                                                                                            && row.UserId == assignee.UserId).FirstOrDefault();
                        itmcContext.tbl_Assignee.Remove(assigneeEntity);
                    }
                    return itmcContext.SaveChanges() > 0;
                }
            }
            else if ((assigneeTypeMasterId.Count == assigneeTypeId.Count) && (assigneeTypeId.Count == 1))
            {
                using (var itmcContext = new ITMCServiceCenter_SQLServer())
                {
                    var oldAssignees = GetList(typeMasterId, typeId);

                    var comparer = new AssigneesEqualityComparer();
                    var keepThem = oldAssignees.Intersect(assignees, comparer);
                    var removeThem = oldAssignees.Except(keepThem, comparer);
                    var addThem = assignees.Except(keepThem, comparer);
                    tbl_Assignee currentAssignee;
                    foreach (tbl_Assignee_DTO assigneeToRemove in removeThem)
                    {
                        currentAssignee = itmcContext.tbl_Assignee.Where(row => row.RelatedToId == assigneeToRemove.RelatedToId
                                                                                     && row.RelateTypeId == assigneeToRemove.RelateTypeId
                                                                                        && row.UserId == assigneeToRemove.UserId).FirstOrDefault();
                        itmcContext.tbl_Assignee.Remove(currentAssignee);
                    }
                    foreach (tbl_Assignee_DTO assigneeToAdd in addThem)
                    {
                        assigneeToAdd.RelateTypeId = typeMasterId;
                        assigneeToAdd.RelatedToId = typeId;
                        itmcContext.tbl_Assignee.Add(assigneeToAdd.ToEntity());
                    }
                    return itmcContext.SaveChanges() > 0;
                }
            }
            else
            {
                return false;
            }
        }

        public List<tbl_Assignee_DTO> GetList(byte typeMasterId, int typeId)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result = (
                                from assignee in itmcContext.tbl_Assignee
                                where assignee.RelatedToId == typeId
                                    && assignee.RelateTypeId == typeMasterId
                                select new tbl_Assignee_DTO
                                {
                                    RelatedToId = assignee.RelatedToId,
                                    RelateTypeId = assignee.RelateTypeId,
                                    UserId = assignee.UserId,
                                }
                              ).ToList();
                FillAllAssignees(result);
                return result;
            }
        }
        #endregion

        #region Static Methods
        private static void FillAllAssignees(List<tbl_Assignee_DTO> assignees)
        {
            foreach (tbl_Assignee_DTO assignee in assignees)
            {
                //Fill User Fulll Names
                assignee.UserFullName = userUtility.GetUserFullName(assignee.UserId);
            }
        }
        #endregion
    }
}
