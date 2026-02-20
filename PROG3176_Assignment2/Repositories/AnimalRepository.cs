using PROG3176_Assignment2.Data;
using PROG3176_Assignment2.Entities;

namespace PROG3176_Assignment2.Repositories
{
    public class AnimalRepository
    {
        private readonly AppDbContext _context;
        public AnimalRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Animal> GetAll()
        {
            return _context.Animals.ToList();
        }

        public Animal? GetById(int id)
        {
            return _context.Animals.Find(id);
        }

        public void Add(Animal animal)
        {
            _context.Animals.Add(animal);
            _context.SaveChanges();
        }

        public void Remove(Animal animal)
        {
            _context.Animals.Remove(animal);
            _context.SaveChanges();
        }

        public Animal Update(Animal animal)
        {
            var existingAnimal = _context.Animals.Find(animal.Id);
            if (existingAnimal == null)
                throw new Exception("Animal not found");

            existingAnimal.Name = animal.Name;
            existingAnimal.Species = animal.Species;
            existingAnimal.Age = animal.Age;
            existingAnimal.IsPet = animal.IsPet;

            var result = _context.Animals.Update(existingAnimal).Entity;
            _context.SaveChanges();
            return result;
        }
    }
}