namespace ExploracionSubmarinaApp.Models;

public class Muestra
{
    public int IdMuestra { get; set; }
    public int IdExpedicion { get; set; }
    public string Tipo { get; set; } = string.Empty;
    public int ProfundidadM { get; set; }
    public decimal MasaKg { get; set; }
}