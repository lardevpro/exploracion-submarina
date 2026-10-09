namespace ExploracionSubmarinaApp.Models;

public class Zona
{
    public int IdZona { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Ubicacion { get; set; } = string.Empty;
    public int ProfundidadMaxima { get; set; }
}