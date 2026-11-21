using System;
using GestãoDeMotoboy.Modelos;
namespace GestãoDeMotoboy.Menus;

internal class CadastroMotoboy : Menu
{
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

            // verifica no dicionario se ele existe, se nao ele parte pra cadastro
            if (!string.IsNullOrWhiteSpace(nome))
            {
                if (!motoboysRegistrados.ContainsKey(nome))
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
