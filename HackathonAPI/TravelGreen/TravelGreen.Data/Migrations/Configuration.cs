namespace TravelGreen.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TravelGreen.Data.Enums;

    internal sealed class Configuration : DbMigrationsConfiguration<TravelGreen.Data.TravelGreenDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TravelGreen.Data.TravelGreenDbContext context)
        {
            //  This method will be called after migrating to the latest version.
            SeedTransportTypes(context);
            SeedTransportFootprintValues(context);

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }

        private void SeedTransportTypes(TravelGreenDbContext context)
        {
            context.TransportTypes.AddOrUpdate(new Models.TransportType() { Name = TransportEnum.OnFoot.ToString() });
            context.TransportTypes.AddOrUpdate(new Models.TransportType() { Name = TransportEnum.Bicycle.ToString() });
            context.TransportTypes.AddOrUpdate(new Models.TransportType() { Name = TransportEnum.Car.ToString() });
            context.TransportTypes.AddOrUpdate(new Models.TransportType() { Name = TransportEnum.ElectricCar.ToString() });
            context.TransportTypes.AddOrUpdate(new Models.TransportType() { Name = TransportEnum.Motorcycle.ToString() });
            context.TransportTypes.AddOrUpdate(new Models.TransportType() { Name = TransportEnum.Scooter.ToString() });
            context.TransportTypes.AddOrUpdate(new Models.TransportType() { Name = TransportEnum.ElectricScooter.ToString() });
            context.TransportTypes.AddOrUpdate(new Models.TransportType() { Name = TransportEnum.Bus.ToString() });
            context.TransportTypes.AddOrUpdate(new Models.TransportType() { Name = TransportEnum.Rail.ToString() });
            context.TransportTypes.AddOrUpdate(new Models.TransportType() { Name = TransportEnum.Tram.ToString() });
            context.TransportTypes.AddOrUpdate(new Models.TransportType() { Name = TransportEnum.Metro.ToString() });
            context.TransportTypes.AddOrUpdate(new Models.TransportType() { Name = TransportEnum.Taxi.ToString() });
            context.TransportTypes.AddOrUpdate(new Models.TransportType() { Name = TransportEnum.Airplane.ToString() });
        }

        private void SeedTransportFootprintValues(TravelGreenDbContext context)
        {
            context.TransportFootprintValues.AddOrUpdate(
                new Models.TransportFootprintValue()
                {
                    TransportType = context.TransportTypes.Where(x => x.Name == TransportEnum.OnFoot.ToString()).FirstOrDefault(),
                    FootprintPerKm = 0,
                    FootprintPerMin = 0
                }
            );

            context.TransportFootprintValues.AddOrUpdate(
                new Models.TransportFootprintValue()
                {
                    TransportType = context.TransportTypes.Where(x => x.Name == TransportEnum.Bicycle.ToString()).FirstOrDefault(),
                    FootprintPerKm = 0,
                    FootprintPerMin = 0
                }
            );

            context.TransportFootprintValues.AddOrUpdate(
                 new Models.TransportFootprintValue()
                 {
                     TransportType = context.TransportTypes.Where(x => x.Name == TransportEnum.Car.ToString()).FirstOrDefault(),
                     FootprintPerKm = 150,
                     FootprintPerMin = 225 //avg speed 80km/h
                 }
            );

            context.TransportFootprintValues.AddOrUpdate(
                 new Models.TransportFootprintValue()
                 {
                     TransportType = context.TransportTypes.Where(x => x.Name == TransportEnum.ElectricCar.ToString()).FirstOrDefault(),
                     FootprintPerKm = 50,
                     FootprintPerMin = 75 //avg speed 80km/h
                 }
            );

            context.TransportFootprintValues.AddOrUpdate(
                 new Models.TransportFootprintValue()
                 {
                     TransportType = context.TransportTypes.Where(x => x.Name == TransportEnum.Motorcycle.ToString()).FirstOrDefault(),
                     FootprintPerKm = 100,
                     FootprintPerMin = 180 //avg speed 100km/h
                 }
            );

            context.TransportFootprintValues.AddOrUpdate(
                 new Models.TransportFootprintValue()
                 {
                     TransportType = context.TransportTypes.Where(x => x.Name == TransportEnum.Scooter.ToString()).FirstOrDefault(),
                     FootprintPerKm = 0,
                     FootprintPerMin = 0
                 }
            );

            context.TransportFootprintValues.AddOrUpdate(
                 new Models.TransportFootprintValue()
                 {
                     TransportType = context.TransportTypes.Where(x => x.Name == TransportEnum.ElectricScooter.ToString()).FirstOrDefault(),
                     FootprintPerKm = 120,
                     FootprintPerMin = 25
                 }
            );

            context.TransportFootprintValues.AddOrUpdate(
                 new Models.TransportFootprintValue()
                 {
                     TransportType = context.TransportTypes.Where(x => x.Name == TransportEnum.Bus.ToString()).FirstOrDefault(),
                     FootprintPerKm = 105,
                     FootprintPerMin = 157 //avg speed 80km/h
                 }
            );

            context.TransportFootprintValues.AddOrUpdate(
                 new Models.TransportFootprintValue()
                 {
                     TransportType = context.TransportTypes.Where(x => x.Name == TransportEnum.Rail.ToString()).FirstOrDefault(),
                     FootprintPerKm = 50,
                     FootprintPerMin = 75 //avg speed 80km/h
                 }
            );

            context.TransportFootprintValues.AddOrUpdate(
                 new Models.TransportFootprintValue()
                 {
                     TransportType = context.TransportTypes.Where(x => x.Name == TransportEnum.Tram.ToString()).FirstOrDefault(),
                     FootprintPerKm = 50,
                     FootprintPerMin = 75 //avg speed 80km/h                 
                 }
            );

            context.TransportFootprintValues.AddOrUpdate(
                 new Models.TransportFootprintValue()
                 {
                     TransportType = context.TransportTypes.Where(x => x.Name == TransportEnum.Metro.ToString()).FirstOrDefault(),
                     FootprintPerKm = 50,
                     FootprintPerMin = 75 //avg speed 80km/h
                 }
            );

            context.TransportFootprintValues.AddOrUpdate(
                 new Models.TransportFootprintValue()
                 {
                     TransportType = context.TransportTypes.Where(x => x.Name == TransportEnum.Taxi.ToString()).FirstOrDefault(),
                     FootprintPerKm = 150,
                     FootprintPerMin = 225 //avg speed 80km/h
                 }
            );

            context.TransportFootprintValues.AddOrUpdate(
                 new Models.TransportFootprintValue()
                 {
                     TransportType = context.TransportTypes.Where(x => x.Name == TransportEnum.Airplane.ToString()).FirstOrDefault(),
                     FootprintPerKm = 200,
                     FootprintPerMin = 3000 //900km/h - 15km/min
                 }
            );
        }
    }
}