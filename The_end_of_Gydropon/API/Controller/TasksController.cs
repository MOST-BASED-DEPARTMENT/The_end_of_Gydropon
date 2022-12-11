using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using The_end_of_Gydropon.API.Model;

namespace The_end_of_Gydropon.API.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class TasksController : ApiController
    {
        private Tasks[] products = 
        { 
            new Tasks
            { 
                ID = 1, 
                User = "berea", 
                Date = "31.01.2004", 
                Description = "wre",
                Field = "rewsd",
                Status = "11:00:00",
                FinishTime = "10:00:00",
                Type = "suck",
                Weather = "i want to kill myself" 
            }
        };

        public IEnumerable<Tasks> GetAllProducts()
        {
            return products;
        }

        public IHttpActionResult GetProduct(int id)
        {
            Tasks product = products.FirstOrDefault((p) => p.ID == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}