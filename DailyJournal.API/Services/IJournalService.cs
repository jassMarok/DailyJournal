using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DailyJournal.API.Entities;

namespace DailyJournal.API.Services
{
    public interface IJournalService
    {
        Task<IEnumerable<Journal>> Get();
        Task<Journal> GetJournalEntryById(Guid journalId);
        Task<Journal> Create(Journal journal);
        Task<Journal> Update(Guid journalId);
        Task<bool> Delete(Guid journalId);
    }
}