using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DailyJournal.API.Entities;
using DailyJournal.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace DailyJournal.API.Controllers
{
    public class JournalController : Controller
    {
        private readonly IJournalService _journalService;

        public JournalController(IJournalService journalService)
        {
            _journalService = journalService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Journal>> Index()
        {
            return Ok(_journalService.Get());
        }

        [HttpPost]
        public async Task<ActionResult<Journal>> Add(Journal model)
        {
            var journal = await _journalService.Create(model);
            return Ok(journal);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid journalGuid)
        { 
            await _journalService.Delete(journalGuid);
            return Ok();
        }

    }
}
