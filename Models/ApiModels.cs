using System;
using System.Collections.Generic;

namespace ReforaTec.Models
{
    public class ApiTree
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public DateTime PlantingDate { get; set; }
        public int ValueId { get; set; }
        public int SpeciesId { get; set; }
        public double? Height { get; set; }
        public double? Diameter { get; set; }
        public ApiLocation Location { get; set; }
        public string Notes { get; set; }
    }

    public class ApiLocation
    {
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string Street { get; set; }
        public string Neighborhood { get; set; }
        public string StreetNumber { get; set; }
    }

    public class ApiSpecies
    {
        public int Id { get; set; }
        public string ScientificName { get; set; }
        public List<string> CommonNames { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }

    public class ApiValue
    {
        public int Id { get; set; }
        public string ValueName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}