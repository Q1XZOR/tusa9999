namespace Party.WebApi.Model
{
    public class ApiGuestDto
    {
        public ApiGuestDto(int id, string firstname, string lastname, string email, string phone, string passport )
        {
            Id = id;
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            Phone = phone;
            Passport = passport;

        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Passport { get; set; }
    }
}
