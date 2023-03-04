﻿using AnimalLibrary;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork11
{
    //класс для работы с первой частью работы
    public class FirstPart
    {
        /*константа - максимальная вместимость очереди;
         * удобство в том, что при её изменении не придётся
         * изменять значения в каждом методе программы
         */
        public const int MAX_CAPACITY = 100;

        //печать основного меню первой части работа
        public static void FPMainPage() //здесь и далее: FP - сокращение First Part
        {
            Console.WriteLine("\n1. Сформировать очередь из случайных объектов\n" +
                "2. Вывести очередь на экран\n" +
                "3. Добавить случайные элементы в очередь\n" +
                "4. Извлечь и удалить элементы из очереди\n" +
                "5. Запросы объектов определённого типа\n" +
                "6. Самое старшее животное очереди\n" +
                "7. Найти элемент в очереди\n" +
                "8. Выполнить клонирование очереди\n\n" +
                "9. Вернуться в главное меню\n");

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
                int choice = Dialog.EnterNumber("Выберите пункт меню:", 1, 9);

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
                        DequeueElements(ref animalQueue);
                        break;
                    case 5:
                        TypeRequests(animalQueue);
                        break;
                    case 6:
                        OldestRequest(animalQueue);
                        break;
                    case 7:
                        FindObject(animalQueue);
                        break;
                    case 8:
                        CloneQueue(animalQueue);
                        break;
                    case 9: //выход в самое первое меню
                        isRunning = false;
                        break;

                }
            } while (isRunning);
            return;
        }

        
        //создание очереди из элементов коллекции с помощью ДСЧ
        public static void MakeQueueRandom(ref Queue<Animal> animals)
        {
            Dialog.PrintHeader("Создание очереди с помощью ДСЧ");
            int length = Dialog.EnterNumber($"Введите длину очереди (до {MAX_CAPACITY}):", 0, MAX_CAPACITY);
            Queue<Animal> animalQueue = new Queue<Animal>(length); //создание очереди заданной длины
            FPMethods.AddRandomToQueue(ref animalQueue, length);

            //обновляем инициализированную очередь
            animals = new Queue<Animal>(animalQueue);
            
            Console.WriteLine();
            switch (animals.Count)
            {
                case 0: //если очередь пуста
                    Dialog.ColorText("Пустая очередь создана", "green");
                    break;
                default: //если очередь содержит 1<=n<=MAX_CAPACITY объектов
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
            //чтобы пользователь успел прочитать сообщение выше
            if (animals.Count >= 22)
            {
                Console.WriteLine("Вывод объектов через...");
                for (int i = 0; i <= 2; i++)
                {
                    Console.WriteLine(i+1);
                    Thread.Sleep(1000);
                }
            }
            int elementNumber = 0;
            foreach(Animal animal in animals) //перебор объектов очереди
            {
                elementNumber++;
                FPQueueCount(elementNumber, $"Объект очереди № ", "");
                Console.Write(":\n\t");
                animal.Show();
            }
            Dialog.BackMessage();
            return;
        }

        //метод извлечения удаления объекта из очереди
        public static void DequeueElements(ref Queue<Animal> animals)
        {
            Dialog.PrintHeader("Извлечение и удаление элементов из очереди");
            if (animals.Count == 0) //случай, когда очередь пуста
            {
                Dialog.ColorText("Нечего удалять в пустой очереди!", "green");
                Console.WriteLine("Заполните её элементами и попробуйте операцию извлечения заново");
                Dialog.BackMessage();
                return;
            }

            int elementAmount = Dialog.EnterNumber("Введите количество извлекаемых из очереди элементов:", 0, animals.Count);
            switch (elementAmount)
            {
                case 0: //случай, когда удалять нечего
                    Dialog.ColorText("Очередь осталась без изменений!","green");
                    break;
                case 1: //особый случай для одного объекта
                    Animal excludedAnimal = animals.Dequeue();
                    Dialog.ColorText("Из очереди удалён первый добавленный из оставшихся элемент:\n", "green");
                    excludedAnimal.Show();
                    break;
                default:
                    //создание массива для исключаемых элементов
                    Animal[] exludedAnimals = new Animal[elementAmount];
                    for (int i = 0; i < elementAmount; i++)
                    {
                        exludedAnimals[i] = animals.Dequeue();
                    }

                    Dialog.ColorText($"Из очереди удален(-ы) следующие {elementAmount} элемент(-ов):\n", "green");
                    foreach (Animal animal in exludedAnimals)
                    {
                        animal.Show();
                    }
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
                    FPMethods.AddRandomToQueue(ref animals, elementAmount);
                    Dialog.ColorText($"Очередь пополнилась на {elementAmount} элемент(-ов)", "green");
                    Console.WriteLine("Для просмотра изменений, выведите очередь на экран (пункт 2)");
                    break;
            }
            Dialog.BackMessage();
            return;
        }

        //запрос на объекты одного типа
        public static void TypeRequests(Queue<Animal> animals)
        {
            Dialog.PrintHeader("Объекты определённого типа");

            if (animals.Count == 0)
            {
                Dialog.ColorText("Для пустой очереди операция недоступна");
                Dialog.BackMessage();
                return;
            }

            bool isRunning = true;
            do
            {
                Dialog.PrintHeader("Объекты определённого типа");
                Console.WriteLine("1. Млекопитающие (Mammal)\n" +
                    "2. Птицы (Bird)\n" +
                    "3. Парнокопытные (Artiodactyl)\n" +
                    "4. Назад\n");
                int choice = Dialog.EnterNumber("Выберите один из типов:", 1, 4);

                if (choice == 4)
                {
                    //выход из меню
                    isRunning = false;
                    break;
                }

                Dialog.PrintHeader("Объекты определённого типа");
                List<Animal> res = FPMethods.GetTypeRequest(choice, animals);
                switch (res.Count)
                {
                    case 0:
                        Console.WriteLine("В очереди нет объектов выбранного типа");
                        break;
                    default:
                        Dialog.ColorText($"В очереди найден(-о) {res.Count} подходящий(-их) элемент(-ов):\n", "green");
                        foreach (Animal animal in res) //перебор в списке
                        {
                            animal.Show();
                        }
                        break;
                }
                Dialog.BackMessage();
            } while (isRunning);
            return;

        }

        //самое старшее животное очереди
        public static void OldestRequest(Queue<Animal> animals)
        {
            Dialog.PrintHeader("Объекты определённого типа");

            if (animals.Count == 0)
            {
                Dialog.ColorText("Для пустой очереди операция недоступна");
                Dialog.BackMessage();
                return;
            }

            Dialog.PrintHeader("Объекты определённого типа");
            Animal animal = FPMethods.OldestAnimal(animals);
            Console.WriteLine("Животное с наибольшим возрастом в очереди:");
            animal.Show();
            Dialog.BackMessage();
            return;
        }

        //поиск объекта в очереди
        public static void FindObject(Queue<Animal> animals)
        {
            Dialog.PrintHeader("поиск объекта в очереди");
            if (animals.Count == 0)
            {
                Dialog.ColorText("Для пустой очереди операция недоступна");
                Dialog.BackMessage();
                return;
            }

            bool isRunning = true;
            do
            {
                Dialog.PrintHeader("поиск объекта в очереди");
                var animalFind = new Animal();
                Console.WriteLine("1. Млекопитающее (Mammal)\n" +
                    "2. Птица (Bird)\n" +
                    "3. Парнокопытное (Artiodactyl)\n" +
                    "4. Назад\n");
                int choice = Dialog.EnterNumber("Выберите тип объекта, который будет найден:", 1, 4);

                if (choice == 4)
                {
                    //возврат в предыдущее меню
                    isRunning = false;
                    return;
                }

                switch (choice)
                { //определение типа
                    case 1:
                        animalFind = new Mammal();
                        break;
                    case 2:
                        animalFind = new Bird();
                        break;
                    case 3:
                        animalFind = new Artiodactyl();
                        break;
                }

                Console.WriteLine();
                animalFind.Init(); //инициализация с клавиатуры

                bool exist = false;

                foreach (Animal animal in animals)
                {
                    if (animal.Equals(animalFind))
                    {
                        exist = true;
                        break;
                    }
                }

                if (!exist)
                {
                    Dialog.ColorText("Заданного элемента в массиве нет");
                    Dialog.BackMessage();
                    return;
                }

                Dialog.ColorText("\nЗаданный элемент есть в очереди:\n", "green");
                animalFind.Show();
                Dialog.BackMessage();
                return;
            } while (isRunning);
        }

        //создание клона очереди и демонстрация работы
        public static void CloneQueue(Queue<Animal> animals)
        {
            Dialog.PrintHeader("клонирование очереди");
            if (animals.Count == 0)
            {
                Dialog.ColorText("Для пустой очереди операция недоступна");
                Dialog.BackMessage();
                return;
            }

            //глубокое копирование исходной очереди
            Queue<Animal> clone = FPMethods.CloneQueue(animals);
            Dialog.ColorText("Очередь-клон успешно создана", "green");
            Console.WriteLine("Для демонстрации работы клонирования, извлечём элемент из исходной очереди");

            Console.WriteLine("Нажмите Enter, чтобы продолжить...");
            Console.ReadLine();
            animals.Dequeue();
            Dialog.ColorText("\nЭлемент успешно извлечён\n", "yellow");

            Console.WriteLine("Сравним очереди");
            Dialog.ColorText("\nИсходная очередь\n", "green");
            foreach(Animal animal in animals)
            {
                animal.Show();
            }
            Dialog.ColorText("\nОчередь-клон\n", "red");
            foreach (Animal animal in clone)
            {
                animal.Show();
            }

            Dialog.BackMessage();
        }
    }
}
