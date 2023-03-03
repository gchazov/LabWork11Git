using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalLibrary;

namespace LabWork11
{
    public class Requests
    {
        //возращает список подходящях (3 запроса в 1)
        public static List<Animal> GetTypeRequest(int choice, Queue<Animal> animals)
        {
            //для choice
            //1 - млекопитающие
            //2 - птицы
            //3 - парнокопытные
            Animal[] animals1 = { new Mammal(), new Bird(), new Artiodactyl() };
            Type typeName = null;
            switch (choice)
            {
                case 1:
                    typeName = animals1[0].GetType();
                    break;
                case 2:
                    typeName = animals1[1].GetType();
                    break;
                case 3:
                    typeName = animals1[2].GetType();
                    break;
            }
            //создание списка для подходящих объектов
            List<Animal> result = new List<Animal>();
            foreach(Animal animal in animals)
            {
                //создаём переменную для определения типа
                var animal1 = animal;
                if (animal1.GetType() == typeName)
                    result.Add(animal1);
            }
            return result;
        }

        //запрос на старейшее животное
        public static Animal OldestAnimal(Queue<Animal> animals)
        {
            int maxAge = 0;
            var animalOld = new Animal();
            foreach (Animal animal in animals)
            {
                if (animal.Age > maxAge)
                {
                    maxAge = animal.Age;
                    animalOld = animal;
                }
            }
            return animalOld;
        }
    }
}
