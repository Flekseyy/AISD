namespace Sort;


public class ResultRow
{
    public string Algorithm { get; set; } = "";
    public int Size { get; set; }
    public string DataType { get; set; } = ""; 
    public double TimeMs { get; set; }
    public long Iterations { get; set; }
}