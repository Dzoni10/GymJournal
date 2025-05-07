using GymJournal.Infrastructure.Database;
using GymJournal.Model;
using GymJournal.RepositoryInterfaces;

namespace GymJournal.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly GymJournalContext _dbContext;


        public PersonRepository(GymJournalContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ICollection<Person> GetAll()
        {
            return _dbContext.People.ToList();
        }

        public Person GetByUserId(int id)
        {
            return _dbContext.People.SingleOrDefault(p => p.UserId == id);
        }

        public void Create(Person person)
        {
            _dbContext.People.Add(person);
            _dbContext.SaveChanges();
        }
    }
}
