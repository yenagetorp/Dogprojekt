using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogProject.Models
{
    public class DogsService
    {
        static List<Dog> dogs = new List<Dog>
        {
            new Dog {Id=43, Name="Douglas", Age=7},
            new Dog {Id=53, Name="Chap", Age=10},
            new Dog {Id=62, Name="Bella", Age=5}

        };

        public void Add(Dog dog)
        {
            int newId;
            if (dogs.Count==0)
            {
                newId = 1;
            }
            else
            {
            newId = dogs.Max(d => d.Id)+1;
            }
            dog.Id = newId;
            dogs.Add(dog);
        }

        public Dog[] GetAllDogs()
        {
            return dogs.ToArray();
        }

        public Dog GetDogById(int id)
        {
            return dogs.SingleOrDefault(d => d.Id==id);
        }

        public void UpdateDog(Dog dog)
        {
           var oldDog= dogs.SingleOrDefault(d => d.Id == dog.Id);
            if (oldDog!=null)
            {
                oldDog.Name = dog.Name;
                oldDog.Age = dog.Age;
            }
        }

        public void DeleteDog(int id)
        {
            dogs.RemoveAll(d => d.Id == id);
        }

    }
}
