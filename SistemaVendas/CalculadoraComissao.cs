namespace SistemaVendas;

public class CalculadoraComissao
{
    public double Calcular(double p)
    {
        var comissao = 0.0;
        if (p >= 0 && p < 10000)
        {
            comissao = p * 0.05;
        }
        else
        {
            comissao = p * 0.06;
        }

        return Math.Floor(comissao * 100) / 100;
    }
}
