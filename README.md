# DIO - Trilha .NET - Fundamentos

Minha resolução para o desafio .NET Fundamentos, da DIO.

## Proposta

Você precisará construir uma classe chamada "Estacionamento", conforme o diagrama abaixo:
<br>
<br>
![Diagrama de classe estacionamento](diagrama_classe_estacionamento.png)

A classe contém três variáveis, sendo:

**precoInicial**: Tipo decimal. É o preço cobrado para deixar seu veículo estacionado.

**precoPorHora**: Tipo decimal. É o preço por hora que o veículo permanecer estacionado.

**veiculos**: É uma lista de string, representando uma coleção de veículos estacionados. Contém apenas a placa do veículo.

A classe contém três métodos, sendo:

**AdicionarVeiculo**: Método responsável por receber uma placa digitada pelo usuário e guardar na variável **veiculos**.

**RemoverVeiculo**: Método responsável por verificar se um determinado veículo está estacionado, e caso positivo, irá pedir a quantidade de horas que ele permaneceu no estacionamento. Após isso, realiza o seguinte cálculo: **precoInicial** \* **precoPorHora**, exibindo para o usuário.

**ListarVeiculos**: Lista todos os veículos presentes atualmente no estacionamento. Caso não haja nenhum, exibir a mensagem "Não há veículos estacionados".

Por último, deverá ser feito um menu interativo com as seguintes ações implementadas:

1. Cadastrar veículo
2. Remover veículo
3. Listar veículos
4. Encerrar

## Solução

Para resolver primeiramente criei loops com while que garatem que o usuário irá informar apenas valores que podem ser convertidos para decimal

```csharp

while (true)
{
    if(decimal.TryParse(Console.ReadLine(), out precoInicial))
    {
        Console.Write("Valor fixo: ");
        Console.WriteLine(precoInicial.ToString("C"));
        break;
    }
    else
    {
        Console.WriteLine("Por favor, digite um valor válido!");
    }
}

```

Usei o método decimal.TryParse num loop while. Se a entrada for válida, ele armazena o valor na variável precoInicial e então saí do loop. Caso a conversão não seja possível, ele repete o código novamente.

Então crei métodos para Adicionar, Remover e Listar veículos. Decidi ter uma abordagem no qual é criada uma lista, que adiciona um carro a uma vaga aleatória, verificando se o total de vagas já não foi preenchido (escolhi 5 vagas). Também implementei uma verfiicação para checar se o carro com placa inserida já não está estacionado.

```csharp

private List<(string Placa, int NumeroVaga)> _veiculosEstacionados = new List<(string, int)>();

public void AdicionarVeiculo()
{


    if (_veiculosEstacionados.Count >= 5)
    {
        Console.WriteLine("Todas as vagas estão ocupadas.");
        return;
    }
    else
    {

        Console.WriteLine("Digite a placa do veículo a ser estacionado");
        string placa = Console.ReadLine().ToUpper();

        if (_veiculosEstacionados.Exists(veiculo => veiculo.Placa == placa))
        {
            Console.WriteLine($"O carro com a placa {placa} já se encontra no estacionamento");

        }
        else
        {
            Random random = new Random();
            int numeroDaVaga;

            while (true)
            {
                numeroDaVaga = random.Next(1, 6);
                if (!_veiculosEstacionados.Exists(veiculo => veiculo.NumeroVaga == numeroDaVaga))
                    break;
            }

            _veiculosEstacionados.Add((placa, numeroDaVaga));
            Console.WriteLine($"O veículo com a placa \"{placa}\" foi estacionado na vaga nº {numeroDaVaga}.");
        }

    }

}

```

Em seguida fiz a mesma verificação de conferir se existe a placa informada na hora de retirar o veículo, retornando uma mensagem caso não encontre. Por fim, ao char o método para listagem de veículos, criei uma interação que para cada veículo na Lista, ele informe a placa e em que vaga se encontra estacionado.
