using System.ComponentModel.DataAnnotations;

namespace COMP003B.SP25.FinalProject.DomingosC.Models
{
    public class ServiceType
    {
        public int Id { get; set; } //gives the service type an ID

        [Required] //requires these fields
        public string Name { get; set; } //the name of the servicetype
        public string Description { get; set; }//description of what needs to be done
        public double EstimatedTime { get; set; } //gives an estmated time for finish
        public decimal Price { get; set; } //gives a price for the work
    }
}
