
namespace SistemaVendas;

public class CalculadoraRoyalties
{
    private VendaRepository _vendaRepository;

    public CalculadoraRoyalties(VendaRepository vendaRepository)
    {
        this._vendaRepository = vendaRepository;
    }

    public double Calcular(int mes, int ano)
    {
        List<Venda> vendas = ObterVendas(mes, ano); 
        if (vendas == null || !vendas.Any())
            return 0;

        double faturamento = CalcularFaturamento(vendas);
        double comissoes = CalcularComissoes(vendas);
        double royalties = CalcularRoyalties(faturamento, comissoes);

        return truncarComDuasCasas(royalties);
    }

    private double truncarComDuasCasas(double valor)
    {
        return Math.Floor(valor * 100) / 100;
    }

    private double CalcularRoyalties(double faturamento, double comissoes)
    {
        return (faturamento - comissoes) * 0.2;
    }

    private double CalcularComissoes(List<Venda> vendas)
    {
        double comissaoTotal = 0;
        var calculadoraComissao = new CalculadoraComissao();
        foreach(var venda in vendas)
            comissaoTotal += calculadoraComissao.Calcular(venda.Valor);
        return comissaoTotal;
    }

    private double CalcularFaturamento(List<Venda> vendas)
    {
        return vendas.Sum(v => v.Valor);
    }

    private List<Venda> ObterVendas(int mes, int ano)
    {
        return _vendaRepository.ObterVendasPorMesEAno(ano, mes);
    }
}
