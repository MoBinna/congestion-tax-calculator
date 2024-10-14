using Domain;
using System;
using System.Collections.Generic;

namespace CongestionTaxCalculator.Controllers
{
    public class TaxCalculationRequest
    {
        public IVehicle VehicleType { get; set; }
        public List<DateTime> Dates { get; set; }
    }
}