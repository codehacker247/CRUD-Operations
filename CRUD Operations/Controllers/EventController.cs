using Microsoft.AspNetCore.Mvc;
using CRUD_Operations.Data;
using CRUD_Operations.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Operations.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class EventController : Controller
    {
        private readonly ContactsApiDbContext dbContext;
        public EventController(ContactsApiDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task< IActionResult> GetEvents()
        {
            return Ok(await dbContext.Events.ToListAsync());
        }

        [HttpPost]  
        public async Task <IActionResult> AddEvent(AddEventRequest addEventRequest)
        {
            var Event = new Event()
            {
                eventId = Guid.NewGuid(),
                eventName = addEventRequest.eventName,
                createdBy = addEventRequest.createdBy,
                date = addEventRequest.date,
            };

            await dbContext.Events.AddAsync(Event); 
            await dbContext.SaveChangesAsync();
            return Ok(Event);
        }
    }
}
