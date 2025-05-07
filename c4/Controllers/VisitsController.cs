using c4.Models;
using Microsoft.AspNetCore.Mvc;

namespace c4.Controllers;

[ApiController]
    [Route("api/")]
    public class VisitsController : ControllerBase
    {
        [HttpGet("visit")]
        public ActionResult<IEnumerable<Visit>> GetVisitsForAnimal()
        {
            return Ok(Database.Visits);
        }

        [HttpGet("visit/withanimal/{id}")]
        public ActionResult<IEnumerable<Visit>> GetVisitsForAnimal(int id)
        {
            var visits = Database.Visits.Where(v => v.AnimalId == id).ToList();
            return Ok(visits);
        }

        [HttpPost("visit/withanimal/{id}")]
        public ActionResult<Visit> AddVisit(int id, Visit visit)
        {
            var animal = Database.Animals.FirstOrDefault(a => a.Id == id);
            if (animal == null) return NotFound("Animal not found");

            visit.Id = Database.Visits.Any() ? Database.Visits.Max(v => v.Id) + 1 : 1;
            visit.AnimalId = id;
            Database.Visits.Add(visit);

            return CreatedAtAction(nameof(GetVisitsForAnimal), new { id = id }, visit);
        }
    }