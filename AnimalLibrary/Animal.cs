﻿namespace AnimalLibrary
{
    public class Animal: IInit, IShow, IComparable, ICloneable
    {
        /*описание полей, вспомогательных массивов
         такое описание есть в каждом наследуемом классе
        */
        protected string name;
        protected int age;
        protected string habitat;
        public AnimalId id;
        public Random random = new Random();

        protected string[] habitatArray = { "Евразия", "Африка", "Австралия", "Южная Америка", "Антарктида", "Северная Америка" };
        protected string[] animalArray = { "Комар", "Карась", "Ондатра", "Крокодил", "Щука", "Таракан", "Ящерица", "Лягушка", "Тарантул"};

        /// <summary>
        /// конструктор с параметрами и значениями по умолчанию
        /// </summary>
        /// <param name="name">название животного</param>
        /// <param name="age">возраст</param>
        /// <param name="habitat">естественное место обитания</param>
        public Animal(string name = "NoName", int age = 1, string habitat = "NoHabitat", int num = 0)
        {
            Name = name;
            Age = age;
            Habitat = habitat;
            id = new AnimalId(num);
        }

        //свойство названия живности
        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        //свойство возраста с условиями
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Возраст животного введён некорректно, полю возраста присвоено значение 1");
                    this.age = 1;
                }
                else if (value > 20)
                {
                    Console.WriteLine("Возраст животного введён некорректно, полю возраста присвоено значение 20");
                    this.age = 20;
                }
                else
                {
                    age = value;
                }
            }
        }

        public string Habitat
        {
            get { return habitat; }
            set { habitat = value; }
        }

        /*Невиртуальный метод для показа содержимого объекта
        об его недостатках указано в комментарии ниже
        */
        public void Print()
        {
            Console.WriteLine($"Животное: {Name}; Возраст: {Age}; Ареал обитания: {Habitat}; ID в зоопарке: {id}");
        }
        /*вирутальный метод показа содержимого объекта 
         Преимущество использования виртуальных методов над не виртуальными:
         Использование виртуальных методов позволяет реализовывать программу
         более гибко и удобно для каждого класса. У невиртуальных методов
         огромный недостаток, так называемая область видимости базового
         класса. Переопределяя невирутальный метод, на вывод поступят
         только те поля и свойства, которые хранятся в наследуемом суперклассе.
         Механизмы раннего и позднего связывания - причина этой разницы.
         */
        public virtual void Show()
        {
            Console.WriteLine($"Животное: {Name}; Возраст: {Age}; Ареал обитания: {Habitat}; ID в зоопарке: {id}");
        }

        //инициализация с клавиатуры (если необходим ввод с клавиатуры)
        public virtual void Init()
        {

            Name = Dialog.EnterString("Введите название животного:", true);
            Age = Dialog.EnterNumber("Введите возраст:", 1, 20);
            Habitat = Dialog.EnterString("Введите ареал обитания:", true);
            id.number = Dialog.EnterNumber("Введите ID: ", 0, 1000);
        }

        //генерация объекта с помощью ДСЧ
        public virtual void RandomInit()
        {
  
            Name = animalArray[random.Next(animalArray.Length)];
            Age = random.Next(1, 20);
            Habitat = habitatArray[random.Next(habitatArray.Length)];
            id.number = random.Next(0, 1000);
        }

        //переопределение вирт. метода Equals
        public override bool Equals(object? obj)
        {
            if (obj is Animal animal)
            {
                return (this.Age == animal.Age
                    && String.Compare(this.Name, animal.Name) == 0
                    && String.Compare(this.Habitat, animal.Habitat) == 0);
            }
            else
                return false;
        }

        //метод поверхностного копирования
        public object ShallowCopy()
        {
            return this.MemberwiseClone();
        }

        //метод глубокого копирования
        public object Clone()
        {
            return new Animal(Name, Age, Habitat, id.number);
        }

        public int CompareTo(object? obj)
        {
            if (!(obj is Animal)) return -1;
            Animal animal = (Animal)obj;
            return Name.CompareTo(animal.Name);
        }

    }
}