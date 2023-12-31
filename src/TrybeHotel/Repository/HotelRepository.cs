using TrybeHotel.Models;
using TrybeHotel.Dto;

namespace TrybeHotel.Repository
{
    public class HotelRepository : IHotelRepository
    {
        protected readonly ITrybeHotelContext _context;
        public HotelRepository(ITrybeHotelContext context)
        {
            _context = context;
        }

        public IEnumerable<HotelDto> GetHotels()
        {
            var hotelsDto = _context.Hotels
                .Select(hotel => new HotelDto 
                {
                    hotelId = hotel.HotelId,
                    name = hotel.Name,
                    address = hotel.Address,
                    cityId = hotel.CityId,
                    cityName = hotel.City.Name,
                });

            return hotelsDto;
        }
        
        public HotelDto AddHotel(Hotel hotel)
        {
            var city = _context.Cities.FirstOrDefault(c => c.CityId == hotel.CityId) ?? throw new ArgumentException("City not found");
            
            var hotelAdd = new Hotel
            {
                Name = hotel.Name,
                Address = hotel.Address,
                CityId = city.CityId
            };

            _context.Hotels.Add(hotelAdd);
            _context.SaveChanges();

            return new HotelDto
            {
                hotelId = hotelAdd.HotelId,
                name = hotelAdd.Name,
                address = hotelAdd.Address,
                cityId = city.CityId,
                cityName = city.Name
            };

        }
    }
}