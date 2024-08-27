using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vezzeta.APIs.Error;

namespace Vezzeta.APIs.Controllers
{
    [Route("errors/{code}")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi =true)]
    public class ErrorsController : ControllerBase
    {

        public ActionResult Error(int code)
        => NotFound(new ApiResponse(code));
    }
}
