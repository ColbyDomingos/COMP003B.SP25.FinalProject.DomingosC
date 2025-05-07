using System.ComponentModel.DataAnnotations;

namespace COMP003B.SP25.FinalProject.DomingosC.Models
{
    public class Customer
    {
        public int Id { get; set; } //sets the id fot the customer

        [Required]
        public string FirstName { get; set; } = string.Empty;// requires a first name for the customer

        [Required]
        public string LastName { get; set; } = string.Empty;// requires a last name for the customer


        [Required, EmailAddress] // requires the email adress
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty; //connects a phone number with the customer

        public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();//one to one connection with a vehicle 
    }
}

