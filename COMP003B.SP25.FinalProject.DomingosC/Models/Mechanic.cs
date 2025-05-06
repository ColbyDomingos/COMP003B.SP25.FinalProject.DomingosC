namespace COMP003B.SP25.FinalProject.DomingosC.Models
{
    public class Mechanic
    {
        public int Id { get; set; } //sets an id for the mechanic 
        public string FirstName { get; set; } //gives the mechanic a first name
        public string LastName { get; set; } //gives the mechanic a last name
        public string Email { get; set; } //gives the email of the mechanic 
        public string Phone { get; set; }//gives the phone number for the mechanic

        public ICollection<BookingMechanic> BookingMechanics { get; set; } //connects with the booking system.
    }
}
