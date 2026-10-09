namespace ExploracionSubmarinaApp.Models;

public class Sumergible
{
    public int IdSumergible { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Modelo { get; set; } = string.Empty;
    public int AutonomiaHoras { get; set; }
}