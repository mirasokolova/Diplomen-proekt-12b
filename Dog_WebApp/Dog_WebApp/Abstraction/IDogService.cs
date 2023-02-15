using Dog_WebApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dog_WebApp.Abstraction
{
    public interface IDogService
    {
        bool Create(string name, int age, string breed, string image);
        bool UpdateDog(int dogId, string name, int age, string breed, string image);
        List<Dog> GetDogs();
        Dog GetDogById(int dogId);
        bool RemoveById(int DogId);
        List<Dog> GetDogs(string searchStringBreed, string searchStringName);
        // object UpdateDog(string name, int age, string breed, string image);
    }
}
