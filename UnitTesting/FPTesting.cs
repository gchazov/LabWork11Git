using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnimalLibrary;
using LabWork11;

namespace MethodTesting
{
    //������������ ������� ��� ������ ����� ������
    [TestClass]
    public class FPTesting
    {
        [TestMethod]
        public void TestRandomdAdd() //���� ���������� ��������� � �������
        {
            int expected = 25; //���������� ��������� �� �����, ������ �����
            Queue<Animal> actual = new Queue<Animal>();
            FPMethods.AddRandomToQueue(ref actual, 25);
            Assert.AreEqual(expected, actual.Count);
        }

        [TestMethod]
        public void TestTypeRequest1() //���� ������� �� �������������
        {
            //��� choice (������������� �������� ������)
            //1 - �������������
            //2 - �����
            //3 - �������������

            //���������� �������� ��������
            Queue<Animal> animals = new();
            Mammal m1 = new();
            Bird b1 = new();
            Artiodactyl a1 = new();
            //��������� 
            animals.Enqueue(m1);
            animals.Enqueue(b1);
            animals.Enqueue(a1);
            List<Animal> res = FPMethods.GetTypeRequest(1, animals);
            List<Animal> actual = new();
            actual.Add(m1);

            //��� ��������� ��������� ����� ������������:
            Assert.IsTrue(res.SequenceEqual(actual));
        }

        [TestMethod]
        public void TestTypeRequest2() //���� ������� �� ����
        {
            Queue<Animal> animals = new();
            Mammal m1 = new();
            Bird b1 = new();
            Artiodactyl a1 = new();
            //��������� 
            animals.Enqueue(m1);
            animals.Enqueue(b1);
            animals.Enqueue(a1);
            List<Animal> res = FPMethods.GetTypeRequest(2, animals);
            List<Animal> actual = new();
            actual.Add(b1);

            //��� ��������� ��������� ����� ������������:
            Assert.IsTrue(res.SequenceEqual(actual));
        }

        [TestMethod]
        public void TestTypeRequest3() //���� ������� �� �������������
        {
            Queue<Animal> animals = new();
            Mammal m1 = new();
            Bird b1 = new();
            Artiodactyl a1 = new();
            //��������� 
            animals.Enqueue(m1);
            animals.Enqueue(b1);
            animals.Enqueue(a1);
            List<Animal> res = FPMethods.GetTypeRequest(3, animals);
            List<Animal> actual = new();
            actual.Add(a1);

            //��� ��������� ��������� ����� ������������:
            Assert.IsTrue(res.SequenceEqual(actual));
        }

        [TestMethod]
        public void TestOldestAnimal() //���� ������� �� ��������� ��������
        {
            Queue<Animal> animals = new();
            Mammal m1 = new("�����", 1, "������", true,1);
            Bird b1 = new("�������", 3, "africa", true, 2);
            Artiodactyl a1 = new("������", 19, "����", true, "������", 3);
            //��������� 
            animals.Enqueue(m1);
            animals.Enqueue(b1);
            animals.Enqueue(a1);
            Artiodactyl expected = new("������", 19, "����", true, "������", 4);
            var actual = FPMethods.OldestAnimal(animals);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCloneQueue() //���� ������������ �������
        {
            Queue<Animal> animals = new();
            Mammal m1 = new("rabbit", 1, "selo Kapustino", true, 1);
            Bird b1 = new("�������", 3, "���� �� �������?", true, 2);
            Artiodactyl a1 = new("goat", 19, "����", true, "cool", 3);
            //��������� 
            animals.Enqueue(m1);
            animals.Enqueue(b1);
            animals.Enqueue(a1);

            Queue<Animal> actual = FPMethods.CloneQueue(animals);
            Assert.IsTrue(actual.SequenceEqual(animals));
        }

        [TestMethod]
        public void TestClearQueue() //���� ������� �������
        {
            Queue<Animal> animals = new();
            Mammal m1 = new("koshak", 1, "Bishkek", true, 1);
            Bird b1 = new("���� ���������", 3, "��� ��� ���������?", true, 2);
            Artiodactyl a1 = new("ram", 19, "NYC", true, "sharp", 3);
            //��������� 
            animals.Enqueue(m1);
            animals.Enqueue(b1);
            animals.Enqueue(a1);

            FPMethods.ClearQueue(ref animals);
            Assert.AreEqual(0, animals.Count);
        }

        [TestMethod]
        public void TestSort() //���� ���������� ������� �� ������
        {
            Queue<Animal> animals = new();
            Mammal m1 = new("���", 1, "Bishkek", true, 1);
            Bird b1 = new("����� ���������", 3, "��� ��� ���������?", true, 2);
            Artiodactyl a1 = new("������", 19, "NYC", true, "sharp", 3);
            //��������� � ��������� �������
            animals.Enqueue(b1);
            animals.Enqueue(a1);
            animals.Enqueue(m1);

            animals.Clear();
            //��������� � ������. �������
            animals.Enqueue(m1);
            animals.Enqueue(b1);
            animals.Enqueue(a1);
            Queue<Animal> sorted = FPMethods.Sort(animals);
            Assert.IsTrue(sorted.SequenceEqual(animals));
        }

        [TestMethod]
        public void TestFindObj1() //���� ������ �� ������
        {
            Queue<Animal> animals = new();
            Mammal m1 = new("���", 1, "Bishkek", true, 1);
            Bird b1 = new("����� ���������", 3, "��� ��� ���������?", true, 2);
            Artiodactyl a1 = new("������", 19, "NYC", true, "sharp", 3);
            //������� ���������� �������������
            animals.Enqueue(m1);
            animals.Enqueue(b1);
            animals.Enqueue(a1);

            Animal animalFind = new("������", 2, "������������ ��������", 666);
            var found = FPMethods.FindObj(animals, animalFind);
            Assert.AreEqual(null, found);
        }

        [TestMethod]
        public void TestFindObj2() //���� ������ ������
        {
            Queue<Animal> animals = new();
            Mammal m1 = new("���", 1, "Bishkek", true, 1);
            Bird b1 = new("����� ���������", 3, "��� ��� ���������?", true, 2);
            Artiodactyl a1 = new("������", 19, "NYC", true, "sharp", 3);
            //������� ���������� �������������
            animals.Enqueue(m1);
            animals.Enqueue(b1);
            animals.Enqueue(a1);

            Mammal animalFind = new("���", 1, "Bishkek", true, 1);
            var found = FPMethods.FindObj(animals, animalFind);
            Assert.AreEqual(m1, found);
        }





    }
}