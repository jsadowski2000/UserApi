using System;
using Microsoft.EntityFrameworkCore;

[Index(nameof(Email), IsUnique = true)]
public class User
{
    public Guid Id { get; set; }

    public string UserName { get; set; }

    public string Password { get; set; }

    public string Email { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public DateTime ConfirmationTokenDate { get; set; } = DateTime.UtcNow;

    public string? ConfirmationToken { get; set; }

    public string? RefreshToken { get; set; }

    public UserStatus Status { get; set; } = UserStatus.PENDING;

    public UserRole Role { get; set; } = UserRole.USER;

    public string? AvatarUrl { get; set; }

    
    public void UpdateTimestamp()
    {
        UpdatedAt = DateTime.UtcNow;
    }
}

public enum UserRole
{
    ADMIN,
    USER
}

public enum UserStatus
{
    PENDING,
    ACTIVE,
    DISABLED
}

