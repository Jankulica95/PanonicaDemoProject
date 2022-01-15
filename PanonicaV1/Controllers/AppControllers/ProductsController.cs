using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PanonicaV1.Models.DTOs;
using PanonicaV1.Models;
using PanonicaV1.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace PanonicaV1.Controllers.AppControllers
{
    public class ProductsController : ApiController
    {
        IProductRepository _repository { get; set; }        

        public ProductsController (IProductRepository repository)
        {
            _repository = repository;
        }


        public IQueryable<ProductDTO> Get() 
        {
            return _repository.GetAll().ProjectTo<ProductDTO>();
        }
        public IHttpActionResult Get(int id) 
        {
            var product = _repository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<ProductDTO>(product));
        } 
        public IHttpActionResult Post(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.Add(product);
            return CreatedAtRoute("DefaultApi", new { id = product.Id }, product);
        }
        public IHttpActionResult Put (int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.Id)
            {
                return BadRequest();
            }

            try
            {
                _repository.Update(product);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(product);
        }
        public IHttpActionResult Delete (int id)
        {
            var product = _repository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            _repository.Delete(product);
            return Ok();
        }

        [Route("api/prices")] 
        public IEnumerable<Product> GetAllByPriceDesc()
        {
            return _repository.GetAllByPriceDesc();
        }

        [Route("api/productSeason")]
        public IEnumerable<ProductDTO> GetAllInSeason (int id)
        {
            return _repository.GetAllInSeason(id);
        }

        [Route("api/minimum")]
        public IEnumerable<ProductDTO> GetAllLessThen (int min)
        {
            return _repository.GetAllLessThen(min);
        }

    }
}
