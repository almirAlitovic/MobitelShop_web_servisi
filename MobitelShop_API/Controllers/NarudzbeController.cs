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
    public class NarudzbeController : ApiController
    {
        private hci231_MobitelShopEntities db = new hci231_MobitelShopEntities();

        // GET: api/Narudzbe
        public IEnumerable<Narudzbe> GetNarudzbe()
        {
            return db.Narudzbe;
        }

        // GET: api/Narudzbe/5
        [ResponseType(typeof(Narudzbe))]
        public IHttpActionResult GetNarudzbe(int id)
        {
            Narudzbe narudzbe = db.Narudzbe.Find(id);
            if (narudzbe == null)
            {
                return NotFound();
            }

            return Ok(narudzbe);
        }

        [HttpGet]
        [ResponseType(typeof(List<Narudzbe>))]
        [Route("api/Narudzbe/GetNarudzbeByKupacId/{kupacId}")]
        public IHttpActionResult GetNarudzbeByKupacId(int kupacId)
        {
            List<Narudzbe> narudzbe = db.Narudzbe.Where(x => x.KupacId == kupacId).ToList();

            if (narudzbe == null)
            {
                return NotFound();
            }

            return Ok(narudzbe);
        }

        [HttpGet]
        [ResponseType(typeof(List<ms_SelectNarudzbaStavkeByKupacId_Result>))]
        [Route("api/Narudzbe/GetHistorijaByKupacId/{kupacId}")]
        public IHttpActionResult GetHistorijaByKupacId(int kupacId)
        {
            List<ms_SelectNarudzbaStavkeByKupacId_Result> historija = db.ms_SelectNarudzbaStavkeByKupacId(kupacId).ToList();

            if (historija == null)
            {
                return NotFound();
            }
            return Ok(historija);
        }


        // PUT: api/Narudzbe/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNarudzbe(int id, Narudzbe narudzbe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != narudzbe.Id)
            {
                return BadRequest();
            }

            db.Entry(narudzbe).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NarudzbeExists(id))
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

        // POST: api/Narudzbe
        [ResponseType(typeof(Narudzbe))]
        public IHttpActionResult PostNarudzbe(NarudzbaDTO narudzbaDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Narudzbe narudzba = new Narudzbe();
            narudzba.BrojNarudzbe = narudzbaDTO.BrojNarudzbe;
            narudzba.Datum = narudzbaDTO.Datum;
            narudzba.UkupniIznos = narudzbaDTO.UkupniIznos;
            narudzba.StatusNarudzbeId = narudzbaDTO.StatusNarudzbeId;
            narudzba.KupacId = narudzbaDTO.KupacId;

            db.Narudzbe.Add(narudzba);
            db.SaveChanges();

            foreach (NarudzbaStavke item in narudzbaDTO.stavke)
            {
                NarudzbaStavke stavka = new NarudzbaStavke();
                stavka = item;
                stavka.NarudzbaId = narudzba.Id;
                db.NarudzbaStavke.Add(stavka);
            }
            db.SaveChanges();

            //return CreatedAtRoute("DefaultApi", new { id = narudzba.Id }, narudzba);

            return Ok(narudzba);
        }

        // DELETE: api/Narudzbe/5
        [ResponseType(typeof(Narudzbe))]
        public IHttpActionResult DeleteNarudzbe(int id)
        {
            Narudzbe narudzbe = db.Narudzbe.Find(id);
            if (narudzbe == null)
            {
                return NotFound();
            }

            db.Narudzbe.Remove(narudzbe);
            db.SaveChanges();

            return Ok(narudzbe);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NarudzbeExists(int id)
        {
            return db.Narudzbe.Count(e => e.Id == id) > 0;
        }
    }
}