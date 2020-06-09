using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailyJournal.API.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<RefreshToken> RefreshTokens { get; set; }
    }
}
