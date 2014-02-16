using ITMCServiceCenter.Web.Domain;
using System;

namespace ITMCServiceCenter.Web.BLL
{
    public class TypeUtility
    {
        #region Methods
        public tbl_TypeMaster_DTO GetTypeByEnum(Types typeEnum)
        {
            tbl_TypeMaster_DTO typeMaster = null;
            var typeDetails = ServiceReference.ITMCServiceClient.GetTypeByEnum(typeEnum);
            if (typeDetails.Success)
            {
                typeMaster = typeDetails.Value;
            }
            return typeMaster;
        }

        public byte GetTypeIdByEnum(Types typeEnum)
        {
            var type = GetTypeByEnum(typeEnum);
            byte typeId;
            if (type == null)
            {
                typeId = Convert.ToByte(-1);
            }
            else
            {
                typeId = type.Id;
            }
            return typeId;
        }

        public string GetTypeNameByEnum(Types typeEnum)
        {
            var type = GetTypeByEnum(typeEnum);
            string typeName;
            if (type == null)
            {
                typeName = string.Empty;
            }
            else
            {
                typeName = type.Type;
            }
            return typeName;
        }
        #endregion
    }
}