using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PanonicaV1.Models;
using PanonicaV1.Interfaces;


namespace PanonicaV1.Controllers.AppControllers
{
    public class ClientCompanyController : ApiController
    {
        IClientCompanyRepository _repository { get; set; }
        public ClientCompanyController (IClientCompanyRepository repository)
        {
            _repository = repository;
        }


        public IQueryable<ClientCompany> Get()
        {
            return _repository.GetAll();
        }

        public IHttpActionResult Get(int id)
        {
            var company = _repository.GetById(id);
            if (company == null)
            {
                return NotFound();
            }
            return Ok();
        }

        public IHttpActionResult Post(ClientCompany company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.Add(company);
            return Ok();
        }

        public IHttpActionResult Put(int id, ClientCompany company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != company.Id)
            {
                return BadRequest();
            }

            try
            {
                _repository.Update(company);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(company);
        }

        public IHttpActionResult Delete(int id)
        {
            var company = _repository.GetById(id);
            if (company == null)
            {
                return NotFound();
            }

            _repository.Delete(company);
            return Ok();
        }


    }
}
