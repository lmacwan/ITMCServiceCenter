using ITMCServiceCenter.Web.Database;
using ITMCServiceCenter.Web.Domain;
using System.Collections.Generic;
using System.Linq;

namespace ITMCServiceCenter.Web.DLL
{
    public class TeamRepository
    {
        #region Data Members
        private EntityUtility entityUtility = new EntityUtility();
        private UserUtility userUtility = new UserUtility();
        private TypeUtility typeUtility = new TypeUtility();
        #endregion

        #region Methods
        /// <summary>
        /// Gets all change requests for a given project from databse
        /// </summary>
        /// <param name="projectId">Project id</param>
        /// <returns>List of change requests</returns>
        public tbl_Team_DTO GetTeam(Types entity, int entityId, TeamType type)
        {
            var entityTypeId = typeUtility.GetTypeByEnum(entity).Id;
            var teamTypeId = entityUtility.GetEntityByTeamType(type).Id;

            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result = (
                                    from team in itmcContext.tbl_Team
                                    where team.TypeId == teamTypeId
                                            && team.RelatedToId == entityId
                                                && team.RelatedTypeId == entityTypeId
                                    select new tbl_Team_DTO()
                                    {
                                        Id = team.Id,
                                        RelatedToId = team.RelatedToId,
                                        RelatedTypeId = team.RelatedTypeId,
                                        TypeId = team.TypeId
                                    }
                              ).FirstOrDefault();
                return result;
            }
        }

        /// <summary>
        /// Gets all teams from database
        /// </summary>
        /// <returns>List of all teams</returns>
        public List<tbl_Team_DTO> GetTeams()
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result = (
                                       from team in itmcContext.tbl_Team
                                       select new tbl_Team_DTO()
                                       {
                                           Id = team.Id,
                                           RelatedToId = team.RelatedToId,
                                           RelatedTypeId = team.RelatedTypeId,
                                           TypeId = team.TypeId
                                       }
                               ).ToList();
                return result;
            }
        }

        /// <summary>
        /// Gets all change requests for a given project from databse
        /// </summary>
        /// <param name="projectId">Project id</param>
        /// <returns>List of change requests</returns>
        public List<tbl_TeamMember_DTO> GetTeamMembersByTeamId(int teamId)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result = (
                               from teammembers in itmcContext.tbl_TeamMember
                               where teammembers.TeamId == teamId
                               select new tbl_TeamMember_DTO()
                               {
                                   TeamId = teammembers.TeamId,
                                   Id = teammembers.Id,
                                   UserId = teammembers.UserId,
                               }
                            ).ToList();
                FillAllTeamMembers(result);
                return result;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tbl_Team_DTO"></param>
        /// <param name="tbl_TeamMember_DTOList"></param>
        /// <returns></returns>
        public int SaveTeamWithMembers(tbl_Team_DTO tbl_Team_DTO, List<tbl_TeamMember_DTO> tbl_TeamMember_DTOList)
        {
            var teamId = -1;
            if (tbl_Team_DTO.Id <= 0)
            {
                teamId = SaveTeam(tbl_Team_DTO);
            }
            else
            {
                teamId = UpdateTeam(tbl_Team_DTO) ? tbl_Team_DTO.Id : -1;
            }
            if (teamId > 0)
            {
                foreach (tbl_TeamMember_DTO member in tbl_TeamMember_DTOList)
                {
                    member.TeamId = teamId;
                }
                var isSaved = UpdateTeamMembers(tbl_TeamMember_DTOList, teamId);
                if (isSaved)
                {
                    return teamId;
                }
            }
            return -1;
        }

        /// <summary>
        /// Updates an exsisting team in the database
        /// </summary>
        /// <param name="tbl_Team_DTO">Team instance with updated values</param>
        /// <returns>Returns true if the team was sucessfully updated, otherwise false</returns>
        public bool UpdateTeam(tbl_Team_DTO tbl_Team_DTO)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                itmcContext.Entry(tbl_Team_DTO.ToEntity()).State = System.Data.EntityState.Modified;
                return itmcContext.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// Deletes an exsisting team in the database
        /// </summary>
        /// <param name="tbl_Team_DTO">The team id</param>
        /// <returns>Returns true if the team was sucessfully deleted, otherwise false</returns>
        public bool DeleteTeam(int teamId)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var currentChangeRequest = itmcContext.tbl_Team.Find(teamId);
                var teamMemberIdList = (from individualTeamMember in itmcContext.tbl_TeamMember
                                        where individualTeamMember.TeamId == teamId
                                        select individualTeamMember.Id).ToList();
                tbl_TeamMember currentTeamMember = null;
                foreach (long teamMemberId in teamMemberIdList)
                {
                    currentTeamMember = itmcContext.tbl_TeamMember.Find(teamMemberId);
                    itmcContext.tbl_TeamMember.Remove(currentTeamMember);
                }
                itmcContext.tbl_Team.Remove(currentChangeRequest);
                return itmcContext.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// Updates an exsisting team in the database
        /// </summary>
        /// <param name="tbl_Team_DTO">Team instance with updated values</param>
        /// <returns>Returns true if the team was sucessfully updated, otherwise false</returns>
        public bool UpdateTeamMembers(List<tbl_TeamMember_DTO> newTeamMembers, int teamId)
        {
            var memberTeamId = (from member in newTeamMembers
                                select member.TeamId).Distinct().ToList();
            if (memberTeamId.Count == 0)
            {
                return DeleteTeam(teamId);
            }
            else
            {
                using (var itmcContext = new ITMCServiceCenter_SQLServer())
                {
                    var oldTeamMembers = GetTeamMembersByTeamId(memberTeamId.First());

                    var comparer = new TeamMemberEqualityComparer();
                    var keepThem = oldTeamMembers.Intersect(newTeamMembers, comparer); //oldTeamMembers.Intersect(newTeamMembers);
                    var removeThem = oldTeamMembers.Except(keepThem, comparer);
                    var addThem = newTeamMembers.Except(keepThem, comparer);
                    tbl_TeamMember currentTeamMember;
                    foreach (tbl_TeamMember_DTO memberToRemove in removeThem)
                    {
                        currentTeamMember = itmcContext.tbl_TeamMember.Find(memberToRemove.Id);
                        itmcContext.tbl_TeamMember.Remove(currentTeamMember);
                    }
                    foreach (tbl_TeamMember_DTO memberToAdd in addThem)
                    {
                        itmcContext.tbl_TeamMember.Add(memberToAdd.ToEntity());
                    }
                    return itmcContext.SaveChanges() > 0;
                }
            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Saves a new team into the database
        /// </summary>
        /// <param name="tbl_Project_DTO">Team to save</param>
        /// <returns>Returns the number of records affected, i.e. 1 if the team was sucessfully saved, otherwise 0</returns>
        private int SaveTeam(tbl_Team_DTO tbl_Team_DTO)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var teamDto = tbl_Team_DTO.ToEntity();
                itmcContext.tbl_Team.Add(teamDto);
                var isSaved = itmcContext.SaveChanges() > 0;
                if (isSaved)
                {
                    return teamDto.Id;
                }
                else
                {
                    return -1;
                }
            }
        }

         /// <summary>
        /// Saves a new team into the database
        /// </summary>
        /// <param name="tbl_Project_DTO">Team to save</param>
        /// <returns>Returns the number of records affected, i.e. 1 if the team was sucessfully saved, otherwise 0</returns>
        private void FillAllTeamMembers(List<tbl_TeamMember_DTO> members)
        {
            foreach (tbl_TeamMember_DTO member in members)
            {
                member.UserFullName = userUtility.GetUserFullName(member.UserId);
            }
        }
        #endregion
    }
}
