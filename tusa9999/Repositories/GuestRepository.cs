using Microsoft.EntityFrameworkCore;
using Party.WebApi.Infrastruture.Data;
using Party.WebApi.Model;
using System.Linq;

namespace Party.WebApi.Repositories
{
        public class GuestRepository : IGuestRepository
        {
            private readonly GuestDbContext _db;
            public GuestRepository(GuestDbContext context)
            {
                _db=context;
            }
            public Guest Add(Guest guest)
            {
                Random random = new Random();
                guest.Id = random.Next(0, 100);
                _db.Add(guest);
                _db.SaveChanges();
                return guest;
            }
            public bool Delete(int id)

            {
                var guestName = _db.Guests.FirstOrDefault(x => x.Id == id);
                if (guestName == null) return false;
                _db.Remove(guestName);
                _db.SaveChanges();
                return true;
            
            }
            public Guest? Update(ApiGuestDto guest, int id)
            {
                var changedEntity = _db.Guests.FirstOrDefault(x => x.Id == id);
                if (changedEntity == null)
                {
                    return null;
                }
                changedEntity.Id = guest.Id;
                changedEntity.FirstName = guest.FirstName;
                changedEntity.LastName = guest.LastName;
                changedEntity.Email = guest.Email;
                changedEntity.Phone = guest.Phone;
                changedEntity.Passport = guest.Passport;
                changedEntity.Status = guest.Status;
                _db.SaveChanges();
                return changedEntity;
            }
            public Guest[] GetAll() => _db.Guests.AsNoTracking().ToArray();

            public Guest? GetById(int id) => _db.Guests.AsNoTracking().FirstOrDefault(x => x.Id == id);

            public Guest? GetFirstName(string firstname) => _db.Guests.AsNoTracking().FirstOrDefault(x => x.FirstName == firstname);
            public Guest? GetLastName(string lastname) => _db.Guests.AsNoTracking().FirstOrDefault(x => x.LastName == lastname);
            public Guest? GetEmail(string email) => _db.Guests.AsNoTracking().FirstOrDefault(x => x.Email == email);
            public Guest? GetPhone(string phone) => _db.Guests.AsNoTracking().FirstOrDefault(x => x.Phone == phone);
            public Guest? GetPassport(string passport) => _db.Guests.AsNoTracking().FirstOrDefault(x => x.Passport == passport);
            public IEnumerable<Guest> GetGuestsByStatus(string status)
            {
                return _db.Guests
                    .AsNoTracking()
                    .Where(x => x.Status == status)
                    .ToList();
            }
        }
    }
