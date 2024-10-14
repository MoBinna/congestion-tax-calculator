using congestion.calculator.Domain;
using Domain;
using System;

namespace CongestionTaxCalculator.Services
{
    public class CongestionTaxCalculatorService : ITaxCalculatorStrategy
    {
        public int GetTax(IVehicle vehicle, DateTime[] dates)
        {
            if (dates == null || dates.Length == 0) return 0;

            int totalFee = 0;

            DateTime intervalStart = dates[0];

            foreach (DateTime date in dates)
            {
                int nextFee = GetTollFee(date, vehicle);
                int tempFee = GetTollFee(intervalStart, vehicle);

                long diffInMilliseconds = (date - intervalStart).Milliseconds;
                long minutes = diffInMilliseconds / 1000 / 60;

                if (minutes <= 60)
                {
                    if (totalFee > 0) totalFee -= tempFee;
                    if (nextFee >= tempFee) tempFee = nextFee;
                    totalFee += tempFee;
                }
                else
                {
                    totalFee += nextFee;
                }

                intervalStart = date;
            }

            if (totalFee > 60) totalFee = 60;
            return totalFee;
        }

        private int GetTollFee(DateTime date, IVehicle vehicle)
        {
            if (IsTollFreeDate(date) || IsTollFreeVehicle(vehicle)) return 0;

            int hour = date.Hour;
            int minute = date.Minute;

            if (hour == 6 && minute >= 0 && minute <= 29) return 8;
            else if (hour == 6 && minute >= 30 && minute <= 59) return 13;
            else if (hour == 7) return 18;
            else if (hour == 8 && minute <= 29) return 13;
            else if (hour >= 8 && hour <= 14 && minute >= 30) return 8;
            else if (hour == 15 && minute <= 29) return 13;
            else if (hour == 15 || hour == 16) return 18;
            else if (hour == 17) return 13;
            else if (hour == 18 && minute <= 29) return 8;
            else return 0;
        }

        private bool IsTollFreeVehicle(IVehicle vehicle)
        {
            return vehicle.GetVehicleType() == VehicleType.Emergency ||
                   vehicle.GetVehicleType() == VehicleType.Military ||
                   vehicle.GetVehicleType() == VehicleType.Diplomat ||
                   vehicle.GetVehicleType() == VehicleType.Foreign;
        }

        private bool IsTollFreeDate(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
        }
    }
}