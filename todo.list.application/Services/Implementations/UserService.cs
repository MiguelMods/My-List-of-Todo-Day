using todo.list.application.Repositories.Contracts;
using todo.list.application.Services.Contracs;
using todo.list.common.Extensions;
using todo.list.common.Models.Requests;
using todo.list.common.Models.Response;
using todo.list.common.Results;
using todo.list.domain.Entities;

namespace todo.list.application.Services.Implementations;

public class UserService(IUnitOfWork unitOfWork) : GenericService<UserEntity>(unitOfWork), IUserService
{
    public async Task<Result<AccountRegisterResponse>> RegisterAsync(AccountRegisterRequest user)
    {
        var emailIsTaken = await UnitOfWork.UserRepository.GetUserByEmailAsync(user.Email);

        if (emailIsTaken != null)
            return Result<AccountRegisterResponse>.Failure("Email is Taken");

        var nickNameIsTaken = await UnitOfWork.UserRepository.GetUserByNickNameAsync(user.NickName);

        if (nickNameIsTaken != null)
            return Result<AccountRegisterResponse>.Failure("Nickame is Taken");

        if (user.Password != user.PasswordConfirm)
            return Result<AccountRegisterResponse>.Failure("Password dont not match");

        var newUser = await UnitOfWork.UserRepository.AddAsync(new UserEntity
        {
            Name = user.Name,
            Nickname = user.NickName,
            Email = user.Email,
            Password = user.Password,
            CreatedBy = "System",
            CreatedAt = DateTime.Now
        });

        var rowAffect = await UnitOfWork.SaveChangesAsync();

        if (rowAffect <= 0)
            throw new Exception("Failed to register user in the database.");

        var response = new AccountRegisterResponse(newUser.Id, newUser.Name, newUser.Nickname, newUser.Email, newUser.RowGuid, newUser.CreatedAt);

        return response.IsASuccess();
    }
    
    public async Task<Result<AccountRegisterResponse>> GetUserByEmailAsync(string email)
    {
        if (string.IsNullOrEmpty(email))
            return Result<AccountRegisterResponse>.Failure("Email cannot be null or empty");

        var userResult = await UnitOfWork.UserRepository.GetUserByEmailAsync(email);

        if (userResult is null)
            return Result<AccountRegisterResponse>.Failure("User not found");

        var response = new AccountRegisterResponse(userResult.Id, userResult.Name, userResult.Nickname, userResult.Email, userResult.RowGuid, userResult.CreatedAt);

        return response.IsASuccess();
    }
    
    public async Task<Result<AccountRegisterResponse>> GetUserByEmailAndPasswordAsync(string email, string password) 
    {
       if(string.IsNullOrEmpty(email))
            throw new ArgumentNullException(nameof(email), "Email cannot be null or empty");

        if (string.IsNullOrEmpty(password))
            throw new ArgumentNullException(nameof(password), "Password cannot be null or empty");
       
        var userResult = await UnitOfWork.UserRepository.GetUserByEmailAndPasswordAsync(email, password);

        if (userResult is null)
            return Result<AccountRegisterResponse>.Failure("User not found or password is incorrect");

        var response = new AccountRegisterResponse(userResult.Id, userResult.Name, userResult.Nickname, userResult.Email, userResult.RowGuid, userResult.CreatedAt);

        return response.IsASuccess();
    }

    public async Task<Result<AccountRegisterResponse>> GetUserByNickNameAsync(string nickName) 
    {
        if (string.IsNullOrEmpty(nickName))
            return Result<AccountRegisterResponse>.Failure("nickName cannot be null or empty");

        var userResult = await UnitOfWork.UserRepository.GetUserByEmailAsync(nickName);

        if (userResult is null)
            return Result<AccountRegisterResponse>.Failure("User not found");

        var response = new AccountRegisterResponse(userResult.Id, userResult.Name, userResult.Nickname, userResult.Email, userResult.RowGuid, userResult.CreatedAt);

        return response.IsASuccess();
    }

    public async Task<Result<AccountRegisterResponse>> GetUserByNickNameAndPasswordAsync(string nickName, string password) 
    {
        if (string.IsNullOrEmpty(nickName))
            return Result<AccountRegisterResponse>.Failure("");

        if (string.IsNullOrEmpty(password))
            return Result<AccountRegisterResponse>.Failure("");

        var userResult = await UnitOfWork.UserRepository.GetUserByNickNameAndPasswordAsync(nickName, password);

        if (userResult is null)
            return Result<AccountRegisterResponse>.Failure("User not found or password is incorrect");
        
        var response = new AccountRegisterResponse(userResult.Id, userResult.Name, userResult.Nickname, userResult.Email, userResult.RowGuid, userResult.CreatedAt);

        return response.IsASuccess();
    }

    public async Task<Result<LoginResponse>> LoginAsync(string nickname, string password)
    {
        if (string.IsNullOrEmpty(nickname) || string.IsNullOrEmpty(password))
            return Result<LoginResponse>.Failure("Nickname or password cannot be null or empty");

        var userResult = await UnitOfWork.UserRepository.GetUserByNickNameAsync(nickname);

        if (userResult is null)
            return Result<LoginResponse>.Failure("User not found");

        if (userResult.Password != password)
            return Result<LoginResponse>.Failure("USername or password is incorrect");

        var response = new LoginResponse(userResult.Id, userResult.Name!, userResult.Nickname!, userResult.Email!, userResult.RowGuid!);

        return response.IsASuccess();
    }
   
    public async Task<Result<LoginResponse>> LoginEmailAsync(string email, string password)
    {
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            return Result<LoginResponse>.Failure("Nickname or password cannot be null or empty");

        var userResult = await UnitOfWork.UserRepository.GetUserByEmailAsync(email);

        if (userResult is null)
            return Result<LoginResponse>.Failure("User not found");

        if (userResult.Password != password)
            return Result<LoginResponse>.Failure("USername or password is incorrect");

        var response = new LoginResponse(userResult.Id, userResult.Name!, userResult.Nickname!, userResult.Email!, userResult.RowGuid!);

        return response.IsASuccess();
    }
    
    public async Task<Result<bool>> UpdateUserPasswordByRowGuidAsync(string rowguid, string newPassword)
    {
        if (rowguid == null || newPassword == null)
            return Result<bool>.Failure("User/password cannot be null");

        var user = await UnitOfWork.UserRepository.GetByRowGuidAsync(rowguid);
        
        if (user == null)
            return Result<bool>.Failure("User Not Found");

        user.Password = newPassword;
        user.UpdatedBy += " Surprise";
        user.UpdatedAt = DateTime.Now;

        var updatedUser = await UnitOfWork.UserRepository.UpdateAsync(user);
        var rowAffect = await UnitOfWork.SaveChangesAsync();

        if (rowAffect <= 0)
            return Result<bool>.Failure("Failed to update user password in the database.");

        return Result<bool>.Success(true);
    }

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
}
