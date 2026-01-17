using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        ProductServices pdservice;

        public ProductController(ProductServices pdservice)
        {
            this.pdservice = pdservice;
        }

        [HttpGet("AllProduct")]
        public IActionResult GetProducts()
        {
            var products = pdservice.AllProducts();
            return Ok(products);
        }

        [HttpGet("Getproduct/{id}")]
        public IActionResult GetProduct(int id)
        {
            var product=pdservice.ProductById(id);
            return Ok(product);
        }

        [HttpPost("Add")]
        public IActionResult AddToInventory([FromBody]ProductDTO product)
        {
            if(product == null)
            {
                return BadRequest("Product data Incorrect");
            }

            if (string.IsNullOrEmpty(product.ProductName))
            {
                return BadRequest("Product Name is required");
            }

            if (product.ProductPrice <= 0)
            {
                return BadRequest("Product Price must be greater than 0");
            }

            var service = pdservice.AddProduct(product);
            return Ok(service);
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult DeleteFromInventory(int id)
        {
            var service = pdservice.DeleteProduct(id);
            return Ok(service);
        }

        [HttpPut("Update")]
        public IActionResult UpdateInventory([FromBody]ProductDTO product)
        {
            if (pdservice.ProductById(product.ProductId) == null)
            {
                return BadRequest("Product Invalid");
            }
            if (string.IsNullOrEmpty(product.ProductName))
            {
                product.ProductName = pdservice.ProductById(product.ProductId).ProductName;
            }
            if (product.ProductPrice <= 0)
            {
                product.ProductPrice = pdservice.ProductById(product.ProductId).ProductPrice;
            }
            var service = pdservice.UpdateProduct(product);
            return Ok(service);
        }


    }
}
