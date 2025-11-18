namespace TravelBookingSystem_MI_hw_7.Models
{
    public class Booking
    {
        public int bookingId { get; set; }
        public int packageId { get; set; }
        public string customerName { get; set; }
        public string customerEmail { get; set; }
        public int NumberOfTravelers { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime BookingDate { get; set; }
    }
}
