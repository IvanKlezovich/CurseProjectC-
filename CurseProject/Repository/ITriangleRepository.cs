namespace CurseProject.Models;

public interface ITriangleRepository
{
    IEnumerable<Triangle> GetAllTriangles();
    Triangle GetTriangleById(long id);
    void AddTriangle(Triangle newTriangle);
    public void DeleteTriangle(long id);
    public void UpdateTriangle(long id, Triangle newTriangle);
}