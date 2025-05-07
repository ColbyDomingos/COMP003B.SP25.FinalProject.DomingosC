using System.ComponentModel.DataAnnotations;

namespace COMP003B.SP25.FinalProject.DomingosC.Models
{
    public class Mechanic
    {
        public int Id { get; set; } //sets an id for the mechanic 

        [Required]
        public string FirstName { get; set; } = string.Empty;//gives the mechanic a first name

        [Required]
        public string LastName { get; set; } = string.Empty;//gives the mechanic a last name

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;//gives the email of the mechanic 

        [Required, Phone]
        public string Phone { get; set; } = string.Empty;//gives the phone number for the mechanic

        [Required]
        public string Speciality { get; set; } = string.Empty;//gives the mechanic a speciality (Added on second migration for a migration add)

        public ICollection<BookingMechanic> BookingMechanics { get; set; } = new List<BookingMechanic>();//connects with the booking system.
    }
}
