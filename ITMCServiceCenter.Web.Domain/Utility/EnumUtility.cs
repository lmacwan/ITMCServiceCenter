using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITMCServiceCenter.Web.Domain
{
    public static class EnumUtility
    {
        public static string ToString(Enum type)
        {

            if (type.GetType() == typeof(Types))
            {
                switch ((Types)type)
                {
                    case Types.ChangeRequest:
                        return "Change Request";
                    case Types.ChangeRequestPriority:
                        return "Change Request Priority";
                    case Types.ChangeRequestStatus:
                        return "Change Request Status";
                    case Types.Designation:
                        return "Designation";
                    case Types.Incident:
                        return "Incident";
                    case Types.IncidentLevel:
                        return "Incident Level";
                    case Types.IncidentStatus:
                        return "Incident Status";
                    case Types.Issue:
                        return "Issue";
                    case Types.IssueCategory:
                        return "Issue Category";
                    case Types.IssuePriority:
                        return "Issue Priority";
                    case Types.IssueStatus:
                        return "Issue Status";
                    case Types.Project:
                        return "Project";
                    case Types.ProjectStatus:
                        return "Project Status";
                    case Types.ProjectTask:
                        return "Project Task";
                    case Types.ProjectType:
                        return "Project Type";
                    case Types.Role:
                        return "Role";
                    case Types.Team:
                        return "Team Type";
                    case Types.Priority:
                        return "Priority";
                    case Types.ServiceRequestStatus:
                        return "Service Request Status";
                    case Types.ServiceRequestPriority:
                        return "Service Request Priority";
                    case Types.ServiceRequest:
                        return "Service Request";
                }
            }
            else if (type.GetType() == typeof(TeamType))
            {
                switch ((TeamType)type)
                {
                    case TeamType.Implementation:
                        return "Implementation Team";
                    case TeamType.Testing:
                        return "Testing Team";
                }
            }
            return string.Empty;
        }
    }
}
