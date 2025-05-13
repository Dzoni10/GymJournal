using GymJournal.Model;

namespace GymJournal.RepositoryInterfaces
{
    public interface IPersonRepository
    {
        Person GetByUserId(int id);
    }
}
