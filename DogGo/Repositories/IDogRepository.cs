using System.Collections.Generic;
using DogGo.Models;
namespace DogGo.Repositories
{
    public interface IDogRepository
    {
        List<Dog> GetAllDogs();
        Dog GetById(int id);
        void AddDog(Dog dog);
        void UpdateDog(Dog dog);
        void DeleteDog(int id);
        List<Dog> GetDogsByOwnerId(int ownerId);

    }
}
