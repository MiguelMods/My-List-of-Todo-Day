using todo.list.common.Models.Requests;
using todo.list.application.Services.Contracts;
using todo.list.domain.Entities;
using todo.list.common.Models.Response;
using todo.list.common.Results;

namespace todo.list.application.Services.Contracs;

public interface IUserService : IGenericService<UserEntity>
{
    Task<Result<AccountRegisterResponse>> RegisterAsync(AccountRegisterRequest user);
    Task<Result<AccountRegisterResponse>> GetUserByEmailAsync(string email);
    Task<Result<AccountRegisterResponse>> GetUserByEmailAndPasswordAsync(string email, string password);
    Task<Result<AccountRegisterResponse>> GetUserByNickNameAsync(string nickName);
    Task<Result<AccountRegisterResponse>> GetUserByNickNameAndPasswordAsync(string nickName, string password);
    Task<Result<LoginResponse>> LoginAsync(string nickname, string password);
    Task<Result<LoginResponse>> LoginEmailAsync(string email, string password);
    Task<Result<bool>> UpdateUserPasswordByRowGuidAsync(string rowguid, string newPassword);
}
