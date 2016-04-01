using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using solo.Models;

namespace solo.Controllers
{
    [Produces("application/json")]
    [Route("api/Posts")]
    public class PostsController : Controller
    {
        private ApplicationDbContext _context;

        public PostsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Posts
        [HttpGet]
        public IEnumerable<Post> GetDbPosts()
        {
            return _context.DbPosts;
        }

        // GET: api/Posts/5
        [HttpGet("{id}", Name = "GetPost")]
        public IActionResult GetPost([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Post post = _context.DbPosts.Single(m => m.Id == id);

            if (post == null)
            {
                return HttpNotFound();
            }

            return Ok(post);
        }

        // PUT: api/Posts/5
        [HttpPut("{id}")]
        public IActionResult PutPost(int id, [FromBody] Post post)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            if (id != post.Id)
            {
                return HttpBadRequest();
            }

            _context.Entry(post).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(id))
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

        // POST: api/Posts
        [HttpPost]
        public IActionResult PostPost([FromBody] Post post)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            _context.DbPosts.Add(post);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PostExists(post.Id))
                {
                    return new HttpStatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetPost", new { id = post.Id }, post);
        }

        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        public IActionResult DeletePost(int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Post post = _context.DbPosts.Single(m => m.Id == id);
            if (post == null)
            {
                return HttpNotFound();
            }

            _context.DbPosts.Remove(post);
            _context.SaveChanges();

            return Ok(post);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PostExists(int id)
        {
            return _context.DbPosts.Count(e => e.Id == id) > 0;
        }
    }
}