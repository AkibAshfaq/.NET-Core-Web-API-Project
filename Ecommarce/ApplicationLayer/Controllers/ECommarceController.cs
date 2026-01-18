using BLL.DTOs;
using BLL.Services;
using DAL.EF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ApplicationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ECommarceController : ControllerBase
    {
        OrderServices odservice;
        ProductServices pdservice;

        public ECommarceController(OrderServices odservice, ProductServices pdservice)
        {
            this.odservice = odservice;
            this.pdservice = pdservice;
        }

        [HttpGet("HomePage")]
        public IActionResult HomePage()
        {
            var products = pdservice.AllProducts();
            if (products == null)
            {
                return BadRequest("No products available");
            }
            return Ok(products);
        }

        [HttpGet("HomePage/Category/{Catagory}")]
        public IActionResult HomePage(string Catagory)
        {
            if (Catagory == null)
            {
                return BadRequest("Catagory is need to be set");
            }
            else
            {
                var product = odservice.ProductByCategory(Catagory);
                if (product == null)
                {
                    return BadRequest("No products available in this category");
                }
                return Ok(product);
            }
        }


        [HttpPost("AddToCart/Id/{ProductId}")]
        public IActionResult AddToCart(int ProductId)
        {
            if (ProductId <= 0)
            {
                return BadRequest("Product ID is required to add to cart");
            }

            var product = odservice.AddToCartById(ProductId);
            if (!product.Any())
            {
                return NotFound("Product not found");
            }
            return Ok(product);
        }

        [HttpPost("RemoveFromCart/Id/{ProductId}")]
        public IActionResult RemoveFromCart(int ProductId)
        {
            if (ProductId < 0)
            {
                return BadRequest("Product ID is required to add to cart");
            }

            var product = odservice.RemoveFromCartById(ProductId);
            if (product == null)
            {
                return BadRequest("Product not found in cart");
            }
            return Ok();
        }


        [HttpPost("AddToCart/Name/{ProductName}")]
        public IActionResult AddToCart(string? ProductName)
        {
            if (ProductName.IsNullOrEmpty())
            {
                return BadRequest("Product Name is required to add to cart");
            }

            var result = odservice.AddToCartByName(ProductName);
            if(result == null)
            { 
                 return BadRequest("Product not found");
            }
            return Ok(result);
        }

        [HttpPost("RemoveFromCart/Name/{ProductName}")]
        public IActionResult RemoveFromCart(string ProductName)
        {
            if (ProductName.IsNullOrEmpty())
            {
                return BadRequest("Product Name is required to remove from cart");
            }

            var result = odservice.RemoveFromCartByName(ProductName);
            if (!result)
            {
                return BadRequest("Product not found in cart");
            }
            return Ok();    

        }


        [HttpGet("ViewCart")]
        public IActionResult ViewCart()
        {
            var cartItems = odservice.ViewCart();
            return Ok(cartItems);
        }

        [HttpGet("ClearCart")]
        public IActionResult ClearCart()
        {
            var result = odservice.ClearCart();
            if (!result)
            {
                return BadRequest("Cart is already empty");
            }
            return Ok("Cart Cleared");
        }

        [HttpGet("Checkout")]
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
