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
            Console.WriteLine("1. Первая часть работы (коллекция Queue<>)\n" +
                    "2. Вторая часть работы (коллекция SortedDictionary <K, T>)\n" +
                    "3. Третья часть работы (коллекции первых двух частей)\n" +
                    "4. Завершить работу программы\n");
        }

        //выполнение основной части программы
        static void Run(ref Queue<Animal> animalQueue)
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
            Console.WriteLine("Для удобства использования программы, пожалуйста, установите полноэкранный режим консоли!\n\n" +
                "=> Alt + Enter для Windows\n" +
                "=> Control + Command + F для MacOS\n");
            Console.WriteLine("Нажмите Enter для продолжения...");
            Console.ReadLine();
        }
        static void Main(string[] args)
        { 
            Queue<Animal> animalQueue = new Queue<Animal>(); //инициализация очереди для 1 части
            UserRecomendations(); //печать рекомендаций для пользователя
            Run(ref animalQueue); //вызов метода Run(...), выполняющего основную часть программы
        }
    }
}