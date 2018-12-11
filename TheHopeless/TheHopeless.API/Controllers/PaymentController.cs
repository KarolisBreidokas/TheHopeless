using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheHopeless.API.Constants;
using TheHopeless.API.Contracts.RentalController;
using TheHopeless.API.Services;

namespace TheHopeless.API.Controllers
{
    [Route("api/Payment")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _service;
        public PaymentController(IPaymentService service)
        {
            _service = service;
        }
        
        [Produces(typeof(ICollection<RentalPaymentTypeDto>))]
        public async Task<IActionResult> GetPaymentMethodList()
        {
            var results = await _service.GetPaymentMethodList();

            return Ok(results);
        }

        [HttpPut("{id}/State")]
        public async Task<IActionResult> ChangeMethodState(int id, bool state)
        {
            if (await _service.ChangeMethodState(id, state))
            {
                return NoContent();
            }
            return NotFound(id);
        }
        
        private Uri CreateResourceUri(int id)
        {
            return new Uri(Url.Link(nameof(RoutingEnum.GetRentalAgreement), new { id = id }));
        }
    }
}
