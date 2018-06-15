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
    public class StatusNarudzbeController : ApiController
    {
        private hci231_MobitelShopEntities db = new hci231_MobitelShopEntities();

        // GET: api/StatusNarudzbe
        public IQueryable<StatusNarudzbe> GetStatusNarudzbe()
        {
            return db.StatusNarudzbe;
        }

        // GET: api/StatusNarudzbe/5
        [ResponseType(typeof(StatusNarudzbe))]
        public IHttpActionResult GetStatusNarudzbe(int id)
        {
            StatusNarudzbe statusNarudzbe = db.StatusNarudzbe.Find(id);
            if (statusNarudzbe == null)
            {
                return NotFound();
            }

            return Ok(statusNarudzbe);
        }

        // PUT: api/StatusNarudzbe/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStatusNarudzbe(int id, StatusNarudzbe statusNarudzbe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != statusNarudzbe.Id)
            {
                return BadRequest();
            }

            db.Entry(statusNarudzbe).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusNarudzbeExists(id))
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

        // POST: api/StatusNarudzbe
        [ResponseType(typeof(StatusNarudzbe))]
        public IHttpActionResult PostStatusNarudzbe(StatusNarudzbe statusNarudzbe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StatusNarudzbe.Add(statusNarudzbe);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = statusNarudzbe.Id }, statusNarudzbe);
        }

        // DELETE: api/StatusNarudzbe/5
        [ResponseType(typeof(StatusNarudzbe))]
        public IHttpActionResult DeleteStatusNarudzbe(int id)
        {
            StatusNarudzbe statusNarudzbe = db.StatusNarudzbe.Find(id);
            if (statusNarudzbe == null)
            {
                return NotFound();
            }

            db.StatusNarudzbe.Remove(statusNarudzbe);
            db.SaveChanges();

            return Ok(statusNarudzbe);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StatusNarudzbeExists(int id)
        {
            return db.StatusNarudzbe.Count(e => e.Id == id) > 0;
        }
    }
}