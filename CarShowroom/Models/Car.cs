using System;

namespace CarShowroom.Models
{
    public sealed record Car
    {
        public Car()
        {
            Id = Guid.NewGuid().ToString();
        }
        
        public string Id { get; init; }
        public string Manufacturer { get; init; }
        public string Model { get; init; }
        public string EngineType { get; init; }
        public string EnginePower { get; init; }
        public int AmountOfCylinders { get; init; }
        public string Color { get; init; }
        public DateTime DateOfCreation { get; init; }
        public int AmountLeft { get; init; }
        public string ImageUrl { get; init; }
    }
}