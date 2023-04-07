using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {

        [HttpGet(Name = "GetCategories")]
        public void Get()
        {

        }

        [HttpPut(Name = "UpdateCategory")]
        public void Update()
        {

        }

        [HttpDelete(Name = "DeleteCategory")]
        public void Delete()
        {

        }

        [HttpPost(Name = "AddCategory")]
        public void Add()
        {

        }


    }
}
