using AutoMapper;
using GymJournal.DTOs;
using GymJournal.Model;
namespace GymJournal.Mappers
{
    public class GymJournalMapper : Profile
    {
        public GymJournalMapper() {
            CreateMap<PersonDTO, Person>().ReverseMap();
            CreateMap<TrainingDTO,Training>().ReverseMap();
        }
    }
}
