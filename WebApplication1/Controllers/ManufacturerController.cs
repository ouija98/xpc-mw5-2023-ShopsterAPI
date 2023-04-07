using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ManufacturerController : ControllerBase
    {

        [HttpGet(Name = "GetManufacturers")]
        public void Get()
        {

        }
        
        [HttpPut(Name = "UpdateManufacturer")]
        public void Update()
        {

        }
        
        [HttpDelete(Name = "DeleteManufacturer")]
        public void Delete()
        {

        }
        
        [HttpPost(Name = "AddManufacturer")]
        public void Add()
        {

        }
        

    }
}
