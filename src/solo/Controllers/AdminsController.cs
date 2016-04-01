using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using solo.Models;

namespace solo.Controllers
{
    [Produces("application/json")]
    [Route("api/Admins")]
    public class AdminsController : Controller
    {
        private ApplicationDbContext _context;

        public AdminsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Admins
        [HttpGet]
        public IEnumerable<Admin> GetDbAdmins()
        {
            return _context.DbAdmins;
        }

        // GET: api/Admins/5
        [HttpGet("{id}", Name = "GetAdmin")]
        public IActionResult GetAdmin([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Admin admin = _context.DbAdmins.Single(m => m.Id == id);

            if (admin == null)
            {
                return HttpNotFound();
            }

            return Ok(admin);
        }

        // PUT: api/Admins/5
        [HttpPut("{id}")]
        public IActionResult PutAdmin(int id, [FromBody] Admin admin)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            if (id != admin.Id)
            {
                return HttpBadRequest();
            }

            _context.Entry(admin).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminExists(id))
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

        // POST: api/Admins
        [HttpPost]
        public IActionResult PostAdmin([FromBody] Admin admin)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            _context.DbAdmins.Add(admin);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AdminExists(admin.Id))
                {
                    return new HttpStatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetAdmin", new { id = admin.Id }, admin);
        }

        // DELETE: api/Admins/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAdmin(int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Admin admin = _context.DbAdmins.Single(m => m.Id == id);
            if (admin == null)
            {
                return HttpNotFound();
            }

            _context.DbAdmins.Remove(admin);
            _context.SaveChanges();

            return Ok(admin);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdminExists(int id)
        {
            return _context.DbAdmins.Count(e => e.Id == id) > 0;
        }
    }
}