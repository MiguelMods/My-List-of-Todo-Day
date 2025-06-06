using todo.list.application.Services.Contracts;
using todo.list.domain.Entities;

namespace todo.list.application.Services.Contracs;

public interface IUserService : IGenericService<UserEntity>
{
    Task<UserEntity> RegisterAsync(UserEntity user);
    Task<UserEntity?> LoginAsync(string nickname, string password);
    Task<UserEntity?> LoginEmailAsync(string email, string password);
    Task<bool> UpdateUserPasswordByRowGuidAsync(string rowguid, string newPassword);
}
