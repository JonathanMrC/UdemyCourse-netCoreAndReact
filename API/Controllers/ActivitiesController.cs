using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using Domain;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        private readonly DataContext _context;
        public ActivitiesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet] //api/activities
        public async Task<ActionResult<List<Activity>>> GetActivities(){
            return await _context.Activities.ToListAsync();
        }

        [HttpGet("{id}")] //api/activities/something
        public async Task<ActionResult<Activity>> GetActivity(Guid id){
            var activity = await _context.Activities.FindAsync(id);
            if(activity is null) return NotFound();
            return activity;
        }
    }
}