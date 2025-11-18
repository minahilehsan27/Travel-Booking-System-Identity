using Microsoft.AspNetCore.Mvc;
using TravelBookingSystem_MI_hw_7.Models;
using TravelBookingSystem_MI_hw_7.Models.Interface;
namespace TravelBookingSystem_MI_hw_7.Controllers
{
    public class TravelController : Controller
    {
        private ITravelService _travelPackage;
        public TravelController(ITravelService package)
        {
            _travelPackage = package;
        }
        public IActionResult Index()
        {
            List<TravelPackage> packages = _travelPackage.GetAllPackages();
            return View(packages);
        }
        [HttpGet]
        public IActionResult Details(int Id)
        {
            TravelPackage package = _travelPackage.GetPackageById(Id);
            ViewBag.Package = package;
            return View();
        }
        [HttpGet]
        public IActionResult Book(int id)
        {
            TravelPackage package = _travelPackage.GetPackageById(id);
            return View(package);
        }
        [HttpPost]
        public IActionResult Book(Booking booking)
        {
            TravelPackage package = _travelPackage.GetPackageById(booking.packageId);
            if (package == null)
            {
                TempData["BookingError"] = "The booking could not be confirmed. Package with this ID doesn't exist.";
                return RedirectToAction("Index");
            }
            booking.TotalAmount = booking.NumberOfTravelers * package.price;
            bool val = _travelPackage.CreateBooking(booking);
            if (val == false)
            {
                TempData["BookingError"] = "The booking could not be confirmed.Number of Travellers are more than available seats.";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Success");
        }
        [HttpGet]
        public IActionResult Success(Booking booking)
        {
            ViewBag.Msg = "Booking confirmed successfully.";
            return View();
        }
    }
}
