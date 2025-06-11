namespace testScrapping.Models;

public class BuscaProcesso
{
    public string ConversationId { get; set; }
    public string CbPesquisa { get; set; }
    public string ValorConsulta { get; set; }
    public string CdForo { get; set; }
    public BuscaProcesso(string conversationId, string cbPesquisa, string valorConsulta, string cdForo)
    {
        ConversationId = conversationId;
        CbPesquisa = cbPesquisa;
        ValorConsulta = valorConsulta;
        CdForo = cdForo;
    }
}