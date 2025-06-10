namespace todo.list.common.Models.Response;

public record LoginResponse(long UserId, string Name, string Nickname, string Email, string Rowguid);
