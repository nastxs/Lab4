using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using Lab4;

namespace TriangleTests
{
    [TestClass]
    public class TestTriangles
    {
        private List<Triangle> trianglesTrue =new List<Triangle>
            {
                new Triangle (1, 5, 9, 5, TriangleType.Isosceles|TriangleType.Oxygon, 9.80752, true),
                new Triangle (2, 5.2, 4.1, 8, TriangleType.Scalene|TriangleType.Obtuse, 9.39464, true),
                new Triangle (3, 25, 29, 40, TriangleType.Scalene|TriangleType.Oxygon, 360.94875, true),
                new Triangle (4, 2.2, 2.2, 2.2, TriangleType.Equilateral|TriangleType.Oxygon,2.09578, true)
            };

        private List<Triangle> trianglesFalse = new List<Triangle>
            {
                new Triangle (1, 5, 9, 5, TriangleType.Isosceles|TriangleType.Right, 9.80752, false),
                new Triangle (2, 5.2, 4.1, 8, TriangleType.Equilateral|TriangleType.Oxygon, 9.39464, false),
                new Triangle (3, 25, 29, 40, TriangleType.Scalene|TriangleType.Oxygon, 0, false),
                new Triangle (4, 2.2, 2.2, 2.2, TriangleType.Isosceles|TriangleType.Obtuse,2.09578, false)
            };

        private List<Triangle> trianglesThreeValidOneInvalid = new List<Triangle>
            {
                new Triangle (1, 5, 9, 5, TriangleType.Isosceles|TriangleType.Oxygon, 9.80752),
                new Triangle (2, 5.2, 4.1, 8, TriangleType.Scalene|TriangleType.Obtuse, 9.39464),
                new Triangle (3, 25, 29, 40, TriangleType.Scalene|TriangleType.Oxygon, 360.94875),
                new Triangle (4, 2.2, 2.2, 2.2, TriangleType.Isosceles|TriangleType.Right,2.09578)
            };

        private List<Triangle> trianglesOneValidOneInvalid = new List<Triangle>
            {
                new Triangle (1, 5, 9, 5, TriangleType.Isosceles|TriangleType.Oxygon, 9.80752),
               new Triangle (3, 25, 29, 40, TriangleType.Scalene, 0)
            };

        private Mock<ITriangleProvider> mock;
        private ITriangleValidateService triangleValidateService;
        private ITriangleService triangleService;

        [TestInitialize]
        public void TestInitialize()
        {
            mock = new Mock<ITriangleProvider>();
            triangleService = new TriangleService();
            triangleValidateService = new TriangleValidateService(mock.Object, triangleService);
        }

        [TestMethod]
        public void TriangleProvider_IsAllValid_True()
        {
            mock.Setup(a => a.GetAll()).Returns(trianglesTrue);
            var result = triangleValidateService.IsAllValid();

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TriangleProvider_IsAllValid_False()
        {
            mock.Setup(a => a.GetAll()).Returns(trianglesFalse);
            var result = triangleValidateService.IsAllValid();

            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void TriangleProvider_IsValid_True()
        {
            mock.Setup(a => a.GetById(It.IsAny<int>())).Returns(trianglesTrue[0]);
            var result = triangleValidateService.IsValid(1);

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TriangleProvider_IsValid_False()
        {
            mock.Setup(a => a.GetById(It.IsAny<int>())).Returns(trianglesFalse[2]);
            var result = triangleValidateService.IsValid(3);

            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void TriangleProvider_IsAllValid_One_Valid_One_Invalid()
        {
            mock.Setup(a => a.GetAll()).Returns(trianglesOneValidOneInvalid);
            var result = triangleValidateService.IsAllValid();

            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void TriangleProvider_IsAllValid_Three_Valid_One_Invalid()
        {
            mock.Setup(a => a.GetAll()).Returns(trianglesThreeValidOneInvalid);
            var result = triangleValidateService.IsAllValid();

            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void TriangleProvider_IsValidValue_True()
        {
            mock.Setup(a => a.GetById(It.IsAny<int>())).Returns(trianglesTrue[0]);
            var result = trianglesTrue[0].IsValidType;

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TriangleProvider_IsValidValue_False()
        {
            mock.Setup(a => a.GetById(It.IsAny<int>())).Returns(trianglesFalse[0]);
            var result = trianglesFalse[0].IsValidType;

            Assert.AreEqual(false, result);
        }
    }
}

