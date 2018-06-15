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
    public class CpuJezgreController : ApiController
    {
        private hci231_MobitelShopEntities db = new hci231_MobitelShopEntities();

        // GET: api/CpuJezgre
        public IQueryable<CpuJezgre> GetCpuJezgre()
        {
            return db.CpuJezgre;
        }

        // GET: api/CpuJezgre/5
        [ResponseType(typeof(CpuJezgre))]
        public IHttpActionResult GetCpuJezgre(int id)
        {
            CpuJezgre cpuJezgre = db.CpuJezgre.Find(id);
            if (cpuJezgre == null)
            {
                return NotFound();
            }

            return Ok(cpuJezgre);
        }

        // PUT: api/CpuJezgre/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCpuJezgre(int id, CpuJezgre cpuJezgre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cpuJezgre.Id)
            {
                return BadRequest();
            }

            db.Entry(cpuJezgre).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CpuJezgreExists(id))
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

        // POST: api/CpuJezgre
        [ResponseType(typeof(CpuJezgre))]
        public IHttpActionResult PostCpuJezgre(CpuJezgre cpuJezgre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CpuJezgre.Add(cpuJezgre);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cpuJezgre.Id }, cpuJezgre);
        }

        // DELETE: api/CpuJezgre/5
        [ResponseType(typeof(CpuJezgre))]
        public IHttpActionResult DeleteCpuJezgre(int id)
        {
            CpuJezgre cpuJezgre = db.CpuJezgre.Find(id);
            if (cpuJezgre == null)
            {
                return NotFound();
            }

            db.CpuJezgre.Remove(cpuJezgre);
            db.SaveChanges();

            return Ok(cpuJezgre);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CpuJezgreExists(int id)
        {
            return db.CpuJezgre.Count(e => e.Id == id) > 0;
        }
    }
}