using System;
using GestaoDeEntregas.Modelos;
using GestaoDeEntregas.Repositorio;
namespace GestaoDeEntregas.Menus;

internal class CadastroMotoboy : Menu
{
    // como menu herda a classe cadastro, criei ele privado apenas pra clase 
    // aos poucos a tendencia e eliminar a busca dicionario e depender menos da memoria 
    private IMotoboyRepositorio MotoboyRepositorio { get; }

    public CadastroMotoboy(IMotoboyRepositorio motoboyRepositorio)
    {
        MotoboyRepositorio = motoboyRepositorio;
    }

    public override void Executar(Dictionary<string, Motoboy> motoboysRegistrados)
    {
        base.Executar(motoboysRegistrados);

        bool continuarCadastrando = true;

        while (continuarCadastrando)
        {
            Console.Clear();
            ExibirTituloOpcoes("Registro de Motoboys");

            Console.Write("Digite o nome do motoboy: ");
            string nome = Console.ReadLine()!.Trim().ToUpper();

            Console.Write("Digite o número de telefone: ");
            string telefone = Console.ReadLine()!.Trim();

            // se existir espaco vazio e o usuario dar enter da como invalido 
            if (!string.IsNullOrWhiteSpace(nome))
            {
                // busca pela interface, o metodo buscar por nome se retornar null deixa cadastrar 
                if (MotoboyRepositorio.BuscarPorNome(nome) == null)
                {
                    Motoboy novoMotoboy = new(nome, telefone);
                    motoboysRegistrados.Add(nome, novoMotoboy);
                    Console.WriteLine($"\nMotoboy {nome} registrado com sucesso!");
                }
                else // ele encontrou
                {
                    Console.WriteLine($"\nO motoboy '{nome}' já está registrado!");
                }
            }
            else // validacao do string nome
            {
                Console.WriteLine("\nNome inválido. Nenhum motoboy foi registrado.");
            }

            Console.Write("\nDeseja cadastrar outro motoboy? (S/N): ");
            continuarCadastrando = Console.ReadLine()!.Trim().ToUpper() == "S";
        }
    }
}
