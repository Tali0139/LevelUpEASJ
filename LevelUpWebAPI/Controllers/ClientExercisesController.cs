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
    public class ClientExercisesController : ApiController
    {
        private LevelUpDBContext db = new LevelUpDBContext();

        // GET: api/ClientExercises
        public IQueryable<ClientExercise> GetClientExercises()
        {
            return db.ClientExercises;
        }

        // GET: api/ClientExercises/5
        [ResponseType(typeof(ClientExercise))]
        public IHttpActionResult GetClientExercise(int id)
        {
            ClientExercise clientExercise = db.ClientExercises.Find(id);
            if (clientExercise == null)
            {
                return NotFound();
            }

            return Ok(clientExercise);
        }

        // PUT: api/ClientExercises/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClientExercise(int id, ClientExercise clientExercise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != clientExercise.ClientExerciseId)
            {
                return BadRequest();
            }

            db.Entry(clientExercise).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExerciseExists(id))
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

        // POST: api/ClientExercises
        [ResponseType(typeof(ClientExercise))]
        public IHttpActionResult PostClientExercise(ClientExercise clientExercise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ClientExercises.Add(clientExercise);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = clientExercise.ClientExerciseId }, clientExercise);
        }

        // DELETE: api/ClientExercises/5
        [ResponseType(typeof(ClientExercise))]
        public IHttpActionResult DeleteClientExercise(int id)
        {
            ClientExercise clientExercise = db.ClientExercises.Find(id);
            if (clientExercise == null)
            {
                return NotFound();
            }

            db.ClientExercises.Remove(clientExercise);
            db.SaveChanges();

            return Ok(clientExercise);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClientExerciseExists(int id)
        {
            return db.ClientExercises.Count(e => e.ClientExerciseId == id) > 0;
        }
    }
}