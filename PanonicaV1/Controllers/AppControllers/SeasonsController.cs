using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PanonicaV1.Models;
using PanonicaV1.Interfaces;
using PanonicaV1.Repository;

namespace PanonicaV1.Controllers
{
    public class SeasonsController : ApiController
    {
        ISeasonRepository _repository { get; set; }

        public SeasonsController(ISeasonRepository repository)
        {
            _repository = repository;
        }


        public IQueryable<Season> Get()
        {
            return _repository.GetAll();
        }
        public IHttpActionResult Get(int id)
        {
            var season = _repository.GetById(id);
            if (season== null)
            {
                return NotFound();
            }
            return Ok();
        }
        public IHttpActionResult Post(Season season)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.Add(season);
            return CreatedAtRoute("DefaultApi", new { id = season.Id }, season); ///Sta se tacno desava?
            //return Ok();

        }
        public IHttpActionResult Put(int id, Season season)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != season.Id)
            {
                return BadRequest();
            }

            try
            {
                _repository.Update(season);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(season);
        }
        public IHttpActionResult Delete(int id)
        {
            var season = _repository.GetById(id);
            if (season == null)
            {
                return NotFound();
            }

            _repository.Delete(season);
            return Ok();
        }


    }
}
