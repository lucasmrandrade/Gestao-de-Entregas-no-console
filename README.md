Gestão de Entregas

Aplicativo de console em C# para controlar entregas feitas por motoboys: cadastrar motoboys, atribuir rotas/pedidos, finalizar entregas e acompanhar quem está disponível, em rota ou voltando para a base.

Objetivo

Substituir o controle manual de entregas por um sistema simples, em que a pessoa responsável pela base consegue ver, em um só lugar, quem está livre e quem está em entrega.

Funcionalidades
Opção	Ação
1	Registrar motoboy
2	Atribuir rota / pedido a um motoboy
3	Finalizar entrega (liberar motoboy)
4	Painel geral (motoboys e rotas ativas)
5	Sair

Depois de cada ação, o programa volta ao menu. A opção 5 encerra o sistema.

Status do motoboy
Disponível na Base: livre para receber uma rota (status padrão ao cadastrar)
Em Rota de Entrega: está fazendo uma entrega
Retornando para a Base: terminou a entrega e está voltando
Tecnologias
C#
.NET 10
Aplicação de console
Como executar
Pelo executável
Baixe o GestaoDeEntregas.exe.
Dê um duplo clique para abrir.

Como o executável não tem assinatura digital, o Windows pode mostrar a tela "O Windows protegeu o seu computador". Clique em Mais informações e depois em Executar assim mesmo.

Pelo código-fonte

Pré-requisito: .NET SDK 10.

git clone <url-do-repositorio>
cd GestaoDeEntregas
dotnet run
Gerar o executável
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true

O arquivo fica em bin\Release\net10.0\win-x64\publish\.

Estrutura do projeto
GestaoDeEntregas/
├── Program.cs                     # Ponto de entrada: monta o menu e controla o fluxo
├── Modelos/
│   ├── Motoboy.cs
│   └── Rotas.cs
└── Menus/
    ├── Menu.cs                    # Classe base
    ├── CadastroMotoboy.cs         # Opção 1
    ├── AtribuirRotaMotoboy.cs     # Opção 2
    ├── FinalizarEntregaMotoboy.cs # Opção 3
    ├── MenuExibirDetalhes.cs      # Opção 4
    └── FinalizaSistema.cs         # Opção 5
Como funciona
Os motoboys ficam em um dicionário em memória (Dictionary<string, Motoboy>), com o nome como chave. Os dados existem só enquanto o programa está aberto.
Cada opção do menu é uma classe que herda de Menu e implementa o método Executar.
O Program.cs liga o número digitado à classe correspondente por meio de um dicionário (Dictionary<int, Menu>).

Para adicionar uma nova opção: crie uma classe que herde de Menu, registre-a no dicionário com um novo número e inclua o texto dela no menu.

Próximos passos
Console (etapa atual)
API
Banco de dados