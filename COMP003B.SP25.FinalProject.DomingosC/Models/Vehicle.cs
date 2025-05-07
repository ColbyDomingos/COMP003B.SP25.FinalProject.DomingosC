using System.ComponentModel.DataAnnotations;

namespace COMP003B.SP25.FinalProject.DomingosC.Models
{
    public class Vehicle
    {
        public int Id { get; set; } // sets an Id for the car

        [Required]
        public string Make { get; set; } = string.Empty;//requires the make of the car

        [Required]
        public string Model { get; set; } = string.Empty;// requires a model for the car

        [Range(1900, 2100)] // cant be lover than 1900 or higher than 2100 because cars really werent that detailed back then and there arent any cars made in 2100 yet so yea
        public int Year { get; set; } // the year the vehicle was made

        public string LicensePlate { get; set; } = string.Empty;// the liscense plate for the vehicle

        public int CustomerId { get; set; } //Gets a customer Id to set for this vehicle
        public Customer? Customer { get; set; } //connects with the customer 1 : 1 relationship
    }
}
