using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TheHopeless.API.Constants;
using TheHopeless.API.Contracts.RentalController;
using TheHopeless.API.Services;

namespace TheHopeless.API.Controllers
{
    [Route("api/Rent")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        private readonly IRentalService _service;

        public RentalController(IRentalService service)
        {
            _service = service;
        }

        [HttpGet]

        [Produces(typeof(ICollection<RentalAgreementDto>))]
        public async Task<IActionResult> Get()
        {
            var results = await _service.Get();

            return Ok(results);
        }

        [HttpGet("{id}", Name = nameof(RoutingEnum.GetRentalAgreement))]
        [Produces(typeof(RentalAgreementDto))]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _service.GetSpecific(id);

            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] NewRentalAgreementDto newRentalAgreement)
        {
            var createdAgreement = await _service.Add(newRentalAgreement);
            var agreementUri = CreateResourceUri(createdAgreement.Id);
            return Created(agreementUri, createdAgreement);
        }

        [HttpPut("{id}")]
        [Produces(typeof(RentalAgreementDto))]
        public async Task<IActionResult> Put(int id, [FromBody] NewRentalAgreementDto agreement)
        {
            var modifiedAgreement = await _service.Edit(id, agreement);

            var agreementUri = CreateResourceUri(modifiedAgreement.Id);
            return Accepted(agreementUri, modifiedAgreement);
        }

        [HttpPost("{id}/Terminate")]
        public async Task<IActionResult> Terminate(int id)
        {
            if (await _service.TerminateAgreement(id))
            {
                return NoContent();
            }
            return NotFound(id);
        }
        [HttpGet("Payments")]
        [Produces(typeof(ICollection<RentalPaymentTypeDto>))]
        public async Task<IActionResult> GetPayment()
        {
            var results = await _service.GetPayment();

            return Ok(results);
        }
        [HttpPost("{id}/State")]
        public async Task<IActionResult> State(int id)
        {
            if (await _service.ChangeState(id))
            {
                return NoContent();
            }
            return NotFound(id);
        }
        [HttpGet("report", Name = nameof(RoutingEnum.GetRentalReport))]
        [Produces(typeof(ICollection<RentalAgreementDto>))]
        public async Task<IActionResult> Report([FromBody] ReportDto report)
        {
            var results = await _service.Report(report.From, report.To);

            return Ok(results);
        }
        private Uri CreateResourceUri(int id)
        {
            return new Uri(Url.Link(nameof(RoutingEnum.GetRentalAgreement), new { id = id }));
        }

    }

    public class ReportDto
    {
        public int From;
        public int To;
    }
}