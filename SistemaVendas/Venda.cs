namespace SistemaVendas;

public class Venda
{
    public Venda(int id, double valor)
    {
        this.Id = id;
        this.Valor = valor;
    }

    public int Id { get; }
    public double Valor{ get; }
}
