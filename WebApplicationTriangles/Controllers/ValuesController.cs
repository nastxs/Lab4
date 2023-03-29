using Microsoft.AspNetCore.Mvc;
using Lab4;

namespace WebApplicationTriangles.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public ValuesController(ITriangleProvider triangleProvider, ITriangleService triangleService)
        {
            TriangleItems = triangleProvider;
            Service = triangleService;
        }
        public ITriangleProvider TriangleItems{ get; set; }
        public ITriangleService Service { get; set; }

        

        [HttpGet("all")]
        public bool Get()
        {
            TriangleValidateService service = new TriangleValidateService(TriangleItems, Service);
            return service.IsAllValid();
        }
        //loca:8080/api/values?a=1&base=2
        
        [HttpGet]
        public IActionResult Get([FromQuery]double a, [FromQuery] double b, [FromQuery] double c)
        {
            try { var item = TriangleItems.GetBySides(a, b, c);
                TriangleValidateService service = new TriangleValidateService(TriangleItems, Service);
                return new ObjectResult(service.IsValid(item.Id));
            }
            catch
            {
                return NotFound();
            }
        }

       
    }
}
