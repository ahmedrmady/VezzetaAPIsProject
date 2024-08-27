using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Vezzeta.APIs.Controllers
{
    [Route("errors/{code}")]
    [ApiController]
    public class ErrorsController : ControllerBase
    {
    }
}
