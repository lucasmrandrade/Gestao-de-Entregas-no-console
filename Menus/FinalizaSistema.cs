using System;
using GestãoDeMotoboy.Modelos;
namespace GestãoDeMotoboy.Menus;

internal class FinalizaSistema : Menu
{
    public override void Executar(Dictionary<string, Motoboy> motoboysRegistrados)
    {
        base.Executar(motoboysRegistrados);
        Console.WriteLine("Encerrado a execução!");
        Thread.Sleep(1000);
    }
}
