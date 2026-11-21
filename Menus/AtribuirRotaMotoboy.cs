using System;
using GestãoDeMotoboy.Modelos;
namespace GestãoDeMotoboy.Menus;

internal class AtribuirRotaMotoboy : Menu // herda de menu
{
    public override void Executar(Dictionary<string, Motoboy> motoboysRegistrados)
    {

        base.Executar(motoboysRegistrados);

        ExibirTituloOpcoes("Atribuir Rota de Entrega");

        if (motoboysRegistrados.Count == 0)
        {
            Console.WriteLine("Nenhum motoboy cadastrado no sistema.");
            Thread.Sleep(1500);
            return;
        }

        // Lista rapidamente quem está livre para facilitar a escolha
        Console.WriteLine("Motoboys disponíveis na base:");
        var disponiveis = motoboysRegistrados.Values.Where(m => m.EstaDisponivel).ToList();
        if (disponiveis.Count == 0)
        {
            Console.WriteLine("-> Nenhum motoboy livre no momento! Todos estão em rota.");
            Console.WriteLine("\nPressione qualquer tecla para voltar...");
            Console.ReadKey();
            return;
        }

        // valida o motoboy na lista pelo nome
        foreach (var m in disponiveis)
        {
            Console.WriteLine($"- {m.Nome}");
        }

        Console.Write("\nDigite o nome do motoboy que fará a entrega: ");
        string nome = Console.ReadLine()!.Trim().ToUpper();

        if (motoboysRegistrados.TryGetValue(nome, out Motoboy? motoboy))
        {
            if (!motoboy.EstaDisponivel)
            {
                Console.WriteLine($"\nO motoboy {motoboy.Nome} já está em uma rota ativa!");
            }
            else
            {
                Console.Write("Número / ID do Pedido: ");
                string idPedido = Console.ReadLine()!.Trim();

                Console.Write("Descrição do Pedido (ex: 2x X-Tudo): ");
                string descricao = Console.ReadLine()!.Trim();

                Console.Write("Endereço de Entrega: ");
                string endereco = Console.ReadLine()!.Trim();

                Rota novaRota = new(idPedido, endereco, descricao);
                motoboy.AtribuirRota(novaRota);

                Console.WriteLine($"\nRota vinculada! {motoboy.Nome} saiu para entrega do pedido #{idPedido}.");
            }
        }
        else
        {
            Console.WriteLine("\nMotoboy não encontrado!");
        }

        Thread.Sleep(2000);
    }
}
