using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnimalLibrary;
using LabWork11;

namespace MethodTesting
{
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
            Mammal m1 = new("�����", 1, "������", true);
            Bird b1 = new("�������", 3, "africa", true);
            Artiodactyl a1 = new("������", 19, "����", true, "������");
            //��������� 
            animals.Enqueue(m1);
            animals.Enqueue(b1);
            animals.Enqueue(a1);
            Artiodactyl expected = new("������", 19, "����", true, "������");
            var actual = FPMethods.OldestAnimal(animals);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCloneQueue() //���� ������������ �������
        {
            Queue<Animal> animals = new();
            Mammal m1 = new("rabbit", 1, "selo Kapustino", true);
            Bird b1 = new("�������", 3, "���� �� �������?", true);
            Artiodactyl a1 = new("goat", 19, "����", true, "cool");
            //��������� 
            animals.Enqueue(m1);
            animals.Enqueue(b1);
            animals.Enqueue(a1);

            Queue<Animal> actual = FPMethods.CloneQueue(animals);
            Assert.IsTrue(actual.SequenceEqual(animals));
        }


    }
}