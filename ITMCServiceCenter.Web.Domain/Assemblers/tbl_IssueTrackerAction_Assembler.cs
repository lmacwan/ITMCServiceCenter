//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2014/02/12 - 15:04:34
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
    /// Assembler for <see cref="tbl_IssueTrackerAction"/> and <see cref="tbl_IssueTrackerActionDTO"/>.
    /// </summary>
    public static partial class tbl_IssueTrackerAction_Assembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="tbl_IssueTrackerActionDTO"/> converted from <see cref="tbl_IssueTrackerAction"/>.</param>
        static partial void OnDTO(this tbl_IssueTrackerAction entity, tbl_IssueTrackerActionDTO dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="tbl_IssueTrackerAction"/> converted from <see cref="tbl_IssueTrackerActionDTO"/>.</param>
        static partial void OnEntity(this tbl_IssueTrackerActionDTO dto, tbl_IssueTrackerAction entity);

        /// <summary>
        /// Converts this instance of <see cref="tbl_IssueTrackerActionDTO"/> to an instance of <see cref="tbl_IssueTrackerAction"/>.
        /// </summary>
        /// <param name="dto"><see cref="tbl_IssueTrackerActionDTO"/> to convert.</param>
        public static tbl_IssueTrackerAction ToEntity(this tbl_IssueTrackerActionDTO dto)
        {
            if (dto == null) return null;

            var entity = new tbl_IssueTrackerAction();

            entity.Id = dto.Id;
            entity.IssueTrackerId = dto.IssueTrackerId;
            entity.Action = dto.Action;
            entity.CreatedBy = dto.CreatedBy;
            entity.CreatedOn = dto.CreatedOn;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="tbl_IssueTrackerAction"/> to an instance of <see cref="tbl_IssueTrackerActionDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="tbl_IssueTrackerAction"/> to convert.</param>
        public static tbl_IssueTrackerActionDTO ToDTO(this tbl_IssueTrackerAction entity)
        {
            if (entity == null) return null;

            var dto = new tbl_IssueTrackerActionDTO();

            dto.Id = entity.Id;
            dto.IssueTrackerId = entity.IssueTrackerId;
            dto.Action = entity.Action;
            dto.CreatedBy = entity.CreatedBy;
            dto.CreatedOn = entity.CreatedOn;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="tbl_IssueTrackerActionDTO"/> to an instance of <see cref="tbl_IssueTrackerAction"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<tbl_IssueTrackerAction> ToEntities(this IEnumerable<tbl_IssueTrackerActionDTO> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="tbl_IssueTrackerAction"/> to an instance of <see cref="tbl_IssueTrackerActionDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<tbl_IssueTrackerActionDTO> ToDTOs(this IEnumerable<tbl_IssueTrackerAction> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
