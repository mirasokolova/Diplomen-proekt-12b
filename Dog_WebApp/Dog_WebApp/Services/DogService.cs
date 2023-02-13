using Dog_WebApp.Abstactions;
using Dog_WebApp.Data;
using Dog_WebApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dog_WebApp.Services
{
    public class DogService : IDogService
    {

        private readonly ApplicationDbContext _context;
           public DogService(ApplicationDbContext context)
           {
            _context = context;

           }
            

           
           public bool Create(string name, int age, string breed, string image)
           {
             Dog item = new Dog
             {
                Name = name,
                Age = age,
                Breed = breed,
                Image = image,
             };

                _context.Dogs.Add(item);
                return _context.SaveChanges() != 0;
            
           }
         public List<Dog> GetDogs()
            {
            List<Dog> dogs = _context.Dogs.ToList();
            return dogs;
        }

            public Dog GetDogById(int dogId)
            {
                return _context.Dogs.Find(dogId);
            }

        
        public List<Dog> GetDogs(string searchStringBreed, string searchStringName)
        {
            List<Dog> dogs = _context.Dogs.ToList();
            if (!String.IsNullOrEmpty(searchStringBreed) && !String.IsNullOrEmpty(searchStringName))
            {
                dogs = dogs.Where(x => x.Breed.Contains(searchStringBreed) && x.Name.Contains(searchStringName)).ToList();

            }
            else if (!String.IsNullOrEmpty(searchStringBreed))
            {
                dogs = dogs.Where(x => x.Breed.Contains(searchStringBreed)).ToList();
            }
            else if (!String.IsNullOrEmpty(searchStringName))
            {
                dogs = dogs.Where(x => x.Name.Contains(searchStringName)).ToList();
            }
            return dogs;
        }
               
        public bool RemoveById(int dogId)
        {
            var dog = GetDogById(dogId);
            if (dog == default(Dog))
            {
                return false;
            }
            _context.Dogs.Remove(dog);
            return _context.SaveChanges() != 0;
        }
               
        public bool UpdateDog(int dogId, string name, int age, string breed, string image)
        {
            var dog = GetDogById(dogId);
            if (dog == default(Dog))
            {
                return false;
            }
            dog.Name = name;
            dog.Age = age;
            dog.Breed = breed;
            dog.Image = image;

            _context.Dogs.Update(dog);
            return _context.SaveChanges() != 0;
        }
    }
}
