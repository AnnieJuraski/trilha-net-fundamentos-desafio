using System.Numerics;

namespace DesafioFundamentos.Models
{
    
    public class Estacionamento
    {

        
        private List<(string Placa, int numeroVaga)> _veiculosEstacionados = new List<(string, int)>();
        private decimal PrecoInicial { get; set; }
        private decimal PrecoPorHora { get; set; }



        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            PrecoInicial = precoInicial;
            PrecoPorHora = precoPorHora;
        }


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
                    Random random = new();
                    int numeroDaVaga;

                    while (true)
                    {
                        numeroDaVaga = random.Next(1, 6);
                        if (!_veiculosEstacionados.Exists(veiculo => veiculo.numeroVaga == numeroDaVaga))
                            break;
                    }

                    _veiculosEstacionados.Add((placa, numeroDaVaga));
                    Console.WriteLine($"O veículo com a placa \"{placa}\" foi estacionado na vaga nº {numeroDaVaga}."); 
                }
                
            }        

        }

        public void RemoverVeiculo()
        {
            //Verifica primeiro se há veículos estacionados
            if(_veiculosEstacionados.Any())
            {
                
                Console.WriteLine("Digite a placa do veículo a ser removido");
                string placa = Console.ReadLine().ToUpper();

                //Em seguida verifico se há um veículo com a placa digitada
                if (_veiculosEstacionados.Exists(veiculo => veiculo.Placa == placa))
                {
                    Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado");

                    int qtdeHoras;
                    while (!int.TryParse(Console.ReadLine(), out qtdeHoras))
                    {
                        Console.WriteLine("Por favor, digite um número inteiro válido");                        
                    }

                    Console.WriteLine($"Preço Inicial: {PrecoInicial.ToString("C")}");
                    Console.WriteLine($"Preço por hora: {PrecoPorHora.ToString("C")}");

                    Console.WriteLine($"Total de horas: {qtdeHoras}h \n");

                    decimal valorTotal = qtdeHoras * PrecoPorHora + PrecoInicial;


                    var veiculoASerRemovido = _veiculosEstacionados.Find(v => v.Placa == placa);
                    _veiculosEstacionados.Remove(veiculoASerRemovido);

                    Console.WriteLine($"O veículo com a placa \"{veiculoASerRemovido.Placa}\" foi removido " +
                                         $"e a vaga de nº {veiculoASerRemovido.numeroVaga} está livre. \n" +
                                         $"O valor a ser pago é de {valorTotal.ToString("C")}");
                }
                else
                {
                    Console.WriteLine($"Veículo com placa {placa} não encontrado no estacionamento.");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados");
            }

        }

        public void ListarVeiculos()
        {
            if (_veiculosEstacionados.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");

                foreach(var veiculo in _veiculosEstacionados)
                {
                    Console.WriteLine($"O veículo com a placa \"{veiculo.Placa}\" está estacionado " +
                                         $"na vaga nº {veiculo.numeroVaga}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados");
            }

        }       

    }

}
