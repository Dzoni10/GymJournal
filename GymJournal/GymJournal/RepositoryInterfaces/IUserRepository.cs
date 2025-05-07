using GymJournal.Model;

namespace GymJournal.RepositoryInterfaces
{
    public interface IUserRepository
    {
        bool Exists(string username);
        User? GetActiveByName(string username);
        User Create(User user);
        long GetPersonId(long userId);
        User GetUsername(long userId);
    }
}
