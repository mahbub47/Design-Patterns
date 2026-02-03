using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Patterns.Behavioural_Design_Patterns
{
    public class StrategiPattern
    {
        public enum VehicleType { Car, Van, Motorcycle}
        public class Ticket
        {
            private string ticketId;
            private VehicleType vehicle;

            public Ticket(VehicleType vehicleType)
            {
                this.ticketId = Guid.NewGuid().ToString();
                this.vehicle = vehicleType;
            }

            public VehicleType GetVehicleType()
            {
                return vehicle;
            }
        }
        public interface IHourlyParkingRateStrategi
        {
            decimal CalculateHourlyParkingRate(Ticket ticket);
        }

        public class FlatRate : IHourlyParkingRateStrategi
        {
            public decimal CalculateHourlyParkingRate(Ticket ticket)
            {
                return 10m;
            }
        }

        public class VehicleBaseRate : IHourlyParkingRateStrategi
        {
            public decimal CalculateHourlyParkingRate(Ticket ticket)
            {
                return ticket.GetVehicleType() switch
                {
                    VehicleType.Motorcycle => 10.00m,
                    VehicleType.Car => 15.00m,
                    VehicleType.Van => 20.00m,
                    _ => 10.00m
                };
            }
        }

        public class ParkingCostService
        {
            private IHourlyParkingRateStrategi _hourlyParkingRateStrategi;
            public ParkingCostService(IHourlyParkingRateStrategi hourlyParkingRateStrategi)
            {
                _hourlyParkingRateStrategi = hourlyParkingRateStrategi;
            }

            public void SetHourlyRateStrategy(IHourlyParkingRateStrategi strategy)
            {
                _hourlyParkingRateStrategi = strategy;
            }

            public void CalcHourlyParkingRate(Ticket ticket)
            {
                decimal parkingCost = _hourlyParkingRateStrategi.CalculateHourlyParkingRate(ticket);
                Console.WriteLine($"You parking cost is {parkingCost}");
            }
        }

        public class ParkingLot
        {
            //public static void Main(string[] args)
            //{
            //    Ticket ticket = new Ticket(VehicleType.Car);
            //    ParkingCostService service = new ParkingCostService(new FlatRate());
            //    service.CalcHourlyParkingRate(ticket);
            //    service.SetHourlyRateStrategy(new VehicleBaseRate());
            //    Ticket ticket1 = new Ticket(VehicleType.Car);
            //    service.CalcHourlyParkingRate(ticket1);
            //}
        }
    }
}
