using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PROG3176_Assignment2.Entities;
using PROG3176_Assignment2.Repositories;

namespace PROG3176_Assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly AnimalRepository _repository;
        public AnimalController(AnimalRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _repository.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _repository.GetById(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add(Animal animal)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _repository.Add(animal);
            return Created();
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var animal = _repository.GetById(id);
            if (animal == null)
                return NotFound();
            _repository.Remove(animal);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Animal animal)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingAnimal = _repository.GetById(id);
            if (existingAnimal == null)
                return NotFound();

            animal.Id = id;
            var result = _repository.Update(animal);
            return Ok(result);
        }
    }
}