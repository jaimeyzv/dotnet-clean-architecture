namespace GWL.Application.UseCases.CreateUser
{
    public sealed record CreateUserResponse
    {
        public int UserId;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender{ get; set; }
        public int Age { get; set; }
    }
}
