namespace CurseProject.Models;

public class Triangle
{
    public long Id { get; init; }
    public string name { get; set; }
    public long A { get; set; }
    public long B { get; set; }
    public long C { get; set; }
    public Double Square { get; set; }
    public void AreaCalculation()
    {
        var p = (A + B + C) / 2.0;
        Square = Math.Sqrt(p*(p-A)*(p-B)*(p-C));
    }
}