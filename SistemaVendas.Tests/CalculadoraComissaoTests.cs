namespace SistemaVendas.Tests;

public class CalculadoraComissaoTests
{
    [Fact]
    public void Venda_de_1000_retorna_comissao_de_50()
    {
        double comissaoEsperada = 50.0;
        double totalVendas = 1000.0;
        CalculadoraComissao calculo = new CalculadoraComissao();
        double comissao = calculo.Calcular(totalVendas);

        Assert.Equal(comissaoEsperada, comissao);
    }

    [Fact]
    public void Venda_de_2000_retorna_comissao_de_100()
    {
        double totalVendas = 2000.0;
        CalculadoraComissao calculo = new CalculadoraComissao();
        double comissao = calculo.Calcular(totalVendas);

        Assert.Equal(100.0, comissao);
    }

    [Fact]
    public void Venda_de_10000_retorna_comissao_de_600()
    {
        double totalVendas = 10000;
        CalculadoraComissao calculo = new CalculadoraComissao();
        double comissao = calculo.Calcular(totalVendas);

        Assert.Equal(600, comissao);
    }

    [Fact]
    public void Venda_de_77_99_retorna_comissao_de_3_89()
    {
        double totalVendas = 77.99;
        CalculadoraComissao calculo = new CalculadoraComissao();
        double comissao = calculo.Calcular(totalVendas);

        Assert.Equal(3.89, comissao);
    }
}