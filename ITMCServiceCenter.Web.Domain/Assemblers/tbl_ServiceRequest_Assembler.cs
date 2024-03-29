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
    /// Assembler for <see cref="tbl_ServiceRequest"/> and <see cref="tbl_ServiceRequestDTO"/>.
    /// </summary>
    public static partial class tbl_ServiceRequest_Assembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="tbl_ServiceRequestDTO"/> converted from <see cref="tbl_ServiceRequest"/>.</param>
        static partial void OnDTO(this tbl_ServiceRequest entity, tbl_ServiceRequestDTO dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="tbl_ServiceRequest"/> converted from <see cref="tbl_ServiceRequestDTO"/>.</param>
        static partial void OnEntity(this tbl_ServiceRequestDTO dto, tbl_ServiceRequest entity);

        /// <summary>
        /// Converts this instance of <see cref="tbl_ServiceRequestDTO"/> to an instance of <see cref="tbl_ServiceRequest"/>.
        /// </summary>
        /// <param name="dto"><see cref="tbl_ServiceRequestDTO"/> to convert.</param>
        public static tbl_ServiceRequest ToEntity(this tbl_ServiceRequestDTO dto)
        {
            if (dto == null) return null;

            var entity = new tbl_ServiceRequest();

            entity.Id = dto.Id;
            entity.RequestedBy = dto.RequestedBy;
            entity.ProjectId = dto.ProjectId;
            entity.StatusId = dto.StatusId;
            entity.PriorityId = dto.PriorityId;
            entity.PreviousStatusId = dto.PreviousStatusId;
            entity.Title = dto.Title;
            entity.Description = dto.Description;
            entity.StartDate = dto.StartDate;
            entity.EndDate = dto.EndDate;
            entity.EstimatedHours = dto.EstimatedHours;
            entity.PercentComplete = dto.PercentComplete;
            entity.PoNo = dto.PoNo;
            entity.CreatedOn = dto.CreatedOn;
            entity.ModifiedOn = dto.ModifiedOn;
            entity.RequestedOn = dto.RequestedOn;
            entity.CreatedBy = dto.CreatedBy;
            entity.ModifiedBy = dto.ModifiedBy;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="tbl_ServiceRequest"/> to an instance of <see cref="tbl_ServiceRequestDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="tbl_ServiceRequest"/> to convert.</param>
        public static tbl_ServiceRequestDTO ToDTO(this tbl_ServiceRequest entity)
        {
            if (entity == null) return null;

            var dto = new tbl_ServiceRequestDTO();

            dto.Id = entity.Id;
            dto.RequestedBy = entity.RequestedBy;
            dto.ProjectId = entity.ProjectId;
            dto.StatusId = entity.StatusId;
            dto.PriorityId = entity.PriorityId;
            dto.PreviousStatusId = entity.PreviousStatusId;
            dto.Title = entity.Title;
            dto.Description = entity.Description;
            dto.StartDate = entity.StartDate;
            dto.EndDate = entity.EndDate;
            dto.EstimatedHours = entity.EstimatedHours;
            dto.PercentComplete = entity.PercentComplete;
            dto.PoNo = entity.PoNo;
            dto.CreatedOn = entity.CreatedOn;
            dto.ModifiedOn = entity.ModifiedOn;
            dto.RequestedOn = entity.RequestedOn;
            dto.CreatedBy = entity.CreatedBy;
            dto.ModifiedBy = entity.ModifiedBy;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="tbl_ServiceRequestDTO"/> to an instance of <see cref="tbl_ServiceRequest"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<tbl_ServiceRequest> ToEntities(this IEnumerable<tbl_ServiceRequestDTO> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="tbl_ServiceRequest"/> to an instance of <see cref="tbl_ServiceRequestDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<tbl_ServiceRequestDTO> ToDTOs(this IEnumerable<tbl_ServiceRequest> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
