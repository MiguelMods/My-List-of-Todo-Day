using Microsoft.EntityFrameworkCore;
using todo.list.application.Repositories.Contracts;
using todo.list.domain.Entities;
using todo.list.persistance.DataBaseContext;

namespace todo.list.persistance.Repositories.Implentations;

public class UserRepository(TodoListDBContext todoListDBContext) : GenericRepository<UserEntity>(todoListDBContext), IUserRepository
{
    public async Task<UserEntity?> GetUserByEmailAsync(string email)
        => await Context.Users.Where(x => x.Email == email).FirstOrDefaultAsync();
    public async Task<UserEntity?> GetUserByEmailAndPasswordAsync(string email, string password)
        => await Context.Users.Where(x => x.Email == email && x.Password == password).FirstOrDefaultAsync();
    public async Task<UserEntity?> GetUserByNickNameAsync(string nickName)
        => await Context.Users.Where(x => x.Nickname == nickName).FirstOrDefaultAsync();
    public async Task<UserEntity?> GetUserByNickNameAndPasswordAsync(string nickName, string password)
        => await Context.Users.Where(x => x.Nickname == nickName && x.Password == password).FirstOrDefaultAsync();
}
