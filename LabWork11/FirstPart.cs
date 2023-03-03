using AnimalLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork11
{
    public class FirstPart
    {
        /*константа - максимальная вместимость очереди;
         * удобство в том, что при её изменении не придётся
         * изменять значения в каждом методе программы
         */
        public const int MAX_CAPACITY = 1000;

        //печать основного меню первой части работа
        public static void FPMainPage() //здесь и далее: FP - сокращение First Part
        {
            Console.WriteLine("\n1. Сформировать очередь из случайных объектов\n" +
                "2. Вывести очередь на экран\n" +
                "3. Добавить случайные элементы в очередь\n" +
                "4. Извлечь и удалить первый элемент из очереди\n" +
                "5. запрос 1\n" +
                "6. запрос 2\n" +
                "7. запрос 3\n" +
                "8. Сортировать очередь и найти в ней элемент\n" +
                "9. Выполнить клонирование очереди\n\n" +
                "10. Вернуться в главное меню");

        }

        //цветовая индикация заполненности очереди
        public static void FPQueueCount(int count, string startMessage, string endMessage)
        {
            Console.Write(startMessage);
            switch (count)
            {
                case <= MAX_CAPACITY/2: //очередь заполнена на менее, чем 50 процентов
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case <= MAX_CAPACITY/4*3: //очередь заполнена на 51-75 процентов
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case <= MAX_CAPACITY: //очередь заполнена на 76-100 процентов
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
            }
            Console.Write($"{count}"+endMessage);
            Console.ResetColor();
        }

        //главное меню первой части работы
        public static void FPMenu(ref Queue<Animal> animalQueue)
        {
            bool isRunning = true;
            do
            {
                Dialog.PrintHeader("Первая часть работы");

                //максимальная ёмкость очереди - константа MAX_CAPACITY
                Console.WriteLine($"Максимальная вместительность очереди - {MAX_CAPACITY}");
                FPQueueCount(animalQueue.Count, "Очередь заполнена на ", $"/{MAX_CAPACITY}");
                Console.WriteLine();

                FPMainPage(); //печать основного меню первой части
                int choice = Dialog.EnterNumber("Выберите пункт меню:", 1, 10);

                Console.WriteLine();
                switch (choice)
                {
                    case 1:
                        MakeQueueRandom(ref animalQueue);
                        break;
                    case 2:
                        PrintQueue(animalQueue);
                        break;
                    case 3:
                        EnqueueElements(ref animalQueue);
                        break;
                    case 4:
                        DequeueElement(ref animalQueue);
                        break;
                    case 10: //выход в самое первое меню
                        isRunning = false;
                        break;

                }
            } while (isRunning);
            return;
        }

        //добавление n-ого количества элементов в конец очереди
        public static void AddRandomToQueue(ref Queue<Animal> animalQueue, int amount)
        {
            //amount - кол-во добавляемых элементов
            for (int i = 0; i < amount; i++)
            {
                //добавление в очередь случайных экзмепляров иерархии AnimalLibrary
                switch (Program.random.Next(1, 4))
                {
                    case 1:
                        Animal animal = new Animal();
                        animal.RandomInit();
                        animalQueue.Enqueue(animal);
                        break;
                    case 2:
                        Bird bird = new Bird();
                        bird.RandomInit();
                        animalQueue.Enqueue(bird);
                        break;
                    case 3:
                        Mammal mammal = new Mammal();
                        mammal.RandomInit();
                        animalQueue.Enqueue(mammal);
                        break;
                    case 4:
                        Artiodactyl artiodactyl = new Artiodactyl();
                        artiodactyl.RandomInit();
                        animalQueue.Enqueue(artiodactyl);
                        break;
                }
            }
        }

        //создание очереди из элементов коллекции с помощью ДСЧ
        public static void MakeQueueRandom(ref Queue<Animal> animals)
        {
            Dialog.PrintHeader("Создание очереди с помощью ДСЧ");
            int length = Dialog.EnterNumber($"Введите длину очереди (до {MAX_CAPACITY}):", 0, MAX_CAPACITY);
            Queue<Animal> animalQueue = new Queue<Animal>(length); //создание очереди заданной длины
            AddRandomToQueue(ref animalQueue, length);

            //обновляем инициализированную очередь
            animals = new Queue<Animal>(animalQueue);
            
            Console.WriteLine();
            switch (animals.Count)
            {
                case 0: //если очередь пуста
                    Dialog.ColorText("Пустая очередь создана", "green");
                    break;
                default: //если очередь содержит 1<=n<=20 объектов
                    Dialog.ColorText($"Очередь успешно создана, её длина - {animals.Count}", "green");
                    break;
            }

            Dialog.BackMessage();
            return;
        }

        //метод вывода очереди объектов на печать
        public static void PrintQueue(Queue<Animal> animals)
        {
            Dialog.PrintHeader("Вывод очереди на печать");
            if (animals.Count == 0) //случай, если очередь пуста
            {
                Console.WriteLine("Текущая очередь пуста");
                Dialog.BackMessage();
                return;
            }
            Console.WriteLine($"Очередь состоит из {animals.Count} следующего(-их) элемента(-ов):\n");
            if (animals.Count >= 40)
                Thread.Sleep(2000); //чтобы пользователь успел прочитать сообщение выше
            int elementNumber = 0;
            foreach(Animal animal in animals) //перебор объектов очереди
            {
                elementNumber++;
                FPQueueCount(elementNumber, $"Объект очереди № ", "");
                Console.Write(":\n");
                animal.Show();
            }
            Dialog.BackMessage();
            return;
        }

        //метод извлечения удаления объекта из очереди
        public static void DequeueElement(ref Queue<Animal> animals)
        {
            Dialog.PrintHeader("Извлечение и удаление элемента из очереди");
            switch (animals.Count)
            {
                case 0: //случай, когда очередь пуста
                    Dialog.ColorText("Нечего удалять в пустой очереди!","green");
                    Console.WriteLine("Заполните её элементами и попробуйте операцию извлечения заново");
                    break;
                default:
                    Animal excludedAnimal = animals.Dequeue();
                    Dialog.ColorText("Из очереди удалён первый добавленный из оставшихся элемент:\n", "green");
                    excludedAnimal.Show();
                    break;
            }
            Dialog.BackMessage();
            return;
            
        }

        //метод добавления объектов в очередь
        public static void EnqueueElements(ref Queue<Animal> animals)
        {
            Dialog.PrintHeader("Добавление случайных объектов в конец очереди");
            FPQueueCount(animals.Count, "Учтите, что очередь заполнена на ", $"/{MAX_CAPACITY}\n");
            int elementAmount = Dialog.EnterNumber("Введите количество добавляемых объектов:", 0, MAX_CAPACITY - animals.Count);
            switch (elementAmount)
            {
                case 0:
                    Dialog.ColorText("Очередь осталась прежней, элементов не прибавилось", "green");
                    break;
                default:
                    AddRandomToQueue(ref animals, elementAmount);
                    Dialog.ColorText($"Очередь пополнилась на {elementAmount} элемент(-ов)", "green");
                    Console.WriteLine("Для просмотра изменений, выведите очередь на экран (пункт 2)");
                    break;
            }
            Dialog.BackMessage();
            return;
        }
    }
}
