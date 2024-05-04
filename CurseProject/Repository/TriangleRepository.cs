using CurseProject.Context;
using CurseProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CurseProject.Repository;

public class TriangleRepository : ITriangleRepository
{

    private readonly PostgresDbContext _postgresDbContext;
    
    public TriangleRepository(PostgresDbContext postgresDbContext)
    {
        _postgresDbContext = postgresDbContext;
    }
    public IEnumerable<Triangle> GetAllTriangles()
    {
        return _postgresDbContext.Triangles;
    }

    public Triangle GetTriangleById(long id)
    {
        //return _postgresDbContext.Triangles.FirstOrDefault(t => t.id == id) ?? throw new Exception();
        return _postgresDbContext.Triangles.Find(id) ?? throw new Exception($"Triangle with ID {id} not found.");
    }

    public void DeleteTriangle(long id)
    {
        var triangle = GetTriangleById(id);
        
        _postgresDbContext.Triangles.Remove(triangle);
        
        _postgresDbContext.SaveChanges();
    }

    public void UpdateTriangle(long id, Triangle newTriangle)
    {
        var triangle = _postgresDbContext.Triangles.Find(id);
        
        if (triangle != null)
        {
            triangle.name = newTriangle.name;
            triangle.a = newTriangle.a;
            triangle.b = newTriangle.b;
            triangle.c = newTriangle.c;
        }

        _postgresDbContext.SaveChanges();
    }
    
    public void AddTriangle(Triangle newTriangle)
    {
        _postgresDbContext.Triangles.Add(newTriangle);
        
        _postgresDbContext.SaveChanges();
    }
}