using Domain;
using System;

namespace CongestionTaxCalculator.Services
{
    public class GothenburgTaxCalculator : ITaxCalculatorStrategy
    {
        private readonly CongestionTaxCalculatorService _congestionTaxCalculator;

        public GothenburgTaxCalculator()
        {
            _congestionTaxCalculator = new CongestionTaxCalculatorService();
        }

        public int GetTax(IVehicle vehicle, DateTime[] dates)
        {
            if (vehicle == null || dates == null || dates.Length == 0)
            {
                return 0;
            }

            return _congestionTaxCalculator.GetTax(vehicle, dates);
        }
    }
}