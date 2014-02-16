//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2014/02/12 - 15:04:35
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//-------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Linq;
using ITMCServiceCenter.Web.Database;

namespace ITMCServiceCenter.Web.Domain
{

    /// <summary>
    /// Assembler for <see cref="tbl_UserMaster"/> and <see cref="tbl_UserMasterDTO"/>.
    /// </summary>
    public static partial class tbl_UserMaster_Assembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="tbl_UserMasterDTO"/> converted from <see cref="tbl_UserMaster"/>.</param>
        static partial void OnDTO(this tbl_UserMaster entity, tbl_UserMasterDTO dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="tbl_UserMaster"/> converted from <see cref="tbl_UserMasterDTO"/>.</param>
        static partial void OnEntity(this tbl_UserMasterDTO dto, tbl_UserMaster entity);

        /// <summary>
        /// Converts this instance of <see cref="tbl_UserMasterDTO"/> to an instance of <see cref="tbl_UserMaster"/>.
        /// </summary>
        /// <param name="dto"><see cref="tbl_UserMasterDTO"/> to convert.</param>
        public static tbl_UserMaster ToEntity(this tbl_UserMasterDTO dto)
        {
            if (dto == null) return null;

            var entity = new tbl_UserMaster();

            entity.Id = dto.Id;
            entity.DesignationId = dto.DesignationId;
            entity.RoleId = dto.RoleId;
            entity.UserName = dto.UserName;
            entity.Password = dto.Password;
            entity.FirstName = dto.FirstName;
            entity.LastName = dto.LastName;
            entity.IsClient = dto.IsClient;
            entity.IsDisable = dto.IsDisable;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="tbl_UserMaster"/> to an instance of <see cref="tbl_UserMasterDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="tbl_UserMaster"/> to convert.</param>
        public static tbl_UserMasterDTO ToDTO(this tbl_UserMaster entity)
        {
            if (entity == null) return null;

            var dto = new tbl_UserMasterDTO();

            dto.Id = entity.Id;
            dto.DesignationId = entity.DesignationId;
            dto.RoleId = entity.RoleId;
            dto.UserName = entity.UserName;
            dto.Password = entity.Password;
            dto.FirstName = entity.FirstName;
            dto.LastName = entity.LastName;
            dto.IsClient = entity.IsClient;
            dto.IsDisable = entity.IsDisable;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="tbl_UserMasterDTO"/> to an instance of <see cref="tbl_UserMaster"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<tbl_UserMaster> ToEntities(this IEnumerable<tbl_UserMasterDTO> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="tbl_UserMaster"/> to an instance of <see cref="tbl_UserMasterDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<tbl_UserMasterDTO> ToDTOs(this IEnumerable<tbl_UserMaster> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
