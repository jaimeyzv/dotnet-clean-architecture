using MediatR;

namespace GWL.Application.UseCases.CreateUser
{
    public sealed record CreateUserRequest(
        int UserId, 
        string FirstName, 
        string LastName, 
        int Age, 
        string Gender
    ) : IRequest<CreateUserResponse>;
}
