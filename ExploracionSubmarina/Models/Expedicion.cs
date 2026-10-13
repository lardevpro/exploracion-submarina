namespace ExploracionSubmarinaApp.Models;

public class Expedicion
{
    public int IdExpedicion { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public DateTime FechaSalida { get; set; } = DateTime.Today;
    public int DuracionHoras { get; set; }
    public int IdZona { get; set; }
    public int IdSumergible { get; set; }
}