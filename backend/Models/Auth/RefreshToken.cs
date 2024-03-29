﻿using backend.Entities;
using System.ComponentModel.DataAnnotations;

namespace backend.Models.Auth
{
    public class RefreshToken
    {
        [Key]
        public int RefreshTokenId { get; set; }
        public string RefreshTokenValue { get; set; }
        public bool Active { get; set; }
        public DateTime Expiration { get; set; }
        public bool Used { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
    }
}
