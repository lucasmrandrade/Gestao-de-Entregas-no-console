namespace GestaoDeEntregas.Modelos;

public class Rota
{
    public string IdPedido { get; set; }
    public string EnderecoEntrega { get; set; }
    public string DescricaoPedido { get; set; }

    public Rota(string idPedido, string enderecoEntrega, string descricaoPedido)
    {
        IdPedido = idPedido;
        EnderecoEntrega = enderecoEntrega;
        DescricaoPedido = descricaoPedido;
    }

    public void ExibirDetalhesRota()
    {
        Console.WriteLine($"   -> Pedido #{IdPedido}: {DescricaoPedido}");
        Console.WriteLine($"   -> Destino: {EnderecoEntrega}");
    }
}