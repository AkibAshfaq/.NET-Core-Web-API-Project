using BLL.Services;
using DAL.EF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ECommarceController : ControllerBase
    {
        OrderServices odservice;

        public ECommarceController(OrderServices odservice)
        {
            this.odservice = odservice;
        }

        [HttpGet("HomePage")]
        public IActionResult HomePage()
        {
            return Ok();
        }


        [HttpGet("HomePage/{Catagory}")]
        public IActionResult HomePage(string? Catagory)
        {
            if (Catagory == null)
            {
                return BadRequest("Catagory is need to be set");
            }
            else
            {
                return Ok();
            }
        }


        [HttpPost("AddToCartById/{ProductId}")]
        public IActionResult AddToCart(int ProductId)
        {
            if (ProductId == null)
            {
                return BadRequest("Product ID is required to add to cart");
            }
            else
            {
                return Ok(odservice.AddToCartById(ProductId));
            }
        }

        [HttpPost("RemoveFromCartById/{ProductId}")]
        public IActionResult RemoveFromCart(int ProductId)
        {
            if (ProductId == null)
            {
                return BadRequest("Product ID is required to add to cart");
            }
            else
            {
                return Ok(odservice.RemoveFromCartById(ProductId));
            }
        }


        [HttpPost("AddToCartByName/{ProductName}")]
        public IActionResult AddToCart(string? ProductName)
        {
            if (ProductName == null)
            {
                return BadRequest("Product Name is required to add to cart");
            }
            else
            {
                return Ok();
            }
        }

        [HttpGet("ViewCart")]
        public IActionResult ViewCart()
        {
            return Ok();
        }

        [HttpPost("Checkout")]
        public IActionResult Checkout()
        {
            return Ok();
        }

        [HttpPost("Payment")]
        public IActionResult Payment()
        {
            return Ok();
        }

    }
}
