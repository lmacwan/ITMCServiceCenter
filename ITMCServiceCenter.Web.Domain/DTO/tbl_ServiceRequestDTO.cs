//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2014/02/12 - 15:04:31
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//-------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ITMCServiceCenter.Web.Domain
{
    [DataContract()]
    public partial class tbl_ServiceRequestDTO : CommonModel
    {
        [DataMember()]
        public Int32 Id { get; set; }

        [DataMember()]
        public Int32 RequestedBy { get; set; }

        [DataMember()]
        public Int16 ProjectId { get; set; }

        [DataMember()]
        public Int16 StatusId { get; set; }

        [DataMember()]
        public Int16 PriorityId { get; set; }

        [DataMember()]
        public Nullable<Int16> PreviousStatusId { get; set; }

        [DataMember()]
        public String Title { get; set; }

        [DataMember()]
        public String Description { get; set; }

        [DataMember()]
        public Nullable<DateTime> StartDate { get; set; }

        [DataMember()]
        public Nullable<DateTime> EndDate { get; set; }

        [DataMember()]
        public Int16 EstimatedHours { get; set; }

        [DataMember()]
        public Byte PercentComplete { get; set; }

        [DataMember()]
        public Int32 PoNo { get; set; }

        [DataMember()]
        public DateTime CreatedOn { get; set; }

        [DataMember()]
        public Nullable<DateTime> ModifiedOn { get; set; }

        [DataMember()]
        public DateTime RequestedOn { get; set; }

        [DataMember()]
        public String CreatedBy { get; set; }

        [DataMember()]
        public String ModifiedBy { get; set; }

        [DataMember()]
        public tbl_EntityDTO tbl_Entity { get; set; }

        [DataMember()]
        public tbl_EntityDTO tbl_Entity1 { get; set; }

        [DataMember()]
        public tbl_EntityDTO tbl_Entity2 { get; set; }

        [DataMember()]
        public tbl_ProjectDTO tbl_Project { get; set; }

        [DataMember()]
        public tbl_ProjectDTO tbl_Project1 { get; set; }

        [DataMember()]
        public tbl_UserMasterDTO tbl_UserMaster { get; set; }

        [DataMember()]
        public List<tbl_ServiceRequestActionDTO> tbl_ServiceRequestAction { get; set; }

        [DataMember()]
        public List<tbl_ServiceRequestDocumentDTO> tbl_ServiceRequestDocument { get; set; }
    }
}
