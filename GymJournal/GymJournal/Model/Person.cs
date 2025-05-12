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
            Validate();
        }

        public Person(string name, string surname, string email, string phone)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Phone = phone;
            Validate(skipUserId: true);
        }

        private void Validate(bool skipUserId=false)
        {
            if (!skipUserId && UserId == 0) throw new ArgumentException("Invalid UserId");
            if (string.IsNullOrWhiteSpace(Name)) throw new ArgumentException("Invalid Name");
            if (string.IsNullOrWhiteSpace(Surname)) throw new ArgumentException("Invalid Surname");
            if (!MailAddress.TryCreate(Email, out _)) throw new ArgumentException("Invalid Email");

            var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(Email, emailPattern))
                throw new ArgumentException("Invalid Email: must include domain like .com");
        }

    }
}