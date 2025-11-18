
namespace TravelBookingSystem_MI_hw_7.Models
{
    public class TravelPackage
    {
        public int packageId { get; set; }
        public string packageName { get; set; }
        public string destination { get; set; }
        public int duration { get; set; }
        public decimal price { get; set; }
        public int availableSeats { get; set; }
        public DateTime departureDate { get; set; }
    }
}
