using Microsoft.AspNetCore.Mvc;
using Party.WebApi.Model;
using Party.WebApi.Interfaces;

namespace Party.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly IGuestRepository _guestRep;
        
        public GuestController(IGuestRepository guestRep)
        {
            _guestRep = guestRep;
        }

        [HttpGet]
        public ActionResult<Guest[]> GetAll()
        {
            return Ok(_guestRep.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Guest> GetById(int id)
        {
            var guestById = _guestRep.GetById(id);
            if (guestById == null)
                return NotFound("We can't find this guest");
            return Ok(guestById);
        }

        
        [HttpPost]
        public ActionResult<Guest> Add(ApiGuestDto guest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingGuest = _guestRep.GetById(guest.Id);
            if (existingGuest != null)
            {
                return Conflict("Guest with this ID already exists.");
            }

            var newGuest = new Guest
            {
                Id = guest.Id,
                FirstName = guest.FirstName,
                LastName = guest.LastName,
                Email = guest.Email,
                Phone = guest.Phone,
                Passport = guest.Passport
            };

            var addedGuest = _guestRep.Add(newGuest);
            return Ok(addedGuest);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var guesToDelete = _guestRep.Delete(id);
            if (guesToDelete == false)
            {
                return NotFound("Sorry, we can't find this guest");
            }
            return Ok("Guest are successfully deleted!");
        }

        [HttpPut("{id}")]
        public ActionResult<Guest> Update(ApiGuestDto guest, int id)
        {
            var gues = _guestRep.Update(guest, id);
            if (gues == null)
            {
                return NotFound("Sorry, we can't find this guest :(");
            }
            return Ok(gues);
        }
    }
}

