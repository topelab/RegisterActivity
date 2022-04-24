using Microsoft.EntityFrameworkCore;
using System.Linq;
using Topelab.RegisterActivity.Domain.Dtos;

namespace Topelab.RegisterActivity.Business.Extensions
{
    /// <summary>
    /// Extensions to IQueryable types
    /// </summary>
    public static class QueryableExtensions
    {
        /// <summary>
        /// Gets the page.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <returns>Get page <paramref name="pageNumber"/> with <paramref name="pageSize"/> elements</returns>
        public static IQueryable<T> GetPage<T>(this IQueryable<T> list, int pageSize, int pageNumber)
            where T : class
        {
            if (pageSize > 0)
            {
                if (pageNumber > 0)
                {
                    list = list.Skip(pageNumber * pageSize);
                }
                list = list.Take(pageSize);
            }

            return list.AsNoTracking();
        }

        /// <summary>
        /// Gets the page.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list.</param>
        /// <param name="criteria">The criteria.</param>
        /// <returns>Gets the page based on <paramref name="criteria"/></returns>
        public static IQueryable<T> GetPage<T>(this IQueryable<T> list, CriteriaDto<T> criteria)
            where T : class
        {
            list = criteria.Filter != null
                ? list.Where(criteria.Filter)
                : list;

            if (criteria.Order != null)
            {
                list = criteria.Descending ? list.OrderByDescending(criteria.Order) : list.OrderBy(criteria.Order);
            }

            return list.GetPage(criteria.PageSize, criteria.PageNumber);
        }

        /// <summary>
        /// Gets the page.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list.</param>
        /// <param name="criteria">The criteria.</param>
        /// <returns>Gets the page based on <paramref name="criteria"/></returns>
		public static IQueryable<T> GetPage<T>(this IQueryable<T> list, CriteriaMultipleDto<T> criteria)
			where T : class
		{
			if (criteria.Filters != null)
			{
				foreach (var item in criteria.Filters)
				{
					list = list.Where(item.Filter);
				}
			}

			if (criteria.Orders?.Any() == true)
			{
				var first = criteria.Orders.First();
				var orderedList = first.Descending ? list.OrderByDescending(first.Order) : list.OrderBy(first.Order);
				foreach (var item in criteria.Orders.Skip(1))
				{
					orderedList = item.Descending ? orderedList.ThenByDescending(item.Order) : orderedList.ThenBy(item.Order);
				}

				return orderedList.GetPage(criteria.PageSize, criteria.PageNumber);
			}
			else
			{
				return list.GetPage(criteria.PageSize, criteria.PageNumber);
			}
		}
	}
}
