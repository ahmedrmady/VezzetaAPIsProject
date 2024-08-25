using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Vezzeta.APIs.Controllers
{
    [Route("api/buggy")]
    [ApiController]
    public class BuggyController : ControllerBase
    {
        [HttpGet("NotFound")]
        public ActionResult NotFoundError()
        =>NotFound();

        [HttpGet("BadRequest")]

        public ActionResult BadRequestError()
        => BadRequest();


        [HttpGet("Vaildation")] 
        public ActionResult ValidationError(int id)
        => BadRequest();


        [HttpGet("ServerError")]
        public ActionResult ServerError()
        {
            List<int> nums;
            
            return Ok(nums.FirstOrDefault(n=>n/2==1));
        }
    }
}
