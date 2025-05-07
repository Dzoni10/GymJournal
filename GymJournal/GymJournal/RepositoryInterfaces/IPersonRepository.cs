using GymJournal.Model;

namespace GymJournal.RepositoryInterfaces
{
    public interface IPersonRepository
    {
        ICollection<Person> GetAll();
        Person GetByUserId(int id);
        void Create(Person person);
    }
}
