using ITMCServiceCenter.Web.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ITMCServiceCenter.Web.BLL
{
    public class TeamBusinessLogic
    {
        #region Data Members
        private TypeUtility typeUtility = new TypeUtility();
        #endregion

        #region Static Methods
        /// <summary>
        /// Gets all change requests for a given project from databse
        /// </summary>
        /// <param name="projectId">Project id</param>
        /// <returns>List of change requests</returns>
        public static tbl_Team_DTO GetTeam(Types entity, int entityId, TeamType type)
        {
            tbl_Team_DTO team = null;
            var teamDetails = ServiceReference.ITMCServiceClient.GetTeam(entity, entityId, type);
            if (teamDetails.Success)
            {
                team = teamDetails.Value;
            }
            return team;
        }

        /// <summary>
        /// Gets all teams from database
        /// </summary>
        /// <returns>List of all teams</returns>
        public static List<tbl_Team_DTO> GetTeams()
        {
            List<tbl_Team_DTO> teamlist = null;
            var teamDetails = ServiceReference.ITMCServiceClient.GetTeams();
            if (teamDetails.Success)
            {
                teamlist = teamDetails.Value.ToList();
            }
            return teamlist;
        }

        /// <summary>
        /// Gets all change requests for a given project from databse
        /// </summary>
        /// <param name="projectId">Project id</param>
        /// <returns>List of change requests</returns>
        public static List<int> GetTeamMembersIdByTeam(tbl_Team_DTO team)
        {
            var teamMembers = GetTeamMembersByTeam(team);
            return (from teamMember in teamMembers
                    select teamMember.UserId
                    ).ToList();
        }
        #endregion

        #region Instance Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="membersId"></param>
        /// <param name="teamType"></param>
        /// <param name="relateType"></param>
        /// <param name="relateToId"></param>
        /// <param name="teamId"></param>
        /// <returns></returns>
        public int SaveTeamWithMembers(List<int> membersId, TeamType teamType, Types relateType, int relateToId, int teamId = -1)
        {
            
            
            //  Get team members from ids
            List<tbl_TeamMember_DTO> teamMembers = GetTeamMembers(membersId);

            //  Get team
            tbl_Team_DTO teamDto = null;
            if (teamId <= 0)
            {
                //  If team is new, get a blank team object and fill it with RelateToId, RelatedTypeId and RelaytedType
                teamDto = GetNewTeam(teamType);
                teamDto.RelatedToId = relateToId;
                teamDto.RelatedTypeId = typeUtility.GetTypeIdByEnum(relateType);
            }
            else
            {
                //  If team already exists, get a team instance
                teamDto = GetTeam(relateType, relateToId, teamType);
            }

            //  Save the team with new members, after validation
            int result = -1;
            if (Validate(teamDto).IsValid)
            {
                var teamDetails = ServiceReference.ITMCServiceClient.SaveTeamWithMembers(teamDto, teamMembers.ToArray());
                if (teamDetails.Success)
                {
                    result = teamDetails.Value;
                }
            }
            return result;
        }

        /// <summary>
        /// Updates an exsisting team in the database
        /// </summary>
        /// <param name="tbl_Team_DTO">Team instance with updated values</param>
        /// <returns>Returns true if the team was sucessfully updated, otherwise false</returns>
        public bool UpdateTeam(tbl_Team_DTO tbl_Team_DTO)
        {
            var teamDetails = ServiceReference.ITMCServiceClient.UpdateTeam(tbl_Team_DTO);
            bool result = false;
            if (teamDetails.Success)
            {
                result = teamDetails.Value;
            }
            return result;
        }

        /// <summary>
        /// Deletes an exsisting team in the database
        /// </summary>
        /// <param name="tbl_Team_DTO">The team id</param>
        /// <returns>Returns true if the team was sucessfully deleted, otherwise false</returns>
        public bool DeleteTeam(int teamId)
        {
            var teamDetails = ServiceReference.ITMCServiceClient.DeleteTeam(teamId);
            bool result = false;
            if (teamDetails.Success)
            {
                result = teamDetails.Value;
            }
            return result;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="teamType"></param>
        /// <returns></returns>
        private tbl_Team_DTO GetNewTeam(TeamType teamType)
        {
            tbl_Team_DTO team = null;
            var teamDetails = ServiceReference.ITMCServiceClient.GetEntityByTeamType(teamType);
            if (teamDetails.Success)
            {
                team = new tbl_Team_DTO();
                team.TeamType = teamType;
                team.TypeId = teamDetails.Value.Id;
                return team;
            }
            return team;
        }

        /// <summary>
        /// Gets all change requests for a given project from databse
        /// </summary>
        /// <param name="projectId">Project id</param>
        /// <returns>List of change requests</returns>
        public static List<tbl_TeamMember_DTO> GetTeamMembersByTeam(tbl_Team_DTO team)
        {
            List<tbl_TeamMember_DTO> result = new List<tbl_TeamMember_DTO>();
            if (team != null)
            {
                var teamDetails = ServiceReference.ITMCServiceClient.GetTeamMembersByTeamId(team.Id);
                if (teamDetails.Success)
                {
                    result = teamDetails.Value.ToList();
                }
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="memberIdList"></param>
        /// <returns></returns>
        private List<tbl_TeamMember_DTO> GetTeamMembers(List<int> memberIdList)
        {
            List<tbl_TeamMember_DTO> newTeamMembers = new List<tbl_TeamMember_DTO>();
            tbl_TeamMember_DTO newMember;
            foreach (int memberId in memberIdList)
            {
                newMember = GetNewTeamMemberByUserId(memberId);
                if (newMember == null)
                {
                    continue;
                }
                else
                {
                    newTeamMembers.Add(newMember);
                }
            }
            return newTeamMembers;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public tbl_TeamMember_DTO GetNewTeamMemberByUserId(int id)
        {
            tbl_TeamMember_DTO validTeamMember = null;
            var validUser = UserBusinessLogic.GetUser(id);
            if (validUser != null)
            {
                validTeamMember = new tbl_TeamMember_DTO();
                validTeamMember.UserId = validUser.Id;
                validTeamMember.UserFullName = validUser.UserFullName;
            }
            return validTeamMember;

        }

        private static tbl_Team_DTO Validate(tbl_Team_DTO tbl_Team_DTO)
        {
            if (tbl_Team_DTO == null)
            {
                tbl_Team_DTO = new tbl_Team_DTO();
            }
            else if (tbl_Team_DTO.RelatedToId == -1)
            {
                //todo: Validate related to id equals -1
            }
            return tbl_Team_DTO;
        }
        #endregion
    }
}
