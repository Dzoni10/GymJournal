using GymJournal.Infrastructure.Database;
using GymJournal.Model;
using GymJournal.RepositoryInterfaces;

namespace GymJournal.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly GymJournalContext _dbContext;

        public UserRepository(GymJournalContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Exists(string username)
        {
            return _dbContext.Users.Any(user => user.Username == username);

        }

        public User? GetActiveByName(string username)
        {
            return _dbContext.Users.FirstOrDefault(user=>user.Username == username);
        }

        public User Create(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return user;
        }

        public long GetPersonId(long userId)
        {
            var person = _dbContext.People.FirstOrDefault(i => i.UserId == userId);
            if (person == null) throw new KeyNotFoundException("Not found.");
            return person.Id;
        }

        public User GetUsername(long userId)
        {
            var person = _dbContext.Users.FirstOrDefault(i => i.Id == userId);
            if (person == null) throw new KeyNotFoundException("Not found.");
            return person;
        }
    }

}
