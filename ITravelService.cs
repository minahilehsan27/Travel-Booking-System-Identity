
using Microsoft.Data.SqlClient;
using TravelBookingSystem_MI_hw_7.Models.Interface;
namespace TravelBookingSystem_MI_hw_7.Models.Repositories
{

    namespace TravelBookingSystemhw.Models.Repositories
    {
        public class TravelService : ITravelService
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog = TravelBooking;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            public void AddPackage(TravelPackage package)
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string query = "Insert into TravelPackage(PackageName,Destination,Duration,Price,AvailableSeats,DepartureDate) values(@pkgName,@dest,@duration,@price,@seats,@date)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("pkgName", package.packageName);
                command.Parameters.AddWithValue("dest", package.destination);
                command.Parameters.AddWithValue("duration", package.duration);
                command.Parameters.AddWithValue("price", package.price);
                command.Parameters.AddWithValue("seats", package.availableSeats);
                command.Parameters.AddWithValue("date", package.departureDate);
                command.ExecuteNonQuery();
                connection.Close();
            }

            public List<TravelPackage> GetAllPackages()
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string query = "Select * from TravelPackage";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                List<TravelPackage> packages = new List<TravelPackage>();
                while (reader.Read())
                {
                    TravelPackage package = new TravelPackage();
                    package.packageId = (int)reader["PackageId"];
                    package.packageName = (string)reader["PackageName"];
                    package.destination = (string)reader["Destination"];
                    package.duration = (int)reader["Duration"];
                    package.price = (decimal)reader["Price"];
                    package.availableSeats = (int)reader["AvailableSeats"];
                    package.departureDate = (DateTime)reader["DepartureDate"];
                    packages.Add(package);
                }
                connection.Close();
                return packages;

            }
            public TravelPackage GetPackageById(int id)
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string query = "Select * from TravelPackage where PackageId = @pkgId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("pkgId", id);
                SqlDataReader reader = command.ExecuteReader();
                TravelPackage travelPackage = new TravelPackage();
                if (reader.Read())
                {
                    travelPackage.packageId = (int)reader["PackageId"];
                    travelPackage.packageName = (string)reader["PackageName"];
                    travelPackage.destination = (string)reader["Destination"];
                    travelPackage.duration = (int)reader["Duration"];
                    travelPackage.price = (decimal)reader["Price"];
                    travelPackage.availableSeats = (int)reader["AvailableSeats"];
                    travelPackage.departureDate = (DateTime)reader["DepartureDate"];
                }
                connection.Close();
                return travelPackage;
            }
            public bool CreateBooking(Booking booking)
            {
                TravelPackage travelPackage = GetPackageById(booking.packageId);
                if (travelPackage != null && booking.NumberOfTravelers <= travelPackage.availableSeats)
                {

                    SqlConnection connection = new SqlConnection(connectionString);
                    connection.Open();
                    string query = "Insert into Booking(PackageId,CustomerName,CustomerEmail,NumberOfTravelers,TotalAmount) values(@pkgId,@cstName,@cstEmail,@noOfTravellers,@tAmount)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("pkgId", booking.packageId);
                    command.Parameters.AddWithValue("cstName", booking.customerName);
                    command.Parameters.AddWithValue("cstEmail", booking.customerEmail);
                    command.Parameters.AddWithValue("noOfTravellers", booking.NumberOfTravelers);
                    command.Parameters.AddWithValue("tAmount", booking.TotalAmount);
                    command.ExecuteNonQuery();
                    connection.Close();
                    return true;
                }
                return false;
            }
        }
    }

}
