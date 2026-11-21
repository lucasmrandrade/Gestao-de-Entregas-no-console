using GestaoDeEntregas.Modelos;
using GestaoDeEntregas.Menus;

Dictionary<string, Motoboy> motoboysRegistrados = new();


// dicionario de opcoes do menu 
Dictionary<int, Menu> opcoesMenu = new();
opcoesMenu.Add(1, new CadastroMotoboy());
opcoesMenu.Add(2, new AtribuirRotaMotoboy());
opcoesMenu.Add(3, new FinalizarEntregaMotoboy());
opcoesMenu.Add(4, new MenuExibirDetalhes());
opcoesMenu.Add(5, new FinalizaSistema());

void ExibirMensagemSistema()
{
    Console.WriteLine(@"
░
░██████╗░███████╗░██████╗████████╗░█████╗░░█████╗░  ██████╗░███████╗
██╔════╝░██╔════╝██╔════╝╚══██╔══╝██╔══██╗██╔══██╗  ██╔══██╗██╔════╝
██║░░██╗░█████╗░░╚█████╗░░░░██║░░░███████║██║░░██║  ██║░░██║█████╗░░
██║░░╚██╗██╔══╝░░░╚═══██╗░░░██║░░░██╔══██║██║░░██║  ██║░░██║██╔══╝░░
╚██████╔╝███████╗██████╔╝░░░██║░░░██║░░██║╚█████╔╝  ██████╔╝███████╗
░╚═════╝░╚══════╝╚═════╝░░░░╚═╝░░░╚═╝░░╚═╝░╚════╝░  ╚═════╝░╚══════╝

███████╗███╗░░██╗████████╗██████╗░███████╗░██████╗░░█████╗░░██████╗
██╔════╝████╗░██║╚══██╔══╝██╔══██╗██╔════╝██╔════╝░██╔══██╗██╔════╝
█████╗░░██╔██╗██║░░░██║░░░██████╔╝█████╗░░██║░░██╗░███████║╚█████╗░
██╔══╝░░██║╚████║░░░██║░░░██╔══██╗██╔══╝░░██║░░╚██╗██╔══██║░╚═══██╗
███████╗██║░╚███║░░░██║░░░██║░░██║███████╗╚██████╔╝██║░░██║██████╔╝
╚══════╝╚═╝░░╚══╝░░░╚═╝░░░╚═╝░░╚═╝╚══════╝░╚═════╝░╚═╝░░╚═╝╚═════╝░ ");
}

void ExibirOpcoesDoMenu()
{
        Console.Clear();
        ExibirMensagemSistema();
        Console.WriteLine("\n1 - Registrar motoboy");
        Console.WriteLine("2 - Atribuir rota / pedido a um motoboy");
        Console.WriteLine("3 - Finalizar entrega (liberar motoboy)");
        Console.WriteLine("4 - Painel geral (motoboys e rotas ativas)");
        Console.WriteLine("5 - Sair");

        Console.Write("\nDigite a sua opção: ");
        string opcaoEscolha = Console.ReadLine();

        int opcaoEscolhaNumerica = int.Parse(opcaoEscolha);

        if (opcoesMenu.ContainsKey(opcaoEscolhaNumerica))
        {
            opcoesMenu[opcaoEscolhaNumerica].Executar(motoboysRegistrados);
            if(opcaoEscolhaNumerica != 5) ExibirOpcoesDoMenu();
        }
        else
        {
            Console.WriteLine("\nOpção inválida!");
            Thread.Sleep(1000);
            ExibirOpcoesDoMenu(); // colocado no fluxo, pra voltar a escolha, fluxo a analisar pra melhoria 
        }
    }

ExibirOpcoesDoMenu();
