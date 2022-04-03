using Tools.TogglData.Domain.Dtos;

namespace Tools.TogglData.Business.Services.Interfaces
{
    public interface ICriteriaService
    {
        TCriteria GetCriteriaMultipleDto<TEntity, TCriteria>(CriteriaDto criteriaDto)
            where TEntity : class
            where TCriteria : CriteriaMultipleDto<TEntity>, new();
    }
}
