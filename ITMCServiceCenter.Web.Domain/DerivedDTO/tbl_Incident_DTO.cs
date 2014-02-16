using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITMCServiceCenter.Web.Domain
{
   public class tbl_Incident_DTO : tbl_IncidentDTO
   {

       #region Additional Properties

       [DataMember()]
       public string ProjectTitle { get; set; }

       [DataMember()]
       public string CreatedByName { get; set; }

       [DataMember()]
       public string ModifiedByName { get; set; }

       [DataMember()]
       public string AssignedToName { get; set; }

       [DataMember()]
       public string RequestedByName { get; set; }

       [DataMember()]
       public string Level { get; set; }
        
       [DataMember()]
       public string Status { get; set; }
       #endregion
   }
}
