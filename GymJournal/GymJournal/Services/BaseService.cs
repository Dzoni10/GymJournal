using AutoMapper;
using FluentResults;
using GymJournal.Infrastructure;
using GymJournal.Model;

namespace GymJournal.Services
{
    public abstract class BaseService<TDto,TEntity> where TEntity : Entity
    {
        private readonly IMapper _mapper;

        protected BaseService(IMapper mapper)
        {
            _mapper = mapper;
        }
        protected TEntity MapToEntity(TDto dto)
        {
            return _mapper.Map<TEntity>(dto);
        }

        protected List<TEntity> MapToEntity(List<TDto> dtos)
        {
            return dtos.Select(dto => _mapper.Map<TEntity>(dto)).ToList();
        }

        protected TDto MapToDto(TEntity result)
        {
            return _mapper.Map<TDto>(result);
        }

        protected Result<List<TDto>> MapToDto(Result<List<TEntity>> result)
        {
            if (result.IsFailed) return Result.Fail(result.Errors);
            return result.Value.Select(_mapper.Map<TDto>).ToList();
        }

        protected Result<PagedResult<TDto>> MapToDto(Result<PagedResult<TEntity>> result)
        {
            if (result.IsFailed) return Result.Fail(result.Errors);

            var items = result.Value.Results.Select(_mapper.Map<TDto>).ToList();
            return new PagedResult<TDto>(items, result.Value.TotalCount);
        }
    }
}
