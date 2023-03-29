using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Lab4
{
   public class TriangleProvider : ITriangleProvider
    {
        public List<Triangle> GetAll()
        {
            using (TrianglesContext db = new TrianglesContext())
            {
                var triangles = db.triangle.ToList();
                return triangles;
            }
        }

        public Triangle GetById(int id)
        {
            using (TrianglesContext db = new TrianglesContext())
            {
                var result = db.triangle.FromSqlRaw($"SELECT * FROM triangle_table WHERE id = {id}").ToList();
                return result[0];
            }
        }

        public Triangle GetBySides(double a, double b, double c)
        {
            using (TrianglesContext db = new TrianglesContext())
            {
                var result = db.triangle.FromSqlRaw($"SELECT * FROM triangle_table WHERE a = {a} AND b = {b} AND c = {c}").ToList();
                return result[0];
            }
        }

        public void Save(Triangle triangle)
        {
            using (TrianglesContext db = new TrianglesContext())
            {
                db.triangle.AddRange(triangle);
                db.SaveChanges();
            }
        }
    }
}
