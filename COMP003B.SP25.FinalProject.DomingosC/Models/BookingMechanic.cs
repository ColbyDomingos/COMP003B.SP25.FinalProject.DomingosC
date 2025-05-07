using System.ComponentModel.DataAnnotations;

namespace COMP003B.SP25.FinalProject.DomingosC.Models
{
    public class BookingMechanic
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int BookingId { get; set; } //Gets an id from the booking model
        public Booking Booking { get; set; } //connects to the booking model

        public int MechanicId { get; set; } // gets the mechanic id from the mechanic model
        public Mechanic Mechanic { get; set; } //connects to the mechanic model
    }
}
