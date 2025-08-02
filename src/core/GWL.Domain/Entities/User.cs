namespace GWL.Domain.Entities
{
    public class User
    {        
        public int UserId { get; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Age { get; private set; }
        public string Gender { get; private set; }

        public User(int userId, string firstName, string lastName, int age, string gender)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Gender = gender;
        }
    }
}
