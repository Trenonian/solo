using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using solo.Models;

namespace solo.Controllers
{
    [Produces("application/json")]
    [Route("api/Tags")]
    public class TagsController : Controller
    {
        private ApplicationDbContext _context;

        public TagsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Tags
        [HttpGet]
        public IEnumerable<Tag> GetDbTags()
        {
            return _context.DbTags;
        }

        // GET: api/Tags/5
        [HttpGet("{id}", Name = "GetTag")]
        public IActionResult GetTag([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Tag tag = _context.DbTags.Single(m => m.Id == id);

            if (tag == null)
            {
                return HttpNotFound();
            }

            return Ok(tag);
        }

        // PUT: api/Tags/5
        [HttpPut("{id}")]
        public IActionResult PutTag(int id, [FromBody] Tag tag)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            if (id != tag.Id)
            {
                return HttpBadRequest();
            }

            _context.Entry(tag).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TagExists(id))
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

        // POST: api/Tags
        [HttpPost]
        public IActionResult PostTag([FromBody] Tag tag)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            _context.DbTags.Add(tag);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TagExists(tag.Id))
                {
                    return new HttpStatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetTag", new { id = tag.Id }, tag);
        }

        // DELETE: api/Tags/5
        [HttpDelete("{id}")]
        public IActionResult DeleteTag(int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Tag tag = _context.DbTags.Single(m => m.Id == id);
            if (tag == null)
            {
                return HttpNotFound();
            }

            _context.DbTags.Remove(tag);
            _context.SaveChanges();

            return Ok(tag);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TagExists(int id)
        {
            return _context.DbTags.Count(e => e.Id == id) > 0;
        }
    }
}