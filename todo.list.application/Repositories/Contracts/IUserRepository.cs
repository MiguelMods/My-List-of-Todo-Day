using todo.list.domain.Entities;

namespace todo.list.application.Repositories.Contracts;

public interface IUserRepository : IGenericRepository<UserEntity>
{
    Task<UserEntity?> GetUserByEmailAsync(string email);
    Task<UserEntity?> GetUserByEmailAndPasswordAsync(string email, string password);
    Task<UserEntity?> GetUserByNickNameAsync(string nickName);
    Task<UserEntity?> GetUserByNickNameAndPasswordAsync(string nickName, string password);
}
