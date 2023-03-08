using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabWork11;
using AnimalLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CollectionTesting
{
    [TestClass]
    public class CollectionsTesting
    {
        [TestMethod]
        public void TestSizeChanges() //тест конструктора, свойств и методов
        {
            TestCollections testCollections = new TestCollections();
            testCollections.RandomInit(500);
            testCollections.AddElements(500);
            testCollections.DeleteElements(3);
            testCollections.DeleteElements(2);
            int size = testCollections.GetSize();

            Assert.AreEqual(995, size);
        }

        [TestMethod]
        public void TestCollectionValues() //тест установки 1, серединного и посл. значений
        {
            //тест  новых свойств
            TestCollections tc = new();
            var col1 = tc.Collection1;
            var col2 = tc.Collection2;
            var col3 = tc.Collection3;
            var col4 = tc.Collection4;

            tc.RandomInit(10);
            tc.AddElements(5);
            tc.SetValues();
            Bird el1 = tc.GetElement("first");
            Bird el2 = tc.GetElement("middle");
            Bird el3 = tc.GetElement("last");
            var el4 = tc.GetElement("notFound");
            var el5 = tc.GetElement("idkWhatTOWRITEHERE"); //по умолчанию свитч

            tc.AddElements(10);
            Bird newEl = tc.GetElement("last");
            //значения не были установлены, поэтому не произойдут изменения

            Assert.AreEqual(el3, newEl);



        }
    }
}
