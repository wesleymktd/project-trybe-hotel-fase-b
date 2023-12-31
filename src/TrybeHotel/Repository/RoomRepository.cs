using TrybeHotel.Models;
using TrybeHotel.Dto;

namespace TrybeHotel.Repository
{
    public class RoomRepository : IRoomRepository
    {
        protected readonly ITrybeHotelContext _context;
        public RoomRepository(ITrybeHotelContext context)
        {
            _context = context;
        }

        public IEnumerable<RoomDto> GetRooms(int HotelId)
        {
            var roomsResult = (
                from room in _context.Rooms
                where room.HotelId == HotelId
                select new RoomDto 
                {
                    roomId = room.RoomId,
                    name = room.Name,
                    capacity = room.Capacity,
                    image = room.Image,
                    hotel = new HotelDto
                    {
                        hotelId = room.Hotel.HotelId,
                        name = room.Hotel.Name,
                        address = room.Hotel.Address,
                        cityId = room.Hotel.CityId,
                        cityName = room.Hotel.City.Name,
                        
                    }
                }
            );

            return roomsResult;
        }

        public RoomDto AddRoom(Room room) {
            _context.Rooms.Add(room);
            _context.SaveChanges();

            var roomCtx = (
                from r in _context.Rooms
                join h in _context.Hotels
                on r.HotelId equals h.HotelId
                join c in _context.Cities
                on h.CityId equals c.CityId
                where r.RoomId == room.RoomId
                select new RoomDto
                {
                    roomId = r.RoomId,
                    name = r.Name,
                    capacity = r.Capacity,
                    image = r.Image,
                    hotel = new HotelDto
                    {
                        hotelId = h.HotelId,
                        name = h.Name,
                        address = h.Address,
                        cityId = c.CityId,
                        cityName = c.Name,
                    }
                }
            ).First();

            return roomCtx;
        }

        public void DeleteRoom(int RoomId) {
            var toRemove = _context.Rooms.Where(r => r.RoomId == RoomId).First();
            _context.Rooms.Remove(toRemove);
            _context.SaveChanges();
        }
    }
}