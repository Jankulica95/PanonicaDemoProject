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
    public class ContractsController : ApiController
    {
        IContractRepository _repository { get; set; }
        public ContractsController (IContractRepository repository)
        {
            _repository = repository;
        }


        public IQueryable<Contract> Get()
        {
            return _repository.GetAll();
        }
        public IHttpActionResult Get(int id)
        {
            var contract = _repository.GetById(id);
            if (contract == null)
            {
                return NotFound();
            }
            return Ok();
        }
        public IHttpActionResult Post(Contract contract)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.Add(contract);
            return Ok();
        }
        public IHttpActionResult Put(int id, Contract contract)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contract.Id)
            {
                return BadRequest();
            }

            try
            {
                _repository.Update(contract);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(contract);
        }
        public IHttpActionResult Delete(int id)
        {
            var contract = _repository.GetById(id);
            if (contract == null)
            {
                return NotFound();
            }

            _repository.Delete(contract);
            return Ok();
        }


        public IQueryable<Contract> GetMost()
        {
            return _repository.GetMost();
        }
        public IQueryable<Contract> GetMostRecent()
        {
            return _repository.GetMostRecent();
        }

    }
}
