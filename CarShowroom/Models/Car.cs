using System;
using Microsoft.AspNetCore.Mvc;

namespace CarShowroom.Models
{
    public sealed record Car
    {
        [FromForm]
        public string Id { get; init; }
        [FromForm]
        public string Manufacturer { get; init; }
        [FromForm]
        public string Model { get; init; }
        [FromForm]
        public string EngineType { get; init; }
        [FromForm]
        public string EnginePower { get; init; }
        [FromForm]
        public int AmountOfCylinders { get; init; }
        [FromForm]
        public string Color { get; init; }
        [FromForm]
        public DateTime DateOfCreation { get; init; }
        [FromForm]
        public int AmountLeft { get; init; }
        [FromForm]
        public string ImageUrl { get; init; }
    }
}