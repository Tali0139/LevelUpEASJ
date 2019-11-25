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
    public class ClientAppointmentsController : ApiController
    {
        private LevelUpDBContext db = new LevelUpDBContext();

        // GET: api/ClientAppointments
        public IQueryable<ClientAppointment> GetClientAppointments()
        {
            return db.ClientAppointments;
        }

        // GET: api/ClientAppointments/5
        [ResponseType(typeof(ClientAppointment))]
        public async Task<IHttpActionResult> GetClientAppointment(int id)
        {
            ClientAppointment clientAppointment = await db.ClientAppointments.FindAsync(id);
            if (clientAppointment == null)
            {
                return NotFound();
            }

            return Ok(clientAppointment);
        }

        // PUT: api/ClientAppointments/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutClientAppointment(int id, ClientAppointment clientAppointment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != clientAppointment.AppointmentId)
            {
                return BadRequest();
            }

            db.Entry(clientAppointment).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientAppointmentExists(id))
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

        // POST: api/ClientAppointments
        [ResponseType(typeof(ClientAppointment))]
        public async Task<IHttpActionResult> PostClientAppointment(ClientAppointment clientAppointment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ClientAppointments.Add(clientAppointment);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ClientAppointmentExists(clientAppointment.AppointmentId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = clientAppointment.AppointmentId }, clientAppointment);
        }

        // DELETE: api/ClientAppointments/5
        [ResponseType(typeof(ClientAppointment))]
        public async Task<IHttpActionResult> DeleteClientAppointment(int id)
        {
            ClientAppointment clientAppointment = await db.ClientAppointments.FindAsync(id);
            if (clientAppointment == null)
            {
                return NotFound();
            }

            db.ClientAppointments.Remove(clientAppointment);
            await db.SaveChangesAsync();

            return Ok(clientAppointment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClientAppointmentExists(int id)
        {
            return db.ClientAppointments.Count(e => e.AppointmentId == id) > 0;
        }
    }
}