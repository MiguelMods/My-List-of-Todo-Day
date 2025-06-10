namespace todo.list.common.Models.Requests
{
    public record AccountRegisterRequest(string Name, string NickName, string Email, string Password, string PasswordConfirm);
}
