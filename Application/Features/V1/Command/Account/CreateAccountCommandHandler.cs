using AutoMapper;
using Application.Data;
using Contract.Abstraction.Message;
using Contract.Abstraction.Shared;
using Domain.Abstraction.Repositories;
using static Contract.Abstraction.Shared.ResultExtension;
using static Contract.Service.Account.Command;

namespace Application.Features.V1.Command.User
{
    public class CreateAccountCommandHandler : ICommandHandler<CreateAccount>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAccountRepository _accountRepository;

        public CreateAccountCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IAccountRepository accountRepository) =>
            (_unitOfWork, _mapper, _accountRepository) = (unitOfWork, mapper, accountRepository);

        public async Task<Result> Handle(CreateAccount request, CancellationToken cancellationToken)
        {
            return await Combine(
                Result.Create(
                await _accountRepository.FindSingleAsync(x => x.Username == request.CreateAccountDTO.Username)))
                .Map(user => _mapper.Map<Domain.Entities.Account>(user))
                .Tap(_accountRepository.Add)
                .Tap(() => _unitOfWork.SaveChangesAsync());
        }
    }
}
