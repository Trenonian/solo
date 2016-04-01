using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using solo.Models;

namespace solo.Controllers
{
    [Produces("application/json")]
    [Route("api/Comments")]
    public class CommentsController : Controller
    {
        private ApplicationDbContext _context;

        public CommentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Comments
        [HttpGet]
        public IEnumerable<Comment> GetDbComments()
        {
            return _context.DbComments;
        }

        // GET: api/Comments/5
        [HttpGet("{id}", Name = "GetComment")]
        public IActionResult GetComment([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Comment comment = _context.DbComments.Single(m => m.Id == id);

            if (comment == null)
            {
                return HttpNotFound();
            }

            return Ok(comment);
        }

        // PUT: api/Comments/5
        [HttpPut("{id}")]
        public IActionResult PutComment(int id, [FromBody] Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            if (id != comment.Id)
            {
                return HttpBadRequest();
            }

            _context.Entry(comment).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentExists(id))
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

        // POST: api/Comments
        [HttpPost]
        public IActionResult PostComment([FromBody] Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            _context.DbComments.Add(comment);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CommentExists(comment.Id))
                {
                    return new HttpStatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetComment", new { id = comment.Id }, comment);
        }

        // DELETE: api/Comments/5
        [HttpDelete("{id}")]
        public IActionResult DeleteComment(int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Comment comment = _context.DbComments.Single(m => m.Id == id);
            if (comment == null)
            {
                return HttpNotFound();
            }

            _context.DbComments.Remove(comment);
            _context.SaveChanges();

            return Ok(comment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CommentExists(int id)
        {
            return _context.DbComments.Count(e => e.Id == id) > 0;
        }
    }
}