namespace lab2.Containers;
public class Refrigirated : Container
{
    public  string Type { get; set; }
    public  double Temperature { get; set; }

    public Refrigirated() : base("Rf")
    {
    }


}