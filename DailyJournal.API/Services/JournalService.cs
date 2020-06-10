using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DailyJournal.API.Entities;
using DailyJournal.API.Helpers;
using Microsoft.EntityFrameworkCore;

namespace DailyJournal.API.Services
{
    public class JournalService : IJournalService
    {
        private readonly DataContext _context;

        public JournalService(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieve all journal entries by a user
        /// </summary>
        /// <param name="userId">User Guid</param>
        /// <returns></returns>
        public async Task<IEnumerable<Journal>> Get()
        {
            return await _context.Journals.ToListAsync();
        }

        /// <summary>
        /// Retrieve journal entry by id
        /// </summary>
        /// <param name="journalId">Journal Guid</param>
        /// <returns></returns>
        public async Task<Journal> GetJournalEntryById(Guid journalId)
        {
            var journal = await _context.Journals
                .FirstOrDefaultAsync(j => j.Id == journalId);

            return journal;
        }

        /// <summary>
        /// Create a new journal entry
        /// </summary>
        /// <param name="journal"></param>
        /// <returns></returns>
        public async Task<Journal> Create(Journal journal)
        {
            await _context.Journals.AddAsync(journal);
            await _context.SaveChangesAsync();

            return journal;
        }

        /// <summary>
        /// Update an existing journal content
        /// </summary>
        /// <param name="journalId"></param>
        /// <returns></returns>
        public async Task<Journal> Update(Guid journalId)
        {
            var journal = await GetJournalEntryById(journalId);

            if (journal == null)
                return null;

            journal.Content = journal.Content;
            journal.UpdatedAt = DateTime.Now;

            await _context.Journals.AddAsync(journal);
            await _context.SaveChangesAsync();

            return journal;
        }

        /// <summary>
        /// Delete a existing journal entry
        /// </summary>
        /// <param name="journalId"></param>
        /// <returns></returns>
        public async Task<bool> Delete(Guid journalId)
        {
            var journal = await GetJournalEntryById(journalId);

            if (journal == null)
                return false;

            _context.Journals.Remove(journal);
            await _context.SaveChangesAsync();

            return true;
        }


    }
}
