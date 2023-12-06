﻿namespace GeneralMotors.API.DTOs.Cars
{
	public class UpdateCarDto
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        public string Color { get; set; }
        public string Fuel_Type { get; set; }
        public string Features { get; set; }
        public string Description { get; set; }
        public int CarTypeId { get; set; }
        public string CarImage { get; set; }
    }
}

