using CongestionTaxCalculator.Services;
using Microsoft.AspNetCore.Mvc;

namespace CongestionTaxCalculator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CongestionTaxController : ControllerBase
    {
        private readonly CongestionTaxService _congestionTaxService;

        public CongestionTaxController(CongestionTaxService congestionTaxService)
        {
            _congestionTaxService = congestionTaxService;
        }

        [HttpPost]
        [Route("calculate")]
        public IActionResult CalculateTax([FromBody] TaxCalculationRequest request)
        {
            var totalTax = _congestionTaxService.CalculateTotalTax(request.VehicleType, request.Dates.ToArray());
            return Ok(new { TotalTax = totalTax });
        }
    }
}