using todo.list.application.Repositories.Contracts;
using todo.list.application.Services.Contracs;
using todo.list.domain.Entities;

namespace todo.list.application.Services.Implementations;

public class UserService(IUnitOfWork unitOfWork) : GenericService<UserEntity>(unitOfWork), IUserService
{
    public async Task<UserEntity?> GetUserByEmailAsync(string email)
    => await UnitOfWork.UserRepository.GetUserByEmailAsync(email);
    public async Task<UserEntity?> GetUserByEmailAndPasswordAsync(string email, string password)
        => await UnitOfWork.UserRepository.GetUserByEmailAndPasswordAsync(email, password);
    public async Task<UserEntity?> GetUserByNickNameAsync(string nickName)
        => await UnitOfWork.UserRepository.GetUserByNickNameAsync(nickName);
    public async Task<UserEntity?> GetUserByNickNameAndPasswordAsync(string nickName, string password)
        => await UnitOfWork.UserRepository.GetUserByNickNameAndPasswordAsync(nickName, password);
    public override async Task<UserEntity> UpdateAsync(UserEntity entity)
    {
        var userFromDb = await Repository.GetByRowGuidAsync(entity.RowGuid!) ?? throw new Exception("User not found");

        userFromDb.Name = entity.Name;
        userFromDb.Nickname = entity.Nickname;
        userFromDb.Password = entity.Password;
        userFromDb.Email = entity.Email;
        userFromDb.LastLogin = entity.LastLogin;
        userFromDb.UpdatedBy += " Surprise";
        userFromDb.UpdatedAt = DateTime.Now;

        var updatedEntity = await Repository.UpdateAsync(userFromDb);
        var rowAffect = await UnitOfWork.SaveChangesAsync();

        if (rowAffect <= 0)
            throw new Exception("Failed to update user in the database.");

        return updatedEntity;
    }
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
