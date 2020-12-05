using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularApp.Models;

namespace AngularApp.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : Controller
    {
        ApplicationContext context;

        public ProductController(ApplicationContext applicationContext)
        {
            context = applicationContext;
            if(!context.Products.Any())
            {
                context.Products.Add(new Product { Name = "iPhone X", Manufacturer = "Apple", Price = 79900 });
                context.Products.Add(new Product { Name = "Galaxy S8", Manufacturer = "Samsung", Price = 49900 });
                context.Products.Add(new Product { Name = "Pixel 2", Manufacturer = "Google", Price = 52900 });
                context.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return context.Products.ToList();
        }

        [HttpGet("{id}")]
        public Product GetProduct(int id)
        {
            Product result = context.Products.FirstOrDefault(x => x.Id == id);
            return result;
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            if(ModelState.IsValid)
            {
                context.Products.Add(product);
                context.SaveChanges();
                return Ok(product);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult ChangeProduct(Product product)
        {
            if(ModelState.IsValid)
            {
                context.Update(product);
                context.SaveChanges();
                return Ok(product);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            Product product = context.Products.FirstOrDefault(x => x.Id == id);
            if(product != null)
            {
                context.Remove(product);
                context.SaveChanges();
                return Ok(product);
            }
            return BadRequest("Product with that ID doesn't exist");
        }
    }
}
