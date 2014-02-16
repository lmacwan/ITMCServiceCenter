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
    /// Assembler for <see cref="tbl_Project"/> and <see cref="tbl_ProjectDTO"/>.
    /// </summary>
    public static partial class tbl_Project_Assembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="tbl_ProjectDTO"/> converted from <see cref="tbl_Project"/>.</param>
        static partial void OnDTO(this tbl_Project entity, tbl_ProjectDTO dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="tbl_Project"/> converted from <see cref="tbl_ProjectDTO"/>.</param>
        static partial void OnEntity(this tbl_ProjectDTO dto, tbl_Project entity);

        /// <summary>
        /// Converts this instance of <see cref="tbl_ProjectDTO"/> to an instance of <see cref="tbl_Project"/>.
        /// </summary>
        /// <param name="dto"><see cref="tbl_ProjectDTO"/> to convert.</param>
        public static tbl_Project ToEntity(this tbl_ProjectDTO dto)
        {
            if (dto == null) return null;

            var entity = new tbl_Project();

            entity.Id = dto.Id;
            entity.ClientId = dto.ClientId;
            entity.StatusId = dto.StatusId;
            entity.TypeId = dto.TypeId;
            entity.Manager = dto.Manager;
            entity.Approver = dto.Approver;
            entity.QA = dto.QA;
            entity.CreatedBy = dto.CreatedBy;
            entity.ModifiedBy = dto.ModifiedBy;
            entity.Title = dto.Title;
            entity.Description = dto.Description;
            entity.StartDate = dto.StartDate;
            entity.EndDate = dto.EndDate;
            entity.EstimatedHours = dto.EstimatedHours;
            entity.EstimatedCost = dto.EstimatedCost;
            entity.PoNo = dto.PoNo;
            entity.Site = dto.Site;
            entity.CreatedOn = dto.CreatedOn;
            entity.ModifiedOn = dto.ModifiedOn;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="tbl_Project"/> to an instance of <see cref="tbl_ProjectDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="tbl_Project"/> to convert.</param>
        public static tbl_ProjectDTO ToDTO(this tbl_Project entity)
        {
            if (entity == null) return null;

            var dto = new tbl_ProjectDTO();

            dto.Id = entity.Id;
            dto.ClientId = entity.ClientId;
            dto.StatusId = entity.StatusId;
            dto.TypeId = entity.TypeId;
            dto.Manager = entity.Manager;
            dto.Approver = entity.Approver;
            dto.QA = entity.QA;
            dto.CreatedBy = entity.CreatedBy;
            dto.ModifiedBy = entity.ModifiedBy;
            dto.Title = entity.Title;
            dto.Description = entity.Description;
            dto.StartDate = entity.StartDate;
            dto.EndDate = entity.EndDate;
            dto.EstimatedHours = entity.EstimatedHours;
            dto.EstimatedCost = entity.EstimatedCost;
            dto.PoNo = entity.PoNo;
            dto.Site = entity.Site;
            dto.CreatedOn = entity.CreatedOn;
            dto.ModifiedOn = entity.ModifiedOn;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="tbl_ProjectDTO"/> to an instance of <see cref="tbl_Project"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<tbl_Project> ToEntities(this IEnumerable<tbl_ProjectDTO> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="tbl_Project"/> to an instance of <see cref="tbl_ProjectDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<tbl_ProjectDTO> ToDTOs(this IEnumerable<tbl_Project> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}