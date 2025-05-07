using c4.Models;

namespace c4;

public static class Database
{
    public static List<Visit> Visits = new List<Visit>
    {
        new Visit { Id = 1, AnimalId = 1, Date = DateTime.Now.AddDays(-10), Description = "Vaccination", Price = 100 },
        new Visit { Id = 2, AnimalId = 2, Date = DateTime.Now.AddDays(-5), Description = "Check-up", Price = 50 }
    };
    public static List<Animal> Animals = new List<Animal>
    {
        new Animal { Id = 1, Name = "Rex", Category = "Dog", Weight = 20.5f, FurColor = "Brown" },
        new Animal { Id = 2, Name = "Milo", Category = "Cat", Weight = 5.2f, FurColor = "Black" }
    };
}