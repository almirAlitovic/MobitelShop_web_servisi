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
    public class MemorijaController : ApiController
    {
        private hci231_MobitelShopEntities db = new hci231_MobitelShopEntities();

        // GET: api/Memorija
        public IQueryable<Memorija> GetMemorija()
        {
            return db.Memorija;
        }

        // GET: api/Memorija/5
        [ResponseType(typeof(Memorija))]
        public IHttpActionResult GetMemorija(int id)
        {
            Memorija memorija = db.Memorija.Find(id);
            if (memorija == null)
            {
                return NotFound();
            }

            return Ok(memorija);
        }

        // PUT: api/Memorija/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMemorija(int id, Memorija memorija)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != memorija.Id)
            {
                return BadRequest();
            }

            db.Entry(memorija).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemorijaExists(id))
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

        // POST: api/Memorija
        [ResponseType(typeof(Memorija))]
        public IHttpActionResult PostMemorija(Memorija memorija)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Memorija.Add(memorija);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = memorija.Id }, memorija);
        }

        // DELETE: api/Memorija/5
        [ResponseType(typeof(Memorija))]
        public IHttpActionResult DeleteMemorija(int id)
        {
            Memorija memorija = db.Memorija.Find(id);
            if (memorija == null)
            {
                return NotFound();
            }

            db.Memorija.Remove(memorija);
            db.SaveChanges();

            return Ok(memorija);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MemorijaExists(int id)
        {
            return db.Memorija.Count(e => e.Id == id) > 0;
        }
    }
}