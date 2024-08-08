﻿namespace AppGestion.Infrastructure.Identity.Identity.Dtos;

public class IdentitySettings
{
    public string? SecretKey { get; set; }
    public string? EncryptKey { get; set; }
    public string? Issuer { get; set; }
    public string? Audience { get; set; }
    public int NotBeforeMinutes { get; set; }
    public int ExpirationMinutes { get; set; }
}