using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PanonicaV1.Models;
using PanonicaV1.Models.DTOs;
using PanonicaV1.Interfaces;

namespace PanonicaV1.Controllers.AppControllers
{
    public class PackagesController : ApiController
    {
        IPackageRepository _repository { get; set; }
        public PackagesController (IPackageRepository repository)
        {
            _repository = repository;
        }

        
        public IQueryable<Packaging> Get()
        {
            return _repository.GetAll();
        }
        public IHttpActionResult Get(int id)
        {
            var package = _repository.GetById(id);
            if (package == null)
            {
                return NotFound();
            }
            return Ok(package);
        }
        public IHttpActionResult Post(Packaging package)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.Add(package);
            return Ok();
        }
        public IHttpActionResult Put(int id, Packaging package)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != package.Id)
            {
                return BadRequest();
            }

            try
            {
                _repository.Update(package);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(package);
        }
        public IHttpActionResult Delete (int id)
        {
            var package = _repository.GetById(id);
            if (package== null)
            {
                return NotFound();
            }
            return Ok();
        }

        //public IQueryable<PackagingDTO> GetTimesUsed()
        //{
        //    return _repository.GetTimesUsed();
        //} //Nije implementirano!

    }
}

