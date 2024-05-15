using CurseProject.Context;
using CurseProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CurseProject.Repository;

public class TriangleRepository(PostgresDbContext postgresDbContext) : ITriangleRepository
{
    public IEnumerable<Triangle> GetAllTriangles()
    {
        return postgresDbContext.Triangles;
    }

    public Triangle GetTriangleById(long id)
    {
        //return _postgresDbContext.Triangles.FirstOrDefault(t => t.id == id) ?? throw new Exception();
        return postgresDbContext.Triangles.Find(id) ?? throw new Exception($"Triangle with ID {id} not found.");
    }

    public void DeleteTriangle(long id)
    {
        var triangle = GetTriangleById(id);
        
        postgresDbContext.Triangles.Remove(triangle);
        
        postgresDbContext.SaveChanges();
    }

    public void UpdateTriangle(long id, Triangle newTriangle)
    {
        var triangle = postgresDbContext.Triangles.Find(id);
        
        if (triangle != null)
        {
            triangle.name = newTriangle.name;
            triangle.A = newTriangle.A;
            triangle.B = newTriangle.B;
            triangle.C = newTriangle.C;
            newTriangle.AreaCalculation();
            triangle.Square = newTriangle.Square;
        }

        postgresDbContext.SaveChanges();
    }
    
    public void AddTriangle(Triangle newTriangle)
    {
        postgresDbContext.Triangles.Add(newTriangle);
        
        postgresDbContext.SaveChanges();
    }
}