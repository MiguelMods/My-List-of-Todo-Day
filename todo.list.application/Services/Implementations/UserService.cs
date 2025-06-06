using todo.list.application.Repositories.Contracts;
using todo.list.application.Services.Contracs;
using todo.list.domain.Entities;

namespace todo.list.application.Services.Implementations;

public class UserService(IUnitOfWork unitOfWork) : GenericService<UserEntity>(unitOfWork), IUserService
{
    public Task<UserEntity> RegisterAsync(UserEntity user)
    {
        throw new NotImplementedException();
    }
    public Task<UserEntity?> LoginAsync(string nickname, string password)
    {
        throw new NotImplementedException();
    }

    public Task<UserEntity?> LoginEmailAsync(string email, string password)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateUserPasswordByRowGuidAsync(string rowguid, string newPassword)
    {
        throw new NotImplementedException();
    }
}
