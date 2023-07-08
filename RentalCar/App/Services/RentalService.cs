using App.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services
{
    class RentalService
    {
        public double PricePerHour { get; private set; }
        public double PricePerDay { get; private set; }

        private ITaxService _taxService;

        public RentalService(double pricePerHour, double pricePerDay, ITaxService taxService)
        {
            PricePerHour = pricePerHour;
            PricePerDay = pricePerDay;
            _taxService = taxService;
        }

        public void ProcessInvoice(CarRental carRental)
        {
            TimeSpan duration = carRental.Finish.Subtract(carRental.Start);

            double basicPayment = duration.TotalHours <= 12.0
                ? PricePerHour * Math.Ceiling(duration.TotalHours)
                : PricePerDay * Math.Ceiling(duration.TotalDays);

            carRental.Invoice = new Invoice(basicPayment, _taxService.Tax(basicPayment));
        }
    }
}
