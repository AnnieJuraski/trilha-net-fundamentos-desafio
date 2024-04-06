using DesafioFundamentos.Models;


// Coloca o encoding para UTF8 para exibir acentuação
Console.OutputEncoding = System.Text.Encoding.UTF8;

decimal precoInicial;
decimal precoPorHora;



Console.WriteLine("Seja bem vindo ao sistema de estacionamento!\n" +     
                      "Digite o preço inicial:");


while (!decimal.TryParse(Console.ReadLine(), out precoInicial))    
{
    Console.WriteLine("Por favor, digite um valor válido!");
}

Console.WriteLine("Agora digite o valor do preço por hora");

while (!decimal.TryParse(Console.ReadLine(), out precoPorHora))
{
    Console.WriteLine("Por favor, digite um valor válido!");
}

Estacionamento meuEstacionamento = new Estacionamento(precoInicial, precoPorHora);


bool exibirMenu = true;


while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("Digite a sua opção:");
    Console.WriteLine("1 - Cadastrar veículo");
    Console.WriteLine("2 - Remover veículo");
    Console.WriteLine("3 - Listar veículos");
    Console.WriteLine("4 - Encerrar");



    switch (Console.ReadLine())
    {
        case "1":
            meuEstacionamento.AdicionarVeiculo();
            break;

        case "2":
            meuEstacionamento.RemoverVeiculo();
            break;

        case "3":
            meuEstacionamento.ListarVeiculos();
            break;

        case "4":
            exibirMenu = false;
            break;

        default:
            Console.WriteLine("Opção inválida");
            break;
    }

    Console.WriteLine("Pressione uma tecla para continuar");
    Console.ReadKey();
    Console.Clear();
}

Console.WriteLine("O programa se encerrou");

