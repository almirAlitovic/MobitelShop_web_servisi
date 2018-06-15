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
    public class KupciController : ApiController
    {
        private hci231_MobitelShopEntities db = new hci231_MobitelShopEntities();

        // GET: api/Kupci
        public IQueryable<Kupci> GetKupci()
        {
            return db.Kupci;
        }

        // GET: api/Kupci/5
        [ResponseType(typeof(Kupci))]
        public IHttpActionResult GetKupci(int id)
        {
            Kupci kupci = db.Kupci.Find(id);
            if (kupci == null)
            {
                return NotFound();
            }

            return Ok(kupci);
        }

        [HttpGet]
        [ResponseType(typeof(Kupci))]
        [Route("api/Kupci/getKupacByLogin/{user}/{password}")]
        public IHttpActionResult getKupacByLogin(string user, string password)
        {
            Kupci kupac = db.Kupci.SingleOrDefault(k => k.KorisnickoIme == user && k.Lozinka == password);

            if (kupac == null)
                return NotFound();

            return Ok(kupac);
        }

        // PUT: api/Kupci/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKupci(int id, Kupci kupci)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kupci.Id)
            {
                return BadRequest();
            }

            db.Entry(kupci).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KupciExists(id))
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

        // POST: api/Kupci
        [ResponseType(typeof(Kupci))]
        public IHttpActionResult PostKupci(Kupci kupci)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Kupci.Add(kupci);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = kupci.Id }, kupci);
        }

        // DELETE: api/Kupci/5
        [ResponseType(typeof(Kupci))]
        public IHttpActionResult DeleteKupci(int id)
        {
            Kupci kupci = db.Kupci.Find(id);
            if (kupci == null)
            {
                return NotFound();
            }

            db.Kupci.Remove(kupci);
            db.SaveChanges();

            return Ok(kupci);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KupciExists(int id)
        {
            return db.Kupci.Count(e => e.Id == id) > 0;
        }
    }
}