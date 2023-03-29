using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab4;

namespace IntegrationTests
{
    [TestClass]
    public class IntegrationTest
    {
        ITriangleProvider triangleProvider;
        ITriangleService triangleService;

        TriangleValidateService service;



        [TestInitialize]

        public void TestInitialize()
        {
            triangleProvider = new TriangleProvider();
            triangleService = new TriangleService();
            service = new TriangleValidateService(triangleProvider, triangleService);

        }

       
        [TestMethod]

        public void IsAllValid_2ValidTriangle()
        {

            triangleProvider.Save(new Triangle(1, 5, 9, 5, TriangleType.Isosceles| TriangleType.Obtuse , 9.80752, true));

            triangleProvider.Save(new Triangle(2, 5.2, 4.1, 8, TriangleType.Scalene | TriangleType.Obtuse, 9.39464, true));

            bool isAllValid = service.IsAllValid();

            Assert.AreEqual(true, isAllValid);

        }

        [TestMethod]

        public void IsAllValid_3InvalidTriangle()
        {

            triangleProvider.Save(new Triangle(8, 5, 9, 5, TriangleType.Scalene | TriangleType.Obtuse, 9.80752, false));

            triangleProvider.Save(new Triangle(9, 25, 29, 40, TriangleType.Scalene | TriangleType.Obtuse, 0, false));
            
            triangleProvider.Save(new Triangle(10, 5.2, 2, 8, TriangleType.Scalene | TriangleType.Right, 9.39464, false));

            bool isAllValid = service.IsAllValid();

            Assert.AreEqual(false, isAllValid);

        }
        [TestMethod]
        public void IsValid_Invalid()
        {

            triangleProvider.Save(new Triangle(4, 5, 9, 5, TriangleType.Scalene | TriangleType.Oxygon, 9.80752, false));

            bool isValid = service.IsValid(4);

            Assert.AreEqual(false, isValid);

        }
        [TestMethod]
        public void IsValid_Valid()
        {

            triangleProvider.Save(new Triangle(5, 25, 29, 40, TriangleType.Scalene | TriangleType.Obtuse, 360.94875, true));

            bool isValid = service.IsValid(5);

            Assert.AreEqual(true, isValid);

        }

        [TestMethod]

        public void IsAllValid_1Valid1InvalidTriangle()
        {
            triangleProvider.Save(new Triangle(6, 5, 9, 5, TriangleType.Isosceles | TriangleType.Obtuse, 9.80752, true));

            triangleProvider.Save(new Triangle(7, 5.2, 2, 8, TriangleType.Scalene|TriangleType.Right, 9.39464, false));
        
            bool isAllValid = service.IsAllValid();

            Assert.AreEqual(false, isAllValid);

        }

        [TestMethod]
        public void IsValid_Valid_Value()
        {
            triangleProvider.Save(new Triangle(3, 25, 29, 40, TriangleType.Scalene | TriangleType.Obtuse, 360.94875, true));

            bool isValid = service.IsValid(3);

            Assert.AreEqual(true, isValid);

            Assert.AreEqual(true, triangleProvider.GetById(3).IsValidType);

        }

        [TestMethod]
        public void IsValid_Invalid_Value()
        {
            triangleProvider.Save(new Triangle(11, 25, 29, 40, TriangleType.Scalene | TriangleType.Right, 360.94875, false));

            bool isAllValid = service.IsAllValid();

            Assert.AreEqual(false, isAllValid);

            Assert.AreEqual(false, triangleProvider.GetById(11).IsValidType);
        }
    }
}
