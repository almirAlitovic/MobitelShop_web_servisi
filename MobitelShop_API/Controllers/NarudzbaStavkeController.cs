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
    public class NarudzbaStavkeController : ApiController
    {
        private hci231_MobitelShopEntities db = new hci231_MobitelShopEntities();

        // GET: api/NarudzbaStavke
        public IQueryable<NarudzbaStavke> GetNarudzbaStavke()
        {
            return db.NarudzbaStavke;
        }

        // GET: api/NarudzbaStavke/5
        [ResponseType(typeof(NarudzbaStavke))]
        public IHttpActionResult GetNarudzbaStavke(int id)
        {
            NarudzbaStavke narudzbaStavke = db.NarudzbaStavke.Find(id);
            if (narudzbaStavke == null)
            {
                return NotFound();
            }

            return Ok(narudzbaStavke);
        }

        // PUT: api/NarudzbaStavke/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNarudzbaStavke(int id, NarudzbaStavke narudzbaStavke)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != narudzbaStavke.Id)
            {
                return BadRequest();
            }

            db.Entry(narudzbaStavke).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NarudzbaStavkeExists(id))
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

        // POST: api/NarudzbaStavke
        [ResponseType(typeof(NarudzbaStavke))]
        public IHttpActionResult PostNarudzbaStavke(NarudzbaStavke narudzbaStavke)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NarudzbaStavke.Add(narudzbaStavke);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = narudzbaStavke.Id }, narudzbaStavke);
        }

        // DELETE: api/NarudzbaStavke/5
        [ResponseType(typeof(NarudzbaStavke))]
        public IHttpActionResult DeleteNarudzbaStavke(int id)
        {
            NarudzbaStavke narudzbaStavke = db.NarudzbaStavke.Find(id);
            if (narudzbaStavke == null)
            {
                return NotFound();
            }

            db.NarudzbaStavke.Remove(narudzbaStavke);
            db.SaveChanges();

            return Ok(narudzbaStavke);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NarudzbaStavkeExists(int id)
        {
            return db.NarudzbaStavke.Count(e => e.Id == id) > 0;
        }
    }
}