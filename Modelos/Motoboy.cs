namespace GestãoDeMotoboy.Modelos;

public class Motoboy
{
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public Rota? RotaAtual { get; private set; }

    // Propriedades calculadas (sem duplicidade)
    public bool EstaDisponivel => RotaAtual == null;
    public string StatusAtual => EstaDisponivel ? "Disponível na Base" : "Em Rota de Entrega";

    public Motoboy(string nome, string telefone)
    {
        Nome = nome;
        Telefone = telefone;
        RotaAtual = null;
    }

    public void AtribuirRota(Rota novaRota)
    {
        RotaAtual = novaRota;
    }

    public void FinalizarRota()
    {
        RotaAtual = null;
    }

    public void ExibirPainel()
    {
        Console.WriteLine($"\nMotoboy: {Nome} | Tel: {Telefone} | Status: [{StatusAtual}]");

        if (RotaAtual != null)
        {
            RotaAtual.ExibirDetalhesRota();
        }
    }
}