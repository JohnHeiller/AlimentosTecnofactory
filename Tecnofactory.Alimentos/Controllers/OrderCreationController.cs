using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tecnofactory.Alimentos.BL.Interface;
using Tecnofactory.Alimentos.DTO;

namespace Tecnofactory.Alimentos.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class OrderCreationController : Controller
    {
        private readonly IOrderCreationService _orderCreationService;
        public OrderCreationController(IOrderCreationService orderCreationService)
        {
            _orderCreationService = orderCreationService;
        }

        [HttpPost(nameof(AddUserOrder))]
        public async Task<IActionResult> AddUserOrder([FromBody] UserOrderDto userOrder)
        {
            bool response = await _orderCreationService.AddUserOrder(userOrder);
            return response ? Ok(response) : BadRequest(response);
        }

        [HttpGet(nameof(GetAllOrders))]
        public IActionResult GetAllOrders()
        {
            List<UserOrderDto> response = _orderCreationService.GetAllOrders();
            return Ok(response);
        }
    }
}
