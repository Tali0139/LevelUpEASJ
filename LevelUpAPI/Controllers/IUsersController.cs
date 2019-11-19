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
using LevelUpAPI;

namespace LevelUpAPI.Controllers
{
    public class IUsersController : ApiController
    {
        private LevelUpDBContext db = new LevelUpDBContext();

        // GET: api/IUsers
        public IQueryable<IUser> GetIUser()
        {
            return db.IUser;
        }

        // GET: api/IUsers/5
        [ResponseType(typeof(IUser))]
        public IHttpActionResult GetIUser(int id)
        {
            IUser iUser = db.IUser.Find(id);
            if (iUser == null)
            {
                return NotFound();
            }

            return Ok(iUser);
        }

        // PUT: api/IUsers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutIUser(int id, IUser iUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != iUser.Id)
            {
                return BadRequest();
            }

            db.Entry(iUser).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IUserExists(id))
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

        // POST: api/IUsers
        [ResponseType(typeof(IUser))]
        public IHttpActionResult PostIUser(IUser iUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.IUser.Add(iUser);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (IUserExists(iUser.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = iUser.Id }, iUser);
        }

        // DELETE: api/IUsers/5
        [ResponseType(typeof(IUser))]
        public IHttpActionResult DeleteIUser(int id)
        {
            IUser iUser = db.IUser.Find(id);
            if (iUser == null)
            {
                return NotFound();
            }

            db.IUser.Remove(iUser);
            db.SaveChanges();

            return Ok(iUser);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IUserExists(int id)
        {
            return db.IUser.Count(e => e.Id == id) > 0;
        }
    }
}