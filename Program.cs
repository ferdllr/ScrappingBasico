using System.Net.Http;
using HtmlAgilityPack;
using testScrapping.Models;

var web = new HtmlWeb();
var busca = new BuscaProcesso("", "NMPARTE","Rumo+Malha+Sul", "-1");
var url = $"https://esaj.tjsp.jus.br/cpopg/search.do?conversationId={busca.ConversationId}&cbPesquisa={busca.CbPesquisa}&dadosConsulta.valorConsulta={busca.ValorConsulta}&cdForo={busca.CdForo}";
var document = web.Load(url);
var processos = new List<Processo>();
var ProcessosHTMLElements = document.DocumentNode.QuerySelectorAll("ul.unj-list-row");

for(int i = 0; i<ProcessosHTMLElements.Count();i++)
{
    var processoUrl = "https://esaj.tjsp.jus.br" + HtmlEntity.DeEntitize(ProcessosHTMLElements[i].QuerySelector("a").Attributes["href"].Value);
    var processoHTML = web.Load(processoUrl);
    var dadosHTML = processoHTML.QuerySelector("div#containerDadosPrincipaisProcesso");
    
    var processo = new Processo
    {
        Url = processoUrl,
        ProcessoId = HtmlEntity.DeEntitize(dadosHTML?.QuerySelector("span#numeroProcesso")?.InnerText.Trim() ?? "N/A"),
        Assunto = HtmlEntity.DeEntitize(dadosHTML?.QuerySelector("span#assuntoProcesso")?.InnerText.Trim() ?? "N/A"),
        Classe = HtmlEntity.DeEntitize(dadosHTML?.QuerySelector("span#classeProcesso")?.InnerText.Trim() ?? "N/A"),
        Foro = HtmlEntity.DeEntitize(dadosHTML?.QuerySelector("span#foroProcesso")?.InnerText.Trim() ?? "N/A"),
    };
    processos.Add(processo);
}

Console.WriteLine("TESTE DE WEBSCRAPPING PROCESSOS");
Console.WriteLine("BUSCA: Rumo Malha Sul");
foreach (var processo in processos)
{
    Console.WriteLine("----------------------------------");
    Console.WriteLine("Url: " + processo.Url);
    Console.WriteLine("Id: " + processo.ProcessoId);
    Console.WriteLine("Assunto: " + processo.Assunto);
    Console.WriteLine("Classe: " + processo.Classe);
    Console.WriteLine("Foro: " + processo.Foro);
}