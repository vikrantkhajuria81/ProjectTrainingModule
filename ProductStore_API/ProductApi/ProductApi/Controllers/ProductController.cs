using System.ComponentModel.DataAnnotations;
using ServiceLayer;
using DomainLayer.Entities;
using ServiceLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using ServiceLayer.Services;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

      
        public ProductController(IUnitOfWork unitofwork)
        {
            UnitOfWork = unitofwork;
        }

        public IUnitOfWork UnitOfWork { get; set; }


        [HttpGet]
        [Route("getall")]
        public IActionResult GetAllProduct()
        {
            var response = UnitOfWork.ProductRepository.GetAllProduct();
            return Ok(response);
        }


        [HttpGet]
        [Route("getById")]
        public IActionResult GetProduct(int id)
        {
            var response = UnitOfWork.ProductRepository.GetProduct(id);
            return Ok(response);
        }

        [HttpPost]
        [Route("addproduct")]
        public IActionResult AddProduct(ProductEntity product)
        {
            return Ok(UnitOfWork.ProductRepository.AddProduct(product));
        }

        [HttpDelete]
        [Route("delete")]
        public IActionResult DeleteProduct(int id)
        {
            return Ok(UnitOfWork.ProductRepository.DeleteProduct(id));
        }


        [HttpPut]
        [Route("edit")]
        public IActionResult UpdateProduct(ProductEntity product)
        {
            return Ok(UnitOfWork.ProductRepository.UpdateProduct(product));
        }



        [HttpGet]
        [Route("search")]
        public async Task<ActionResult<IEnumerable<ProductEntity>>> Search(string name)
        {
            try
            {
                var result = await UnitOfWork.ProductRepository.Search(name);

                if (result.Any())
                {
                    return Ok(result);
                }

                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
    }
}
