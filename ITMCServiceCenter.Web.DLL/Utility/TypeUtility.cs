using ITMCServiceCenter.Web.Database;
using ITMCServiceCenter.Web.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITMCServiceCenter.Web.DLL
{
    public class TypeUtility
    {
        public  tbl_TypeMaster_DTO GetTypeByEnum(Enum type)
        {
            var typeName = EnumUtility.ToString(type);
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result = (from typeMaster in itmcContext.tbl_TypeMaster
                              where typeMaster.Type == typeName
                              select new tbl_TypeMaster_DTO()
                              {
                                  Id = typeMaster.Id,
                                  Type = typeMaster.Type
                              }
                         ).FirstOrDefault();
                return result;
            }
        }

        public string GetTypeName(Enum type)
        {
            var typeDto = GetTypeByEnum(type);
            return typeDto == null ? string.Empty : typeDto.Type;
        }
    }
}
