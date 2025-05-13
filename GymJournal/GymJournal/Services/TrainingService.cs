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

        public Result<PagedResult<TrainingDTO>> GetUserTrainings(int userId,int page, int pageSize)
        {
            var query = _trainingRepository.GetAllUserTrainings(userId);
            var totalCount = query.Count();

            var items = query.OrderBy(t=>t.Id).Skip((page-1)*pageSize).Take(pageSize).ToList();

            var dtos = _mapper.Map<List<TrainingDTO>>(items);
            return Result.Ok(new PagedResult<TrainingDTO>(dtos, totalCount));
        }

        public async Task<List<TrainingProgressDTO>> GetWeeklyProgressAsync(long userId, int year, int month)
        {
            var result = await _trainingRepository.GetWeeklyProgress(userId, year, month);
            var dtos = _mapper.Map<List<TrainingProgressDTO>>(result);
            return dtos;
        }
    }
}
