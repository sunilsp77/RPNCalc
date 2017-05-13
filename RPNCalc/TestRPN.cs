using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace RPNCalc
{
    [TestFixture]
    class TestRPN
    {
        [Test]
        public void TestCase1()
        {
            RPNCalculator obj = new RPNCalculator();
            Assert.AreEqual(4, Convert.ToInt32(obj.Calculate("2,2,+")));
        }
        [Test]
        public void TestCase2()
        {
            RPNCalculator obj = new RPNCalculator();
            Assert.AreEqual(5, Convert.ToInt32(obj.Calculate("2,3,+")));
        }
        [Test]
        public void TestCase3()
        {
            try
            {
                RPNCalculator obj = new RPNCalculator();
                int result = Convert.ToInt32(obj.Calculate("2,+,2"));
            }catch(Exception ex)
            {
                Assert.AreEqual("Invalid Expression", ex.Message);
            }
            
        }
        [Test]
        public void TestCase4()
        {
            try
            {
                RPNCalculator obj = new RPNCalculator();
                int result = Convert.ToInt32(obj.Calculate("+"));
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Invalid Expression", ex.Message);
            }
            
        }
        [Test]
        public void TestCase5()
        {
                RPNCalculator obj = new RPNCalculator();           
                Assert.AreEqual(0,Convert.ToInt32(obj.Calculate("2,2,+,4,-")));
        }
        [Test]
        public void TestCase6()
        {
            RPNCalculator obj = new RPNCalculator();
            Assert.AreEqual(1, Convert.ToInt32(obj.Calculate("2,2,*,4,/")));
        }
        [Test]
        public void TestCase7()
        {
            RPNCalculator obj = new RPNCalculator();
            Assert.AreEqual(0, Convert.ToInt32(obj.Calculate("2,2,*,4,/,1,+,2,-")));
        }
        [Test]
        public void TestCase8()
        {
            try
            {
                RPNCalculator obj = new RPNCalculator();
                int result = Convert.ToInt32(obj.Calculate("2,0,/"));
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Divide by zero", ex.Message);
            }
        }
        [Test]
        public void TestCase9()
        {
            try
            {
                RPNCalculator obj = new RPNCalculator();
                Convert.ToInt32(obj.Calculate("-4,!"));
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Invalid Operand", ex.Message);
            }
        }
        [Test]
        public void TestCase10()
        {
            RPNCalculator obj = new RPNCalculator();
            Assert.AreEqual(24, Convert.ToInt32(obj.Calculate("4,!")));
        }
        [Test]
        public void TestCase11()
        {
            RPNCalculator obj = new RPNCalculator();
            Assert.AreEqual(1, Convert.ToInt32(obj.Calculate("2,2,*,4,/,1,+,2,-,!")));
        }
        [Test]
        public void TestCase12()
        {
            try
            {
                RPNCalculator obj = new RPNCalculator();
                obj.Calculate("2147483647,2,+");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("greater than max1", ex.Message);
            }
        }
    }
}
