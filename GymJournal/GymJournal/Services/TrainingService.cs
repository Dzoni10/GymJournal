using AutoMapper;
using FluentResults;
using GymJournal.DTOs;
using GymJournal.Model;
using GymJournal.RepositoryInterfaces;
using GymJournal.ServiceInterfaces;
using GymJournal.Infrastructure;

namespace GymJournal.Services
{
    public class TrainingService: CrudService<TrainingDTO,Training>, ITrainingService   
    {
        private readonly ITrainingRepository _trainingRepository;
        protected readonly IMapper _mapper;
        public TrainingService(ICrudRepository<Training> repository, ITrainingRepository trainingRepository, IMapper mapper) : base(repository,mapper)
        {
            _trainingRepository = trainingRepository;
            _mapper = mapper;
        }

        public Result<PagedResult<TrainingDTO>> GetCardio(int page, int pageSize)
        {
            var query = _trainingRepository.GetCardio();
            var totalCount = query.Count();

            var items = query
                .OrderBy(t => t.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize).ToList();

            var dtos = _mapper.Map<List<TrainingDTO>>(items);

            return Result.Ok(new PagedResult<TrainingDTO>(dtos,totalCount)); 
            
        }

        public Result<PagedResult<TrainingDTO>> GetFlexibility(int page, int pageSize)
        {
            var query = _trainingRepository.GetFlexibility();
            var totalCount = query.Count();

            var items = query
                .OrderBy(t => t.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize).ToList();

            var dtos = _mapper.Map<List<TrainingDTO>>(items);

            return Result.Ok(new PagedResult<TrainingDTO>(dtos, totalCount));
        }

        public Result<PagedResult<TrainingDTO>> GetStrength(int page, int pageSize)
        {
            var query = _trainingRepository.GetStrength();
            var totalCount = query.Count();

            var items = query
                .OrderBy(t => t.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize).ToList();

            var dtos = _mapper.Map<List<TrainingDTO>>(items);

            return Result.Ok(new PagedResult<TrainingDTO>(dtos, totalCount));
        }

        //public Result<TrainingDTO> GetByTrainingId(int id)
        //{
        //    return MapToDto(_trainingRepository.GetByTrainingId(id));
        //}


    }
}
