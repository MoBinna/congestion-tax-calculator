using Domain;
using System;

namespace CongestionTaxCalculator.Services
{
    public interface ITaxCalculatorStrategy
    {
        int GetTax(IVehicle vehicle, DateTime[] dates);
    }
}