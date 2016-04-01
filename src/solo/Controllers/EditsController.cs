using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using solo.Models;

namespace solo.Controllers
{
    [Produces("application/json")]
    [Route("api/Edits")]
    public class EditsController : Controller
    {
        private ApplicationDbContext _context;

        public EditsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Edits
        [HttpGet]
        public IEnumerable<Edit> GetDbEdits()
        {
            return _context.DbEdits;
        }

        // GET: api/Edits/5
        [HttpGet("{id}", Name = "GetEdit")]
        public IActionResult GetEdit([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Edit edit = _context.DbEdits.Single(m => m.Id == id);

            if (edit == null)
            {
                return HttpNotFound();
            }

            return Ok(edit);
        }

        // PUT: api/Edits/5
        [HttpPut("{id}")]
        public IActionResult PutEdit(int id, [FromBody] Edit edit)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            if (id != edit.Id)
            {
                return HttpBadRequest();
            }

            _context.Entry(edit).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EditExists(id))
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

        // POST: api/Edits
        [HttpPost]
        public IActionResult PostEdit([FromBody] Edit edit)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            _context.DbEdits.Add(edit);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (EditExists(edit.Id))
                {
                    return new HttpStatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetEdit", new { id = edit.Id }, edit);
        }

        // DELETE: api/Edits/5
        [HttpDelete("{id}")]
        public IActionResult DeleteEdit(int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Edit edit = _context.DbEdits.Single(m => m.Id == id);
            if (edit == null)
            {
                return HttpNotFound();
            }

            _context.DbEdits.Remove(edit);
            _context.SaveChanges();

            return Ok(edit);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EditExists(int id)
        {
            return _context.DbEdits.Count(e => e.Id == id) > 0;
        }
    }
}