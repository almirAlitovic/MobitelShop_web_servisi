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
    public class OperativniSistemController : ApiController
    {
        private hci231_MobitelShopEntities db = new hci231_MobitelShopEntities();

        // GET: api/OperativniSistem
        public IQueryable<OperativniSistem> GetOperativniSistem()
        {
            return db.OperativniSistem;
        }

        // GET: api/OperativniSistem/5
        [ResponseType(typeof(OperativniSistem))]
        public IHttpActionResult GetOperativniSistem(int id)
        {
            OperativniSistem operativniSistem = db.OperativniSistem.Find(id);
            if (operativniSistem == null)
            {
                return NotFound();
            }

            return Ok(operativniSistem);
        }

        // PUT: api/OperativniSistem/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOperativniSistem(int id, OperativniSistem operativniSistem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != operativniSistem.Id)
            {
                return BadRequest();
            }

            db.Entry(operativniSistem).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OperativniSistemExists(id))
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

        // POST: api/OperativniSistem
        [ResponseType(typeof(OperativniSistem))]
        public IHttpActionResult PostOperativniSistem(OperativniSistem operativniSistem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OperativniSistem.Add(operativniSistem);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = operativniSistem.Id }, operativniSistem);
        }

        // DELETE: api/OperativniSistem/5
        [ResponseType(typeof(OperativniSistem))]
        public IHttpActionResult DeleteOperativniSistem(int id)
        {
            OperativniSistem operativniSistem = db.OperativniSistem.Find(id);
            if (operativniSistem == null)
            {
                return NotFound();
            }

            db.OperativniSistem.Remove(operativniSistem);
            db.SaveChanges();

            return Ok(operativniSistem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OperativniSistemExists(int id)
        {
            return db.OperativniSistem.Count(e => e.Id == id) > 0;
        }
    }
}