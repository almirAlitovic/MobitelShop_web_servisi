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
using MobitelShop_API.Models;

namespace MobitelShop_API.Controllers
{
    public class BrendoviController : ApiController
    {
        private hci231_MobitelShopEntities db = new hci231_MobitelShopEntities();

        // GET: api/Brendovi
        public IQueryable<Brendovi> GetBrendovi()
        {
            return db.Brendovi;
        }

        // GET: api/Brendovi/5
        [ResponseType(typeof(Brendovi))]
        public IHttpActionResult GetBrendovi(int id)
        {
            Brendovi brendovi = db.Brendovi.Find(id);
            if (brendovi == null)
            {
                return NotFound();
            }

            return Ok(brendovi);
        }

        // PUT: api/Brendovi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBrendovi(int id, Brendovi brendovi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != brendovi.Id)
            {
                return BadRequest();
            }

            db.Entry(brendovi).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrendoviExists(id))
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

        // POST: api/Brendovi
        [ResponseType(typeof(Brendovi))]
        public IHttpActionResult PostBrendovi(Brendovi brendovi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Brendovi.Add(brendovi);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = brendovi.Id }, brendovi);
        }

        // DELETE: api/Brendovi/5
        [ResponseType(typeof(Brendovi))]
        public IHttpActionResult DeleteBrendovi(int id)
        {
            Brendovi brendovi = db.Brendovi.Find(id);
            if (brendovi == null)
            {
                return NotFound();
            }

            db.Brendovi.Remove(brendovi);
            db.SaveChanges();

            return Ok(brendovi);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BrendoviExists(int id)
        {
            return db.Brendovi.Count(e => e.Id == id) > 0;
        }
    }
}