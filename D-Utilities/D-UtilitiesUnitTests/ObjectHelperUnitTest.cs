using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using D_Utilities;
namespace D_UtilitiesUnitTests
{
    [TestClass]
    public class ObjectHelperUnitTest
    {
        private testClass1 TestItem1 { get; set; }

        private testClass1 TestItem2 { get; set; }

        private testClass2 TestItem3 { get; set; }

        private testClass2 TestItem4 { get; set; }

        [TestMethod]
        public void TestEqualsMethod()
        {
            TestItem1 = new testClass1(1, 2, 3);
            TestItem2 = new testClass1(1, 2, 3);
            TestItem3 = new testClass2(4, 5, 6);
            TestItem4 = new testClass2(4, 5, 6);

            Assert.IsTrue(ObjectHelper.Equals(TestItem1, TestItem2));

            Assert.IsTrue(ObjectHelper.Equals(TestItem3, TestItem4));

            Assert.IsFalse(ObjectHelper.Equals(TestItem1, TestItem4));

            Assert.IsFalse(ObjectHelper.Equals(TestItem2, TestItem3));
        }

        [TestMethod]
        public void TestCompareMethod()
        {
            TestItem1 = new testClass1(1, 2, 3);
            TestItem2 = new testClass1(1, 2, 3);
            TestItem3 = new testClass2(4, 5, 6);
            TestItem4 = new testClass2(4, 5, 6);

            Assert.IsNotNull(ObjectHelper.Compare(TestItem1, TestItem2));

            Assert.IsNotNull(ObjectHelper.Compare(TestItem3, TestItem4));

            Assert.IsNull(ObjectHelper.Compare(TestItem1, TestItem4));

            Assert.IsNull(ObjectHelper.Compare(TestItem2, TestItem3));
        }
    }
    public class testClass1
    {
        public testClass1(int property1, int property2, int property3)
        {
            MyProperty1 = property1;
            MyProperty2 = property2;
            MyProperty3 = property3;
        }

        public int MyProperty1 { get; set; }

        public int MyProperty2 { get; set; }

        public int MyProperty3 { get; set; }

    }

    public class testClass2
    {
        public testClass2(int property1, int property2, int property3)
        {
            MyProperty1 = property1;
            MyProperty2 = property2;
            MyProperty3 = property3;
        }

        public int MyProperty1 { get; set; }

        public int MyProperty2 { get; set; }

        public int MyProperty3 { get; set; }
    }
}
