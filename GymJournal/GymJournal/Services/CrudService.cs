using AutoMapper;
using FluentResults;
using GymJournal.Infrastructure;
using GymJournal.Model;
using GymJournal.RepositoryInterfaces;
using GymJournal.Startup;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GymJournal.Services
{
    public abstract class CrudService<TDto,TEntity> : BaseService<TDto,TEntity> where TEntity : Entity
    {
        protected readonly ICrudRepository<TEntity> _crudRepository;

        
        public CrudService(IMapper mapper) : base(mapper) { }
        protected CrudService(ICrudRepository<TEntity> crudRepository, IMapper mapper) : base(mapper)
        {
            _crudRepository = crudRepository;
        }

        public Result<PagedResult<TDto>> GetPaged(int page, int pageSize)
        {
            var result = _crudRepository.GetPaged(page, pageSize);
            return MapToDto(result);
        }

        public Result<TDto> Get(int id)
        {
            try
            {
                var result = _crudRepository.Get(id);
                return MapToDto(result);
            }
            catch (KeyNotFoundException e)
            {
                return Result.Fail(FailureCode.NotFound).WithError(e.Message);
            }
        }

        public virtual Result<TDto> Create(TDto entity)
        {
            try
            {
                var result = _crudRepository.Create(MapToEntity(entity));
                return MapToDto(result);
            }
            catch (ArgumentException e)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(e.Message);
            }
        }

        public virtual Result<TDto> Update(TDto entity)
        {
            try
            {
                var result = _crudRepository.Update(MapToEntity(entity));
                return MapToDto(result);
            }
            catch (KeyNotFoundException e)
            {
                return Result.Fail(FailureCode.NotFound).WithError(e.Message);
            }
            catch (ArgumentException e)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(e.Message);
            }
        }

        public virtual Result Delete(int id)
        {
            try
            {
                _crudRepository.Delete(id);
                return Result.Ok();
            }
            catch (KeyNotFoundException e)
            {
                return Result.Fail(FailureCode.NotFound).WithError(e.Message);
            }
        }

    }

}
