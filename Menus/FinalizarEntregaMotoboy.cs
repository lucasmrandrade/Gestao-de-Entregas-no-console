using System;
using GestãoDeMotoboy.Modelos;
namespace GestãoDeMotoboy.Menus;

internal class FinalizarEntregaMotoboy : Menu  
{
	public override void Executar(Dictionary<string, Motoboy> motoboysRegistrados)
	{
        base.Executar(motoboysRegistrados);
        ExibirTituloOpcoes("Finalizar Entrega");

        var emRota = motoboysRegistrados.Values.Where(m => !m.EstaDisponivel).ToList();

        if (emRota.Count == 0)
        {
            Console.WriteLine("Nenhum motoboy está em rota de entrega no momento.");
            Thread.Sleep(1500);
            return;
        }

        Console.WriteLine("Motoboys atualmente em rota:");
        // verifica se o motoboy esta em rota pra finalizar 
        foreach (var m in emRota)
        {
            Console.WriteLine($"- {m.Nome} (Pedido #{m.RotaAtual!.IdPedido} -> {m.RotaAtual.EnderecoEntrega})");
        }

        Console.Write("\nDigite o nome do motoboy que concluiu a entrega: ");
        string nome = Console.ReadLine()!.Trim().ToUpper();

        if (motoboysRegistrados.TryGetValue(nome, out Motoboy? motoboy) && !motoboy.EstaDisponivel)
        {
            string pedidoConcluido = motoboy.RotaAtual!.IdPedido;
            motoboy.FinalizarRota();
            Console.WriteLine($"\nPedido #{pedidoConcluido} finalizado! {motoboy.Nome} está disponível na base novamente.");
        }
        else
        {
            Console.WriteLine("\nMotoboy não encontrado ou não possui rota ativa.");
        }

        Thread.Sleep(2000);


    }
}
