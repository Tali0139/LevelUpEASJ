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
    public class ExercisesController : ApiController
    {
        private LevelUpDBContext db = new LevelUpDBContext();

        // GET: api/Exercises
        public IQueryable<Exercises> GetExercises()
        {
            return db.Exercises;
        }

        // GET: api/Exercises/5
        [ResponseType(typeof(Exercises))]
        public IHttpActionResult GetExercises(int id)
        {
            Exercises exercises = db.Exercises.Find(id);
            if (exercises == null)
            {
                return NotFound();
            }

            return Ok(exercises);
        }

        // PUT: api/Exercises/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutExercises(int id, Exercises exercises)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != exercises.ExerciseId)
            {
                return BadRequest();
            }

            db.Entry(exercises).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExercisesExists(id))
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

        // POST: api/Exercises
        [ResponseType(typeof(Exercises))]
        public IHttpActionResult PostExercises(Exercises exercises)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Exercises.Add(exercises);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = exercises.ExerciseId }, exercises);
        }

        // DELETE: api/Exercises/5
        [ResponseType(typeof(Exercises))]
        public IHttpActionResult DeleteExercises(int id)
        {
            Exercises exercises = db.Exercises.Find(id);
            if (exercises == null)
            {
                return NotFound();
            }

            db.Exercises.Remove(exercises);
            db.SaveChanges();

            return Ok(exercises);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ExercisesExists(int id)
        {
            return db.Exercises.Count(e => e.ExerciseId == id) > 0;
        }
    }
}