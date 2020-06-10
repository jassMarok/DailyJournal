using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailyJournal.API.Entities
{
    public class Journal
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
