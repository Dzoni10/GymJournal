using GymJournal.Model;

namespace GymJournal.RepositoryInterfaces
{
    public interface IUserRepository
    {
        bool Exists(string username);
        bool ExistsEmail(string email);
        User? GetActiveByName(string username);
        User Create(User user);
        long GetPersonId(long userId);
        User GetUsername(long userId);
        string GetUserNameById(long id);
    }
}
