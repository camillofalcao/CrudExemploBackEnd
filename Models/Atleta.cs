namespace AtletaBackend.Models;
public class Atleta
{
    public string? Id { get; set; }
    public string Nome { get; set; } = "";
    public double Altura { get; set; }
    public double Peso { get; set; }

    public IList<AtletaRecord> Records { get; set; } = new List<AtletaRecord>();
}
