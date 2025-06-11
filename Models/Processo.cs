namespace testScrapping.Models;

public class Processo
{
    public string? ProcessoId{ get; set; }
    public string? Url { get; set; }
    public string? Classe { get; set; }
    public string? Assunto { get; set; }
    public string? Foro { get; set; }
    public string? Vara { get; set; }
    public string? Juiz { get; set; }
    public List<Movimentacao>? Movimentacoes { get; set; }
}