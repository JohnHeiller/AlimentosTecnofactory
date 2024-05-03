using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tecnofactory.Alimentos.BL.Interface;
using Tecnofactory.Alimentos.DTO;

namespace Tecnofactory.Alimentos.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class FoodManagementController : Controller
    {
        private readonly IFoodManagementService _foodManagementService;
        public FoodManagementController(IFoodManagementService foodManagementService)
        {
            _foodManagementService = foodManagementService;
        }

        [HttpPost(nameof(AddElementCatalogue))]
        public IActionResult AddElementCatalogue([FromBody] List<FoodDto> foods)
        {
            var response = _foodManagementService.AddElementCatalogue(foods);
            return Ok(response);
        }

        [HttpPut(nameof(UpdateElementCatalogue))]
        public IActionResult UpdateElementCatalogue([FromBody] FoodDto food)
        {
            Guid response = _foodManagementService.UpdateElementCatalogue(food);
            return Ok(response);
        }

        [HttpDelete(nameof(DeleteElementCatalogue))]
        public IActionResult DeleteElementCatalogue([FromBody] FoodDto food)
        {
            Guid response = _foodManagementService.DeleteElementCatalogue(food);
            return Ok(response);
        }

        [HttpGet(nameof(GetAllAvailableElementCatalogue))]
        public IActionResult GetAllAvailableElementCatalogue()
        {
            List<FoodDto> response = _foodManagementService.GetAllAvailableElementCatalogue();
            return Ok(response);
        }
    }
}
