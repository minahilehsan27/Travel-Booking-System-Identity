namespace TravelBookingSystem_MI_hw_7.Models.Interface
{ 
    public interface ITravelService
    {
        public void AddPackage(TravelPackage pacakge);
        public List<TravelPackage> GetAllPackages();
        public TravelPackage GetPackageById(int id);
        public bool CreateBooking(Booking booking);
    }

}
