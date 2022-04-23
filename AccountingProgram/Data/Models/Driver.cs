namespace AccountingProgram.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.Driver;

    public class Driver
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(DriverNameMaxLength)]
        public string Name { get; set; }

        public int RouteId { get; set; }
        public Route Route { get; set; }
    }
}
