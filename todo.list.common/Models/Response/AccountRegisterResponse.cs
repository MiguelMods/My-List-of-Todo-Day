namespace todo.list.common.Models.Response;

public record AccountRegisterResponse(long UserId, string? Name, string? NickName, string? Email, string? Rowguid, DateTime? CreatedAt);
