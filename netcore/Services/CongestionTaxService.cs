using Domain;
using System;

namespace CongestionTaxCalculator.Services
{
    public class CongestionTaxService
    {
        private readonly ITaxCalculatorStrategy _taxCalculator;

        public CongestionTaxService(ITaxCalculatorStrategy taxCalculator)
        {
            _taxCalculator = taxCalculator;
        }

        public decimal CalculateTotalTax(IVehicle vehicle, DateTime[] dates)
        {
            if (vehicle == null || dates == null || dates.Length == 0)
            {
                return 0;
            }

            return _taxCalculator.GetTax(vehicle, dates);
        }
    }
}