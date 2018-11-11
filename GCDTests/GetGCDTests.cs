using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCD;

namespace GCDTests
{
    [TestFixture]
    public class GetGCDTests
    {
        [TestCase(87, 195, ExpectedResult = 3)]
        [TestCase(690, 695, ExpectedResult = 5)]
        [TestCase(120, 1020, ExpectedResult = 60)]
        [TestCase(40, 100, ExpectedResult = 20)]
        [TestCase(985, 985, ExpectedResult = 985)]
        public int GCDEuklidTests_WithTwoArguments_ExpectedGDCValue(int a, int b)
        {
            return GetGCD.GCDEuklid(a, b);
        }

        public int GCDdSteinTests_WithTwoArguments_ExpectedGDCValue(int a, int b)
        {
            return GetGCD.GCDStein(a, b);
        }

        [TestCase(14, 21, 28, ExpectedResult = 7)]
        [TestCase(72, 32, 256, ExpectedResult = 8)]
        [TestCase(1080, 86, 122, ExpectedResult = 2)]
        [TestCase(3216, 784, 16, ExpectedResult = 16)]
        public int GCDEuklidTests_WithThreeArguments_ExpectedGDCValue(int a, int b, int c)
        {
            return GetGCD.GCDEuklid(a, b, c);
        }
        public int GCDdSteinTests_WithThreeArguments_ExpectedGDCValue(int a, int b, int c)
        {
            return GetGCD.GCDStein(a, b, c);
        }

        [TestCase(276, 636, 2828, 88, ExpectedResult = 4)]
        [TestCase(36, 60, 126, 654, ExpectedResult = 6)]
        [TestCase(125, 855, 1300, 812805, ExpectedResult = 5)]
        [TestCase(21, 30, 3330, 795, ExpectedResult = 3)]
        public int GCDEuklidTests_WithFourArguments_ExpectedGDCValue(params int[] d)
        {
            return GetGCD.GCDEuklid(d);
        }

        public int GCDdSteinTests_WithFourArguments_ExpectedGDCValue(params int[] d)
        {
            return GetGCD.GCDStein(d);
        }

        [Test]
        public void GCDEuklidTests_WithLessThanOneArgs_ThrowsArgumentException()
        {
            Assert.That(() => GetGCD.GCDEuklid(0, 120), Throws.ArgumentException);
        }

        [Test]
        public void GCDSteinTests_WithLessThanOneArgs_ThrowsArgumentException()
        {
            Assert.That(() => GetGCD.GCDStein(0, 120), Throws.ArgumentException);
        }

        [Test]
        public void GCDEuklidTests_ArrayIsNull_ThrowsArgumentNullException()
        {
            Assert.That(() => GetGCD.GCDEuklid(null), Throws.ArgumentNullException);
        }
        [Test]
        public void GCDSteinTests_ArrayIsNull_ThrowsArgumentNullException()
        {
            Assert.That(() => GetGCD.GCDStein(null), Throws.ArgumentNullException);
        }

    }
}
