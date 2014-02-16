using ITMCServiceCenter.Web.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITMCServiceCenter.Web.UI
{
    public class TeamModel
    {
        #region Data Members
        private MarkupList<tbl_TeamMember_DTO> members;
        #endregion

        #region Constructor
        public TeamModel()
        {
            Team = new tbl_Team_DTO();
            SelectedMembers = new MarkupList<tbl_TeamMember_DTO>();
            SelectedMembersId = new List<int>();
        }
        #endregion

        #region Properties
        public tbl_Team_DTO Team { get; set; }

        public MarkupList<tbl_TeamMember_DTO> SelectedMembers
        {
            get { return members; }
            set
            {
                members = value;
                SelectedMembersId = (from member in members
                                     select member.UserId).ToList();
            }
        }

        public List<string> SelectedMembersFullName
        {
            get
            {
                return (from member in SelectedMembers
                        select member.UserFullName).ToList();
            }
        }

        public List<int> SelectedMembersId { get; set; }

        public string MembersString { get { return SelectedMembers.ToString(); } }
        #endregion
    }
}