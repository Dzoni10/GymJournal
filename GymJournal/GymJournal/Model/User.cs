namespace GymJournal.Model
{
    public class User : Entity
    {
        public string Username {  get; set; }
        public string Password { get; set; }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        private void Validate()
        {
            if (string.IsNullOrWhiteSpace(Username)) throw new ArgumentException("Invalid Name");
            if (string.IsNullOrWhiteSpace(Password)) throw new ArgumentException("Invalid Surname");
        }


    }
}
