namespace AtletaBackend.Models;
public class AtletaRecord
{
    public string? Id { get; set; }
    public string AtletaId { get; set; } = null!;
    public string Descricao { get; set; } = "";
    public DateTime Data { get; set; }
}
