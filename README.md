# Gestão de Motoboys

Aplicativo de console em C# para controlar motoboys e entregas: cadastrar motoboys, atribuir rotas/pedidos, finalizar entregas e acompanhar quem está disponível, em rota ou voltando para a base.

## Objetivo

Substituir o controle manual de motoboys por um sistema simples, em que a pessoa responsável pela base consegue ver, em um só lugar, quem está livre e quem está em entrega.

## Como usar

Ao abrir o programa, aparece o banner do sistema e o menu principal:

| Opção | Ação |
|---|---|
| 1 | Registrar motoboy |
| 2 | Atribuir rota / pedido a um motoboy |
| 3 | Finalizar entrega (liberar motoboy) |
| 4 | Painel geral (motoboys e rotas ativas) |
| 5 | Sair |

Digite o número da opção e pressione Enter. Depois de cada ação, o programa volta ao menu. A opção 5 encerra o sistema.

### Fluxo de uso típico

1. **Registrar** o motoboy (nome e telefone). Ele entra no sistema com o status **Disponível na Base**.
2. **Atribuir uma rota/pedido** a ele, informando o pedido, o endereço e a descrição.
3. Acompanhar pelo **Painel geral** quais motoboys estão ocupados e quais rotas estão ativas.
4. **Finalizar a entrega** quando o motoboy concluir, liberando-o para uma nova rota.

## Status do motoboy

Cada motoboy tem um status que indica em que etapa ele está:

- **Disponível na Base**: livre para receber uma rota (status padrão ao cadastrar)
- **Em Rota de Entrega**: está fazendo uma entrega
- **Retornando para a Base**: terminou a entrega e está voltando

## Estrutura do projeto

```
GestãoDeMotoboys/
├── Program.cs          # Ponto de entrada: monta o menu e controla o fluxo
├── Modelos/            # Dados do sistema
│   ├── Motoboy.cs
│   └── Rota.cs
└── Menus/              # Uma classe por opção do menu
    ├── Menu.cs                    # Classe base
    ├── CadastroMotoboy.cs         # Opção 1
    ├── AtribuirRotaMotoboy.cs     # Opção 2
    ├── FinalizarEntregaMotoboy.cs # Opção 3
    ├── MenuExibirDetalhes.cs      # Opção 4
    └── FinalizaSistema.cs         # Opção 5
```

Namespaces: `GestãoDeMotoboy.Modelos` e `GestãoDeMotoboy.Menus`.

## Como o sistema é organizado

### Modelos

- **Motoboy**: representa um motoboy, com nome (`nomeDoMotoboy`), telefone (`telefone`) e status (`status`). O status começa como "Disponível na Base". Também tem métodos para exibir as informações do motoboy e alterar o status.
- **Rota**: representa uma entrega, com o id do pedido (`idPedido`), o endereço e a descrição.

### Armazenamento dos dados

Os motoboys ficam em um dicionário em memória, criado no `Program.cs`:

```csharp
Dictionary<string, Motoboy> motoboysRegistrados = new();
```

A chave é o nome do motoboy e o valor é o objeto `Motoboy`. Esse mesmo dicionário é passado para todas as opções do menu, então todas trabalham sobre os mesmos dados.

> Os dados existem só enquanto o programa está aberto. Ao fechar, o cadastro é perdido. A gravação em banco de dados está prevista para uma etapa futura.

### Menus

Cada opção do menu é uma classe própria que herda da classe base `Menu`. A base cuida do que é comum a todas (como limpar a tela e exibir o título da opção), e cada classe implementa o seu próprio `Executar`.

No `Program.cs`, as opções ficam registradas em um dicionário, ligando o número digitado à classe correspondente:

```csharp
Dictionary<int, Menu> opcoesMenu = new();
opcoesMenu.Add(1, new CadastroMotoboy());
opcoesMenu.Add(2, new AtribuirRotaMotoboy());
opcoesMenu.Add(3, new FinalizarEntregaMotoboy());
opcoesMenu.Add(4, new MenuExibirDetalhes());
opcoesMenu.Add(5, new FinalizaSistema());
```

Como todas herdam de `Menu`, o programa executa qualquer opção do mesmo jeito:

```csharp
opcoesMenu[numero].Executar(motoboysRegistrados);
```

**Para adicionar uma nova opção:** crie uma classe que herde de `Menu`, implemente o `Executar`, adicione-a ao dicionário com um novo número e inclua o texto dela no menu.

### Fluxo do programa

1. O programa cria os dicionários de motoboys e de opções do menu.
2. `ExibirOpcoesDoMenu()` limpa a tela, mostra o banner e as opções, e lê o número digitado.
3. Se o número existe em `opcoesMenu`, executa a classe correspondente.
4. Depois da execução, o menu é exibido novamente, exceto quando a opção escolhida é a 5 (Sair), que encerra o programa.

## Tecnologias

- C# com top-level statements
- Aplicação de console (.NET)

## Roadmap

1. **Console** (etapa atual)
2. **API**
3. **Banco de dados**