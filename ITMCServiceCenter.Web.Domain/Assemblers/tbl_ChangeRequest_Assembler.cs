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
    /// Assembler for <see cref="tbl_ChangeRequest"/> and <see cref="tbl_ChangeRequestDTO"/>.
    /// </summary>
    public static partial class tbl_ChangeRequest_Assembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="tbl_ChangeRequestDTO"/> converted from <see cref="tbl_ChangeRequest"/>.</param>
        static partial void OnDTO(this tbl_ChangeRequest entity, tbl_ChangeRequestDTO dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="tbl_ChangeRequest"/> converted from <see cref="tbl_ChangeRequestDTO"/>.</param>
        static partial void OnEntity(this tbl_ChangeRequestDTO dto, tbl_ChangeRequest entity);

        /// <summary>
        /// Converts this instance of <see cref="tbl_ChangeRequestDTO"/> to an instance of <see cref="tbl_ChangeRequest"/>.
        /// </summary>
        /// <param name="dto"><see cref="tbl_ChangeRequestDTO"/> to convert.</param>
        public static tbl_ChangeRequest ToEntity(this tbl_ChangeRequestDTO dto)
        {
            if (dto == null) return null;

            var entity = new tbl_ChangeRequest();

            entity.Id = dto.Id;
            entity.RequestedBy = dto.RequestedBy;
            entity.Approver = dto.Approver;
            entity.ChangeWriter = dto.ChangeWriter;
            entity.ProjectId = dto.ProjectId;
            entity.PriorityId = dto.PriorityId;
            entity.StatusId = dto.StatusId;
            entity.Title = dto.Title;
            entity.Description = dto.Description;
            entity.StartDate = dto.StartDate;
            entity.EndDate = dto.EndDate;
            entity.EstimatedHours = dto.EstimatedHours;
            entity.PercentComplete = dto.PercentComplete;
            entity.Impact = dto.Impact;
            entity.PoNo = dto.PoNo;
            entity.RequestedOn = dto.RequestedOn;
            entity.CreatedOn = dto.CreatedOn;
            entity.ModifiedOn = dto.ModifiedOn;
            entity.CreatedBy = dto.CreatedBy;
            entity.ModifiedBy = dto.ModifiedBy;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="tbl_ChangeRequest"/> to an instance of <see cref="tbl_ChangeRequestDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="tbl_ChangeRequest"/> to convert.</param>
        public static tbl_ChangeRequestDTO ToDTO(this tbl_ChangeRequest entity)
        {
            if (entity == null) return null;

            var dto = new tbl_ChangeRequestDTO();

            dto.Id = entity.Id;
            dto.RequestedBy = entity.RequestedBy;
            dto.Approver = entity.Approver;
            dto.ChangeWriter = entity.ChangeWriter;
            dto.ProjectId = entity.ProjectId;
            dto.PriorityId = entity.PriorityId;
            dto.StatusId = entity.StatusId;
            dto.Title = entity.Title;
            dto.Description = entity.Description;
            dto.StartDate = entity.StartDate;
            dto.EndDate = entity.EndDate;
            dto.EstimatedHours = entity.EstimatedHours;
            dto.PercentComplete = entity.PercentComplete;
            dto.Impact = entity.Impact;
            dto.PoNo = entity.PoNo;
            dto.RequestedOn = entity.RequestedOn;
            dto.CreatedOn = entity.CreatedOn;
            dto.ModifiedOn = entity.ModifiedOn;
            dto.CreatedBy = entity.CreatedBy;
            dto.ModifiedBy = entity.ModifiedBy;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="tbl_ChangeRequestDTO"/> to an instance of <see cref="tbl_ChangeRequest"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<tbl_ChangeRequest> ToEntities(this IEnumerable<tbl_ChangeRequestDTO> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="tbl_ChangeRequest"/> to an instance of <see cref="tbl_ChangeRequestDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<tbl_ChangeRequestDTO> ToDTOs(this IEnumerable<tbl_ChangeRequest> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
