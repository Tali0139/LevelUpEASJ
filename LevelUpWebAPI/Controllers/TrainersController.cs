using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using LevelUpWebAPI;

namespace LevelUpWebAPI.Controllers
{
    public class TrainersController : ApiController
    {
        private LevelUpDBContext db = new LevelUpDBContext();

        // GET: api/Trainers
        public IQueryable<Trainer> GetTrainers()
        {
            return db.Trainers;
        }

        // GET: api/Trainers/5
        [ResponseType(typeof(Trainer))]
        public async Task<IHttpActionResult> GetTrainer(int id)
        {
            Trainer trainer = await db.Trainers.FindAsync(id);
            if (trainer == null)
            {
                return NotFound();
            }

            return Ok(trainer);
        }

        // PUT: api/Trainers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTrainer(int id, Trainer trainer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != trainer.Id)
            {
                return BadRequest();
            }

            db.Entry(trainer).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainerExists(id))
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

        // POST: api/Trainers
        [ResponseType(typeof(Trainer))]
        public async Task<IHttpActionResult> PostTrainer(Trainer trainer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Trainers.Add(trainer);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = trainer.Id }, trainer);
        }

        // DELETE: api/Trainers/5
        [ResponseType(typeof(Trainer))]
        public async Task<IHttpActionResult> DeleteTrainer(int id)
        {
            Trainer trainer = await db.Trainers.FindAsync(id);
            if (trainer == null)
            {
                return NotFound();
            }

            db.Trainers.Remove(trainer);
            await db.SaveChangesAsync();

            return Ok(trainer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TrainerExists(int id)
        {
            return db.Trainers.Count(e => e.Id == id) > 0;
        }
    }
}