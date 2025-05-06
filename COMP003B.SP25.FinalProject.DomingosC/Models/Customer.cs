using System.ComponentModel.DataAnnotations;

namespace COMP003B.SP25.FinalProject.DomingosC.Models
{
    public class Customer
    {
        public int Id { get; set; } //sets the id fot the customer

        [Required]
        public string FirstName { get; set; } // requires a first name for the customer

        [Required]
        public string LastName { get; set; } // requires a last name for the customer

        
        [Required, EmailAddress] // requires the email adress
        public string Email { get; set; }
        public string PhoneNumber { get; set; } //connects a phone number with the customer

        public ICollection<Vehicle> Vehicles { get; set; } //one to one connection with a vehicle 
    }
}

