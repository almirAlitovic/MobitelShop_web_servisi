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
using MobitelShop_API.DTO;

namespace MobitelShop_API.Controllers
{
    public class MobiteliController : ApiController
    {
        private hci231_MobitelShopEntities db = new hci231_MobitelShopEntities();

        // GET: api/Mobiteli
        public IQueryable<Mobiteli> GetMobiteli()
        {
            return db.Mobiteli;
        }

        // GET: api/Mobiteli/5
        [ResponseType(typeof(Mobiteli))]
        public IHttpActionResult GetMobiteli(int id)
        {
            Mobiteli mobiteli = db.Mobiteli.Find(id);
            if (mobiteli == null)
            {
                return NotFound();
            }

            return Ok(mobiteli);
        }

        // GET: api/Mobiteli/5
        [ResponseType(typeof(MobiteliDTO))]
        [Route("api/Mobiteli/GetMobiteliById/{id}")]
        public IHttpActionResult GetMobiteliById(int id)

        {
            Mobiteli mobiteli = db.Mobiteli
                .Include(b => b.Brendovi)
                .Include(o => o.OperativniSistem)
                .Include(c => c.CpuJezgre)
                .Include(m => m.Memorija)
                .Where(m => m.Id == id).SingleOrDefault();

            MobiteliDTO mobitel = new MobiteliDTO {
                Id = mobiteli.Id,
                Brend = mobiteli.Brendovi.Naziv,
                OperativniSistem = mobiteli.OperativniSistem.Naziv,
                CpuJezgre = mobiteli.CpuJezgre.Opis,
                Memorija = mobiteli.Memorija.Kapacitet.ToString(),
                Cijena = mobiteli.Cijena,
                Naziv = mobiteli.Naziv,
                SlikaUrl = mobiteli.SlikaUrl,
                Status = mobiteli.Status
            };

            if (mobiteli == null)
            {
                return NotFound();
            }

            return Ok(mobitel);
        }

        [HttpGet]
        [ResponseType(typeof(List<Mobiteli>))]
        [Route("api/Mobiteli/GetMobiteliByNaziv/{naziv}")]
        public IHttpActionResult GetMobiteliByNaziv(string naziv="")
        {

            if (naziv != "")
            {
                return Ok(db.ms_SelectMobitelByNaziv(naziv).ToList());
            }
            else
            {
                return NotFound();
            }

        }

        [HttpGet]
        [ResponseType(typeof(List<Mobiteli>))]
        [Route("api/Mobiteli/GetMobiteliByFilteri/{brendId?}/{cpuId?}/{memorijaId?}/{osId?}")]
        public IHttpActionResult GetMobiteliByFilteri(int? brendId = 0, int? cpuId = 0, int? memorijaId = 0, int? osId = 0)
        {
            List<Mobiteli> mobiteli = new List<Mobiteli>();

            if (brendId != 0)
            {
                mobiteli = db.Mobiteli.Where(x => x.BrendoviId == brendId).ToList();

                if (cpuId != 0)
                {
                    mobiteli = mobiteli.Where(c => c.CpuJezgreId == cpuId).ToList();
                }
                if (memorijaId != 0)
                {
                    mobiteli = mobiteli.Where(m => m.MemorijaId == memorijaId).ToList();
                }
                if (osId != 0)
                {
                    mobiteli = mobiteli.Where(o => o.OperativniSistemId == osId).ToList();
                }
            }

            else if (cpuId != 0)
            {
                mobiteli = db.Mobiteli.Where(x => x.CpuJezgreId == cpuId).ToList();

                if (brendId != 0)
                {
                    mobiteli = mobiteli.Where(c => c.BrendoviId == brendId).ToList();
                }
                if (memorijaId != 0)
                {
                    mobiteli = mobiteli.Where(m => m.MemorijaId == memorijaId).ToList();
                }
                if (osId != 0)
                {
                    mobiteli = mobiteli.Where(o => o.OperativniSistemId == osId).ToList();
                }
            }

            else if (memorijaId != 0)
            {
                mobiteli = db.Mobiteli.Where(x => x.MemorijaId == memorijaId).ToList();

                if (cpuId != 0)
                {
                    mobiteli = mobiteli.Where(c => c.CpuJezgreId == cpuId).ToList();
                }
                if (brendId != 0)
                {
                    mobiteli = mobiteli.Where(p => p.BrendoviId == brendId).ToList();
                }
                if (osId != 0)
                {
                    mobiteli = mobiteli.Where(o => o.OperativniSistemId == osId).ToList();
                }
            }

            else if (osId != 0)
            {
                mobiteli = db.Mobiteli.Where(x => x.OperativniSistemId == osId).ToList();

                if (cpuId != 0)
                {
                    mobiteli = mobiteli.Where(c => c.CpuJezgreId == cpuId).ToList();
                }
                if (memorijaId != 0)
                {
                    mobiteli = mobiteli.Where(m => m.MemorijaId == memorijaId).ToList();
                }
                if (brendId != 0)
                {
                    mobiteli = mobiteli.Where(p => p.BrendoviId == brendId).ToList();
                }
            }
            else
            {
                mobiteli = db.Mobiteli.ToList();
            }


            return Ok(mobiteli);
        }


        // PUT: api/Mobiteli/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMobiteli(int id, Mobiteli mobiteli)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mobiteli.Id)
            {
                return BadRequest();
            }

            db.Entry(mobiteli).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MobiteliExists(id))
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

        // POST: api/Mobiteli
        [ResponseType(typeof(Mobiteli))]
        public IHttpActionResult PostMobiteli(Mobiteli mobiteli)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Mobiteli.Add(mobiteli);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = mobiteli.Id }, mobiteli);
        }

        // DELETE: api/Mobiteli/5
        [ResponseType(typeof(Mobiteli))]
        public IHttpActionResult DeleteMobiteli(int id)
        {
            Mobiteli mobiteli = db.Mobiteli.Find(id);
            if (mobiteli == null)
            {
                return NotFound();
            }

            db.Mobiteli.Remove(mobiteli);
            db.SaveChanges();

            return Ok(mobiteli);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MobiteliExists(int id)
        {
            return db.Mobiteli.Count(e => e.Id == id) > 0;
        }
    }
}