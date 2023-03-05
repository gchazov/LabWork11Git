using System.Collections;
using AnimalLibrary;


namespace LabWork11
{
    public class Program
    {
        //объект для генерации с помощью ДСЧ
        public static Random random = new Random();

        //печать основного меню программы на экран
        static void MainPage()
        {
            Console.WriteLine("1. Первая часть работы (коллекция Queue <Animal>)\n" +
                    "2. Вторая часть работы (коллекция SortedDictionary <int, Animal>)\n" +
                    "3. Третья часть работы (коллекции первых двух частей)\n\n" +
                    "4. Завершить работу программы\n");
        }

        //выполнение основной части программы
        static void Run(ref Queue<Animal> animalQueue, ref SortedDictionary<int, Animal> animalDict)
        {
            bool isRunning = true; //при false программа завершит работу
            do
            {
                Dialog.PrintHeader("Лабораторная работа 11");
                MainPage();

                int choice = Dialog.EnterNumber("\nВыберите один из пунктов меню:", 1, 4);
                switch (choice) //обработка выбора пользователя через switch-case
                {
                    case 1:
                        FirstPart.FPMenu(ref animalQueue); //запуск первой части работы
                        break;
                    case 2:
                        SecondPart.SPMenu(ref animalDict);
                        break;
                    case 4:
                        isRunning = false; //установка условия завершения программы
                        break;
                }
            } while (isRunning);
            Dialog.PrintHeader("Завершение работы");
            Dialog.ColorText("Программа успешно завершила свою работу. Всего Вам хорошего!", "cyan");

        }

        //рекомендации по использованию приложения для пользователя
        public static void UserRecomendations()
        {
            Dialog.PrintHeader("Важная информация для пользователя");
            Console.WriteLine("Для удобства использования программы, пожалуйста, установите полноэкранный режим консоли!\n\n" +
                "=> Alt + Enter для Windows\n" +
                "=> Control + Command + F для MacOS\n");
            Console.WriteLine("Нажмите Enter для продолжения...");
            Console.ReadLine();
        }
        static void Main(string[] args)
        { 
            Queue<Animal> animalQueue = new Queue<Animal>(); //инициализация очереди для 1 части
            SortedDictionary<int, Animal> animalDict = new SortedDictionary<int, Animal>(); //инициализация словаря для 2 части
            UserRecomendations(); //печать рекомендаций для пользователя
            Run(ref animalQueue, ref animalDict); //вызов метода Run(...), выполняющего основную часть программы
        }
    }
}