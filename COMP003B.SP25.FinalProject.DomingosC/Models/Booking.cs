namespace COMP003B.SP25.FinalProject.DomingosC.Models
{
    public class Booking
    {
        public int Id { get; set; } //gives an id for the booking
        public DateTime Date { get; set; } //date that the car was inducted into the shop
        public TimeSpan Time { get; set; } //time left for fixes or work
        public string Status { get; set; } //how the status of the car is, finished, working etc

        public int VehicleId { get; set; } //gives the vehicle an Id for the booking
        public Vehicle Vehicle { get; set; } // Take s the vehicle from the vehicles model

        public int ServiceTypeId { get; set; } //gives an ID to the service type to give more separation between vehicles
        public ServiceType ServiceType { get; set; } //takes service type from service type, duh

        public ICollection<BookingMechanic> BookingMechanics { get; set; } //Connects with the booking mechanic code structure
    }
}
