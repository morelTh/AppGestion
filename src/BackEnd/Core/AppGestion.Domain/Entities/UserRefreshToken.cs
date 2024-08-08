namespace AppGestion.Domain.Entities;

public class UserRefreshToken :  BaseEntity
{
    public UserRefreshToken() => CreatedAt=DateTime.Now;

    public int UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsValid { get; set; }
    
    public virtual User? User { get; set; }
}