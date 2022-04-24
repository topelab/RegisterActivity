using Topelab.RegisterActivity.Domain.Dtos;

namespace Topelab.RegisterActivity.Business.Services.Interfaces
{
    public interface ICriteriaService
    {
        TCriteria GetCriteriaMultipleDto<TEntity, TCriteria>(CriteriaDto criteriaDto)
            where TEntity : class
            where TCriteria : CriteriaMultipleDto<TEntity>, new();
    }
}
