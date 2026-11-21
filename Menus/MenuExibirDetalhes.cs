using System;
using GestãoDeMotoboy.Modelos;
namespace GestãoDeMotoboy.Menus;

internal class MenuExibirDetalhes : Menu 
{
    public override void Executar(Dictionary<string, Motoboy> motoboysRegistrados)
    {
        base.Executar(motoboysRegistrados);
            ExibirTituloOpcoes("Painel Geral de Operações");

            if (motoboysRegistrados.Count == 0) // valida se ele esta cadastrado
            {
                Console.WriteLine("Nenhum motoboy cadastrado no momento.");
            }
            else
            {
                foreach (var motoboy in motoboysRegistrados.Values) // se tiver, vai exibir o painel que esta na class motoboy
                {
                    motoboy.ExibirPainel();
                }
            }

            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal...");
            Console.ReadKey();
        }
    }
