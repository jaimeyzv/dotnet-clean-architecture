using AutoMapper;
using GWL.Domain.Entities;
using GWL.Domain.Interfaces;
using MediatR;

namespace GWL.Application.UseCases.CreateUser
{
    public class CreateUserHandler(IUnitOfWork unitOfWork, 
        IUserRepository userRepository, 
        IMapper mapper) : IRequestHandler<CreateUserRequest, CreateUserResponse>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IUserRepository _repository = userRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);

            await _repository.Create(user, cancellationToken);
            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<CreateUserResponse>(user);
        }
    }
}
