namespace AppGestion.Domain.Entities;

public class UserRefreshToken : BaseEntity<Guid>
{
    public UserRefreshToken()
    {
        CreatedAt=DateTime.Now;
    }

    public int UserId { get; set; }
    public User User { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsValid { get; set; }
}