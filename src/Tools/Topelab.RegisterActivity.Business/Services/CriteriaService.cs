using System.Collections.Generic;
using System.Linq;
using Topelab.Core.Adapters.Extensions;
using Topelab.RegisterActivity.Business.Services.Interfaces;
using Topelab.RegisterActivity.Domain.Dtos;

namespace Topelab.RegisterActivity.Business.Services
{
    /// <summary>
    /// Services for Criteria entities
    /// </summary>
    public class CriteriaService : ICriteriaService
    {
        /// <summary>
        /// Converts <paramref name="criteriaDto"/> to a type based on <see cref="CriteriaMultipleDto{TEntity}"/>
        /// </summary>
        /// <typeparam name="TEntity">Type for entity</typeparam>
        /// <typeparam name="TCriteria">Type for output criteria</typeparam>
        /// <param name="criteriaDto">Criteria</param>
        /// <returns>Criteria multiple</returns>
        public TCriteria GetCriteriaMultipleDto<TEntity, TCriteria>(CriteriaDto criteriaDto)
            where TEntity : class
            where TCriteria : CriteriaMultipleDto<TEntity>, new()
        {
            List<FilterDto<TEntity>> filterDtos = null;

            if (!string.IsNullOrWhiteSpace(criteriaDto.Filter))
            {
                filterDtos = new List<FilterDto<TEntity>>();
                var filter = new FilterDto<TEntity> { Filter = criteriaDto.Filter.BuildExpression<TEntity>().Result };
                filterDtos.Add(filter);
            }

            var orderDtos = criteriaDto.Order?.BuildSortExpressions<TEntity>().Select(r => new OrderDto<TEntity> { Order = r.Order, Descending = r.Descending }).ToList();

            return new TCriteria
            {
                Filters = filterDtos,
                Orders = orderDtos,
                PageNumber = criteriaDto.PageNumber,
                PageSize = criteriaDto.PageSize
            };

        }
    }
}
