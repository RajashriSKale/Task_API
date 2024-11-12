using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsManagementApplication.Migrations;
using ProductsManagementApplication.Model;

namespace ProductsManagementApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public readonly Application ac;
        public ProductController(Application ac)
        {
            this.ac = ac;
        }

        [HttpPost]
        public IActionResult GetData(Products aa)
        {
            ac.Products.Add(aa);
            ac.SaveChanges();


            return Ok("record save");
        }

        [HttpGet]
        public IActionResult GetData()
        {
            var r = ac.Products.ToList();

            return Ok(r);
        }

        [HttpGet("{id}")]
        public IActionResult GetSingledata(int id)
        {
            var r = ac.Products.Where(x => x.Id == id).FirstOrDefault();

            return Ok(r);
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteData(int id)
        {
            //var r = ac.Producttable.Where(x => x.Id == id).FirstOrDefault();
            //ac.Producttable.Remove(r);
            //ac.SaveChanges();
            //return Ok("Deleted Recorded");


            var project = ac.Products.Find(id);
            if (project == null)
            {
                return NotFound();
            }

            ac.Products.Remove(project);
            ac.SaveChanges();
            return Ok(new { message = "Project deleted successfully" });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Products p)
        {
            var r = ac.Products.Find(id);
            if (r == null)
            {
                return NotFound();
            }

            r.Name = p.Name;
            r.Price = p.Price;
            r.Quantity = p.Quantity;
            ac.Products.Update(r);
            ac.SaveChanges();
            return Ok(r);

        }
    }
}
