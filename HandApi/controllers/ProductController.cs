using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HandApi.Data;
using HandApi.Models;
using HandApi.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HandApi.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _services;
 
        public ProductController(IProductServices services)
        {
            _services = services;
        }

        [HttpGet]
        public  IActionResult GetAll()
        {
            return StatusCode(200,  _services.GetAll());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int? id)
        {
            try
            {
                if (id == null)
                {
                    return BadRequest("El identificador es nulo.");
                }
                ProductEntity productEntity = _services.GetById(id);
                if (productEntity == null)
                {
                    return NotFound("Producto no encontrado.");
                }

                return Ok(productEntity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrio un error al obtener los datos del producto. " + ex.Message);
            }
            
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProductEntity model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Modelo no válido.");
                }
                _services.Create(model);             
                return Ok(model);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrio un error al crear el producto. " + ex.Message);
            }
            finally
            {
                model = null;
            }
          

        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return BadRequest("el identificador es nulo.");
                }
               

                _services.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "ocurrio un error al eliminar el producto. " + ex.Message);
            }

             
        }

        [HttpPut]
        public IActionResult Put([FromBody] ProductEntity model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Modelo no válido.");
                }
            
                _services.Update(model);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrio un error al actualizar los datos del artículo. " + ex.Message);
            }
        }
    }
}