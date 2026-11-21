using System;
using GestaoDeEntregas.Modelos;
namespace GestaoDeEntregas.Menus;



internal class Menu()
{
    public void ExibirTituloOpcoes(string titulo)
    {
        int quantidadeDeLetras = titulo.Length;
        string caractereTitulo = string.Empty.PadLeft(quantidadeDeLetras, '*');
        Console.WriteLine(caractereTitulo);
        Console.WriteLine(titulo);
        Console.WriteLine(caractereTitulo + "\n");
    }

    public virtual void Executar(Dictionary<string, Motoboy> motoboysRegistrados)
    {
        Console.Clear();
    }
}
