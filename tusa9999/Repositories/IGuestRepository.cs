using Party.WebApi.Model;

namespace Party.WebApi.Repositories
{
    public interface IGuestRepository
    {
       Guest[] GetAll();
        Guest Add(Guest guest);
        Guest? Update(ApiGuestDto guest, int id);
        bool Delete(int id);
        Guest? GetById(int id);
        Guest? GetFirstName(string firstname);
        Guest? GetLastName(string lastname);
        Guest? GetEmail(string email);
        public Guest? GetPhone(string phone);
        public Guest? GetPassport(string passport);

        IEnumerable<Guest> GetGuestsByStatus(ApiStatus status);

    }
}
