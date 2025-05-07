using c4.Models;
using Microsoft.AspNetCore.Mvc;

namespace c4.Controllers;

[ApiController]
    [Route("api/")]
    public class AnimalsController : ControllerBase
    {
        [HttpGet("animal")]
        public ActionResult<IEnumerable<Animal>> GetAnimals()
        {
            return Ok(Database.Animals);
        }

        [HttpGet("animal/{id}")]
        public ActionResult<Animal> GetAnimal(int id)
        {
            var animal = Database.Animals.FirstOrDefault(a => a.Id == id);
            if (animal == null) return NotFound();
            return Ok(animal);
        }

        [HttpPost("animal")]
        public ActionResult<Animal> AddAnimal(Animal animal)
        {
            animal.Id = Database.Animals.Max(a => a.Id) + 1;
            Database.Animals.Add(animal);
            return CreatedAtAction(nameof(GetAnimal), new { id = animal.Id }, animal);
        }

        [HttpPut("animal/{id}")]
        public IActionResult UpdateAnimal(int id, Animal updatedAnimal)
        {
            var animal = Database.Animals.FirstOrDefault(a => a.Id == id);
            if (animal == null) return NotFound();

            animal.Name = updatedAnimal.Name;
            animal.Category = updatedAnimal.Category;
            animal.Weight = updatedAnimal.Weight;
            animal.FurColor = updatedAnimal.FurColor;

            return NoContent();
        }

        [HttpDelete("animal/{id}")]
        public IActionResult DeleteAnimal(int id)
        {
            var animal = Database.Animals.FirstOrDefault(a => a.Id == id);
            if (animal == null) return NotFound();
            Database.Animals.Remove(animal);
            return NoContent();
        }

        [HttpGet("animal/search/{name}")]
        public ActionResult<IEnumerable<Animal>> SearchAnimalsByName(string name)
        {
            var results = Database.Animals.Where(a => a.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
            return Ok(results);
        }
    }