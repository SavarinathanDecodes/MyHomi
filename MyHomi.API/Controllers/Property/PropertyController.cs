using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MyHomi.API.Helper;
using MyHomi.PropertyManager.Service.Interface;
using MyHomi.PropertyManager.ViewModel.Request;
using MyHomi.PropertyManager.ViewModel.Response;

namespace MyHomi.API.Controllers.Property
{
    [EnableCors("MyPolicy")]
    [ApiController]
    public class PropertyController : BaseController
    {

        #region Private members

        private readonly IPropertyService _propertyService;

        #endregion


        #region Constractor

        public PropertyController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        #endregion


        #region End points

        [Route("CreateProperty")]
        [HttpPost]
        public async Task<IActionResult> CreateProperty([FromBody] PropertyRequestVM requestVM)
        {
            const string LOG_ID = "PropertyController::CreateProperty";

            try
            {
                PropertyResponseVM responseVM = await _propertyService.CreateProperty(requestVM);
                return Ok(new ApiResponse<PropertyResponseVM>(responseVM, "New property has been created", "CREATE-NEW-PROPERTY"));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{LOG_ID} {ex.Message}");
                return BadRequest("");
            }
        }

        #endregion

    }
}
