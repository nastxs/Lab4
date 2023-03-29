using System;

namespace Lab4
{
    public class TriangleService : ITriangleService
    {
        public double GetArea(double a, double b, double c)
        {
            double p = (a + b + c) / 2;
            return Math.Round(Math.Sqrt(p*(p - a) * (p - b) * (p - c)), 5);
        }

        public TriangleType GetType(double a, double b, double c)
        {
            TriangleType result1, result2;

                if (a != b && b != c && a != c)
                   result1=TriangleType.Scalene; 
                else
                    if (a == b && b == c && a == c)
                    result1= TriangleType.Equilateral;
                else
                    result1=TriangleType.Isosceles;
            

            if (a * a == (b * b + c * c) || b * b == (a * a + c * c) || c * c == (b * b + a * a))
                result2 = TriangleType.Right;
            else
                    if (a * a > (b * b + c * c) || b * b > (a * a + c * c) || c * c > (b * b + a * a))
                result2 = TriangleType.Obtuse;
            else
                result2 = TriangleType.Oxygon;

            return result1 | result2;
    }


    public bool IsValidTriangle(double a, double b, double c)
        {
            if (a > 0 && b > 0 && c > 0)
                if (a < b + c && b < a + c && c < a + b)
                    return true;
                else return false;
            else return false;
        }

        public void Save(double a, double b, double c, TriangleType type, double area)
        {
            int count = 0;
            Triangle triangle = new Triangle(count, a, b, c, type, area);
        }
    }
}
