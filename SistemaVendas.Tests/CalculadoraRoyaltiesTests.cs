using Moq;

namespace SistemaVendas.Tests;

// Lula
// Raul
// Danilo
// Felix
// Erick

public class CalculadoraRoyaltiesTests
{

    [Fact]
    public void Mes_12_de_2022_sem_vendas_retorna_royalties_de_0()
    {
        int mes = 12;
        int ano = 2022;
        double royaltiesEsperados = 0;

        var marionete = new Mock<VendaRepository>();
        double royaltiesCalculados = new CalculadoraRoyalties(marionete.Object).Calcular(mes, ano);

        Assert.Equal(royaltiesEsperados, royaltiesCalculados);
    }

    [Fact]
    public void Mes_07_de_2023_com_uma_venda_de_1000_retorna_royalties_de_190()
    {
        int mes = 7;
        int ano = 2023;
        double royaltiesEsperados = 190;

        var listaFalsa = new List<Venda>(){new Venda(1, 1000)};

        var marionete = new Mock<VendaRepository>();

        marionete.Setup(x => x.ObterVendasPorMesEAno(ano, mes)).Returns(listaFalsa);

        double royaltiesCalculados = new CalculadoraRoyalties(marionete.Object).Calcular(mes, ano);

        Assert.Equal(royaltiesEsperados, royaltiesCalculados);
    }

    [Fact]
    public void Mes_08_de_2023_uma_venda_de_100000_retorna_royalties_de_18800()
    {
        int mes = 8;
        int ano = 2023;
        double royaltiesEsperados = 18800;

        var listaFalsa = new List<Venda>(){new Venda(1, 100000)};

        var marionete = new Mock<VendaRepository>();

        marionete.Setup(x => x.ObterVendasPorMesEAno(ano, mes)).Returns(listaFalsa);

        double royaltiesCalculados = new CalculadoraRoyalties(marionete.Object).Calcular(mes, ano);

        Assert.Equal(royaltiesEsperados, royaltiesCalculados);
    }

    [Fact]
    public void Mes_09_de_2023_com_uma_venda_de_1000_e_uma_de_100000_retorna_royalties_de_18990()
    {
        int mes = 9;
        int ano = 2023;
        double royaltiesEsperados = 18990;

        var listaFalsa = new List<Venda>(){new Venda(1, 1000), new Venda(2, 100000)};

        var marionete = new Mock<VendaRepository>();

        marionete.Setup(x => x.ObterVendasPorMesEAno(ano, mes)).Returns(listaFalsa);

        double royaltiesCalculados = new CalculadoraRoyalties(marionete.Object).Calcular(mes, ano);

        Assert.Equal(royaltiesEsperados, royaltiesCalculados);
    }

    [Fact]
    public void Mes_10_de_2023_com_uma_venda_de_5559_retorna_royalties_de_10_56()
    {
        int mes = 10;
        int ano = 2023;
        double royaltiesEsperados = 10.56;

        var listaFalsa = new List<Venda>(){new Venda(1, 55.59)};

        var marionete = new Mock<VendaRepository>();

        marionete.Setup(x => x.ObterVendasPorMesEAno(ano, mes)).Returns(listaFalsa);

        double royaltiesCalculados = new CalculadoraRoyalties(marionete.Object).Calcular(mes, ano);

        Assert.Equal(royaltiesEsperados, royaltiesCalculados);
    }
}