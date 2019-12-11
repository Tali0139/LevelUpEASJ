using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using LevelUpWebAPI;

namespace LevelUpWebAPI.Controllers
{
    public class LevelsController : ApiController
    {
        private LevelUpDBContext db = new LevelUpDBContext();

        // GET: api/Levels
        public IQueryable<Levels> GetLevels()
        {
            return db.Levels;
        }

        // GET: api/Levels/5
        [ResponseType(typeof(Levels))]
        public IHttpActionResult GetLevels(int id)
        {
            Levels levels = db.Levels.Find(id);
            if (levels == null)
            {
                return NotFound();
            }

            return Ok(levels);
        }

        // PUT: api/Levels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLevels(int id, Levels levels)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != levels.LevelValue)
            {
                return BadRequest();
            }

            db.Entry(levels).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LevelsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Levels
        [ResponseType(typeof(Levels))]
        public IHttpActionResult PostLevels(Levels levels)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Levels.Add(levels);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (LevelsExists(levels.LevelValue))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = levels.LevelValue }, levels);
        }

        // DELETE: api/Levels/5
        [ResponseType(typeof(Levels))]
        public IHttpActionResult DeleteLevels(int id)
        {
            Levels levels = db.Levels.Find(id);
            if (levels == null)
            {
                return NotFound();
            }

            db.Levels.Remove(levels);
            db.SaveChanges();

            return Ok(levels);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LevelsExists(int id)
        {
            return db.Levels.Count(e => e.LevelValue == id) > 0;
        }
    }
}