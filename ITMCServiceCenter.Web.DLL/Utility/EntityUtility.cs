using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITMCServiceCenter.Web.Domain;
using ITMCServiceCenter.Web.Database;

namespace ITMCServiceCenter.Web.DLL
{
    public class EntityUtility
    {
        public System.Collections.IList GetEntitiesByType(Types entityType)
        {
            if (entityType == Types.ProjectTaskType)
            {
                return GetAllProjectTaskTypes();
            }
            else
            {
                var entityTypeString = EnumUtility.ToString(entityType);
                using (var itmcContext = new ITMCServiceCenter_SQLServer())
                {
                    var result =
                            (from type in itmcContext.tbl_TypeMaster
                             join e in itmcContext.tbl_Entity
                             on type.Id equals e.TypeMasterId
                             where type.Type == entityTypeString
                             select new tbl_Entity_DTO()
                             {
                                 Id = e.Id,
                                 Name = e.Name
                             }
                             ).ToList();
                    return result;
                }
            }
        }

        public tbl_Entity_DTO GetEntityByTeamType(Enum entityType)
        {
            var entityName = EnumUtility.ToString(entityType);
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result =
                        (from entity in itmcContext.tbl_Entity
                         where entity.Name == entityName
                         select new tbl_Entity_DTO()
                         {
                             Id = entity.Id,
                             TypeMasterId = entity.TypeMasterId,
                             Name = entity.Name
                         }
                         ).FirstOrDefault();
                return result;
            }
        }

        public static List<tbl_ProjectTaskType_DTO> GetAllProjectTaskTypes()
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result =
                        (from type in itmcContext.tbl_ProjectTaskType
                         select new tbl_ProjectTaskType_DTO()
                         {
                             Id = type.Id,
                             Type = type.Type,
                             ProjectId = type.ProjectId
                         }
                         ).ToList();
                return result;
            }
        }

        public static List<tbl_ProjectTaskType_DTO> GetProjectTaskTypesByProjectId(short projectId)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result =
                        (from type in itmcContext.tbl_ProjectTaskType
                         where type.ProjectId == projectId
                         select new tbl_ProjectTaskType_DTO()
                         {
                             Id = type.Id,
                             Type = type.Type,
                             ProjectId = type.ProjectId
                         }
                         ).ToList();
                return result;
            }
        }

        public static tbl_ProjectTaskType_DTO GetProjectTaskTypeById(int Id)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result =
                        (from type in itmcContext.tbl_ProjectTaskType
                         where type.Id == Id
                         select new tbl_ProjectTaskType_DTO()
                         {
                             Id = type.Id,
                             Type = type.Type,
                             ProjectId = type.ProjectId
                         }
                         ).FirstOrDefault();
                return result;
            }
        }

        public string GetEntityName(short? entityId)
        {
            using (var itmcContext = new ITMCServiceCenter_SQLServer())
            {
                var result =
                        (from entity in itmcContext.tbl_Entity
                         where entity.Id == entityId
                         select new tbl_Entity_DTO()
                         {
                             Id = entity.Id,
                             TypeMasterId = entity.TypeMasterId,
                             Name = entity.Name
                         }
                         ).FirstOrDefault();
                return result == null ? string.Empty : result.Name;
            }
        }
    }
}
