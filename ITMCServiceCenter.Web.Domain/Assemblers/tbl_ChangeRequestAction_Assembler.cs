//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2014/02/12 - 15:04:33
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
    /// Assembler for <see cref="tbl_ChangeRequestAction"/> and <see cref="tbl_ChangeRequestActionDTO"/>.
    /// </summary>
    public static partial class tbl_ChangeRequestAction_Assembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="tbl_ChangeRequestActionDTO"/> converted from <see cref="tbl_ChangeRequestAction"/>.</param>
        static partial void OnDTO(this tbl_ChangeRequestAction entity, tbl_ChangeRequestActionDTO dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="tbl_ChangeRequestAction"/> converted from <see cref="tbl_ChangeRequestActionDTO"/>.</param>
        static partial void OnEntity(this tbl_ChangeRequestActionDTO dto, tbl_ChangeRequestAction entity);

        /// <summary>
        /// Converts this instance of <see cref="tbl_ChangeRequestActionDTO"/> to an instance of <see cref="tbl_ChangeRequestAction"/>.
        /// </summary>
        /// <param name="dto"><see cref="tbl_ChangeRequestActionDTO"/> to convert.</param>
        public static tbl_ChangeRequestAction ToEntity(this tbl_ChangeRequestActionDTO dto)
        {
            if (dto == null) return null;

            var entity = new tbl_ChangeRequestAction();

            entity.Id = dto.Id;
            entity.ChangeRequestId = dto.ChangeRequestId;
            entity.Action = dto.Action;
            entity.CreatedBy = dto.CreatedBy;
            entity.CreatedOn = dto.CreatedOn;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="tbl_ChangeRequestAction"/> to an instance of <see cref="tbl_ChangeRequestActionDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="tbl_ChangeRequestAction"/> to convert.</param>
        public static tbl_ChangeRequestActionDTO ToDTO(this tbl_ChangeRequestAction entity)
        {
            if (entity == null) return null;

            var dto = new tbl_ChangeRequestActionDTO();

            dto.Id = entity.Id;
            dto.ChangeRequestId = entity.ChangeRequestId;
            dto.Action = entity.Action;
            dto.CreatedBy = entity.CreatedBy;
            dto.CreatedOn = entity.CreatedOn;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="tbl_ChangeRequestActionDTO"/> to an instance of <see cref="tbl_ChangeRequestAction"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<tbl_ChangeRequestAction> ToEntities(this IEnumerable<tbl_ChangeRequestActionDTO> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="tbl_ChangeRequestAction"/> to an instance of <see cref="tbl_ChangeRequestActionDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<tbl_ChangeRequestActionDTO> ToDTOs(this IEnumerable<tbl_ChangeRequestAction> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
