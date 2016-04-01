using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using solo.Models;

namespace solo.Controllers
{
    [Produces("application/json")]
    [Route("api/Boards")]
    public class BoardsController : Controller
    {
        private ApplicationDbContext _context;

        public BoardsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Boards
        [HttpGet]
        public IEnumerable<Board> GetDbBoards()
        {
            return _context.DbBoards;
        }

        // GET: api/Boards/5
        [HttpGet("{id}", Name = "GetBoard")]
        public IActionResult GetBoard([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Board board = _context.DbBoards.Single(m => m.Id == id);

            if (board == null)
            {
                return HttpNotFound();
            }

            return Ok(board);
        }

        // PUT: api/Boards/5
        [HttpPut("{id}")]
        public IActionResult PutBoard(int id, [FromBody] Board board)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            if (id != board.Id)
            {
                return HttpBadRequest();
            }

            _context.Entry(board).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoardExists(id))
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

        // POST: api/Boards
        [HttpPost]
        public IActionResult PostBoard([FromBody] Board board)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            _context.DbBoards.Add(board);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (BoardExists(board.Id))
                {
                    return new HttpStatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetBoard", new { id = board.Id }, board);
        }

        // DELETE: api/Boards/5
        [HttpDelete("{id}")]
        public IActionResult DeleteBoard(int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Board board = _context.DbBoards.Single(m => m.Id == id);
            if (board == null)
            {
                return HttpNotFound();
            }

            _context.DbBoards.Remove(board);
            _context.SaveChanges();

            return Ok(board);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BoardExists(int id)
        {
            return _context.DbBoards.Count(e => e.Id == id) > 0;
        }
    }
}