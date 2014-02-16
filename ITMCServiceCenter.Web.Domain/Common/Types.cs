using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITMCServiceCenter.Web.Domain
{
    [DataContract]
    public enum Types
    {
        //  Types with no entities
        [EnumMember]
        ServiceRequest,
        [EnumMember]
        ChangeRequest,
        [EnumMember]
        Incident,
        [EnumMember]
        Issue,
        [EnumMember]
        Project,
        [EnumMember]
        ProjectTask,

        //  Types with entities
        [EnumMember]
        ChangeRequestPriority,
        [EnumMember]
        ChangeRequestStatus,
        [EnumMember]
        Designation,
        [EnumMember]
        IncidentLevel,
        [EnumMember]
        IncidentStatus,
        [EnumMember]
        IssueCategory,
        [EnumMember]
        IssuePriority,
        [EnumMember]
        IssueStatus,
        [EnumMember]
        ProjectStatus,
        [EnumMember]
        ProjectType,
        [EnumMember]
        Priority,
        [EnumMember]
        ProjectTaskType,
        [EnumMember]
        Role,
        [EnumMember]
        ServiceRequestStatus,
        [EnumMember]
        ServiceRequestPriority,
        [EnumMember]
        Team
    }
}