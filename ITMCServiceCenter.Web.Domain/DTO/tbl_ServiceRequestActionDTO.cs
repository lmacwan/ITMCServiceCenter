//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2014/02/12 - 13:08:59
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
    public partial class tbl_ServiceRequestActionDTO : CommonModel, IAction
    {
        [DataMember()]
        public Int32 Id { get; set; }

        [DataMember()]
        public Int32 ServiceRequestId { get; set; }

        [DataMember()]
        public String Action { get; set; }

        [DataMember()]
        public String CreatedBy { get; set; }

        [DataMember()]
        public DateTime CreatedOn { get; set; }

        [DataMember()]
        public tbl_ServiceRequestDTO tbl_ServiceRequest { get; set; }


        public Types RelatedType
        {
            get { return Types.ServiceRequest; }
        }

        public int RelatedToId
        {
            get { return Id; }
        }
    }
}