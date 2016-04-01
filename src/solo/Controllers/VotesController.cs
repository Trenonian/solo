using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using solo.Models;

namespace solo.Controllers
{
    [Produces("application/json")]
    [Route("api/Votes")]
    public class VotesController : Controller
    {
        private ApplicationDbContext _context;

        public VotesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Votes
        [HttpGet]
        public IEnumerable<Vote> GetDbVotes()
        {
            return _context.DbVotes;
        }

        // GET: api/Votes/5
        [HttpGet("{id}", Name = "GetVote")]
        public IActionResult GetVote([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Vote vote = _context.DbVotes.Single(m => m.Id == id);

            if (vote == null)
            {
                return HttpNotFound();
            }

            return Ok(vote);
        }

        // PUT: api/Votes/5
        [HttpPut("{id}")]
        public IActionResult PutVote(int id, [FromBody] Vote vote)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            if (id != vote.Id)
            {
                return HttpBadRequest();
            }

            _context.Entry(vote).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VoteExists(id))
                {
                    return HttpNotFound();
                }
                else
                {
                    throw;
                }
            }

            return new HttpStatusCodeResult(StatusCodes.Status204NoContent);
        }

        // POST: api/Votes
        [HttpPost]
        public IActionResult PostVote([FromBody] Vote vote)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            _context.DbVotes.Add(vote);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (VoteExists(vote.Id))
                {
                    return new HttpStatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetVote", new { id = vote.Id }, vote);
        }

        // DELETE: api/Votes/5
        [HttpDelete("{id}")]
        public IActionResult DeleteVote(int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Vote vote = _context.DbVotes.Single(m => m.Id == id);
            if (vote == null)
            {
                return HttpNotFound();
            }

            _context.DbVotes.Remove(vote);
            _context.SaveChanges();

            return Ok(vote);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VoteExists(int id)
        {
            return _context.DbVotes.Count(e => e.Id == id) > 0;
        }
    }
}