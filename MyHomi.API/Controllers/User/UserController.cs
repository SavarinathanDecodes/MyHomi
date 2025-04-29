using Microsoft.AspNetCore.Mvc;

namespace MyHomi.API.Controllers.Module
{
    public class UserController : BaseController
    {
        #region End Points

        [Route("HelloWorld")]
        [HttpGet]
        public IActionResult HelloWorld()
        {
            return Ok("HelloWorld");
        }

        #endregion
    }
}
