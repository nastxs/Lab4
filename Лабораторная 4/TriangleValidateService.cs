using System.Collections.Generic;

namespace Lab4
{
   
    public class TriangleValidateService : ITriangleValidateService

    {

        private readonly ITriangleProvider dataProvider;

       private readonly ITriangleService triangleService;

        public TriangleValidateService(ITriangleProvider dataProvider, ITriangleService triangleService)
        {
            this.dataProvider = dataProvider;
            this.triangleService = triangleService;
        }

        private void checkTriangle(Triangle triangle)
        {
            if (triangleService.IsValidTriangle(triangle.A, triangle.B, triangle.C) == true)
              if (triangleService.GetType(triangle.A, triangle.B, triangle.C) == triangle.Type)
                    if (triangleService.GetArea(triangle.A, triangle.B, triangle.C) == triangle.Area)
                        triangle.IsValidType = true;
                    else triangle.IsValidType = false;
                else triangle.IsValidType = false;
            else triangle.IsValidType = false;
        }
        public bool IsValid(int id)
        {
            Triangle triangle = dataProvider.GetById(id);
            checkTriangle(triangle);
            return triangle.IsValidType;
        }

        public bool IsAllValid()
        {
            List<Triangle> list = dataProvider.GetAll();
            foreach (Triangle item in list)
            {
                checkTriangle(item);
                if (item.IsValidType == true)
                    continue;
                else
                    return false;
            }
            return true;
        }
    }
}

