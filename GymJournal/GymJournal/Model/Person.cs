using GymJournal.Model;
using System.Net.Mail;
using System.Xml.Linq;

namespace GymJournal.Model
{
    public class Person : Entity
    {
        public long UserId { get; init; }
        public string Name { get; init; }
        public string Surname { get; init; }
        public string Email { get; init; }
        public string Phone { get; init; }


        public Person(long userId, string name, string surname, string email, string phone)
        {
            UserId = userId;
            Name = name;
            Surname = surname;
            Email = email;
            Phone = phone;
        }

    }
}