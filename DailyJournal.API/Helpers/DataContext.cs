using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DailyJournal.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace DailyJournal.API.Helpers
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options) {}

        public DbSet<Journal> Journals { get; set; }
    }
}
