using System;

namespace projTransporte
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SistemaDeTransporte sistema = new SistemaDeTransporte();
            int opcao;

            do
            {
                Console.WriteLine("\nMenu de opções:" +
                    "\n0. Finalizar" +
                    "\n1. Cadastrar veículo" +
                    "\n2. Cadastrar garagem" +
                    "\n3. Iniciar jornada" +
                    "\n4. Encerrar jornada" +
                    "\n5. Liberar viagem (origem → destino)" +
                    "\n6. Listar veículos em determinada garagem" +
                    "\n7. Informar quantidade de viagens (origem → destino)" +
                    "\n8. Listar viagens (origem → destino)" +
                    "\n9. Informar quantidade de passageiros transportados (origem → destino)" +
                    "\nEscolha a opção desejada: ");

                string inputOpcao = Console.ReadLine();
                if (!int.TryParse(inputOpcao, out opcao))
                {
                    Console.WriteLine("Entrada inválida!");
                    continue;
                }

                switch (opcao)
                {
                    case 0:
                        Console.WriteLine("Encerrando programa...");
                        break;

                    case 1:
                        Console.WriteLine("Digite o ID do veículo:");
                        int idVeiculo = int.Parse(Console.ReadLine());
                        Console.WriteLine("Digite a capacidade do veículo:");
                        int capacidade = int.Parse(Console.ReadLine());
                        sistema.CadastrarVeiculo(new Veiculo(idVeiculo, capacidade, 0, false));
                        break;

                    case 2:
                        Console.WriteLine("Digite o ID da garagem:");
                        int idGaragem = int.Parse(Console.ReadLine());
                        Console.WriteLine("Digite o nome da garagem:");
                        string nomeGaragem = Console.ReadLine();
                        sistema.CadastrarGaragem(new Garagem(idGaragem, nomeGaragem));
                        break;

                    case 3:
                        sistema.IniciarJornada();
                        break;

                    case 4:
                        sistema.EncerrarJornada();
                        break;

                    case 5:
                        Console.WriteLine("Digite o ID da garagem de origem:");
                        int idOrigem = int.Parse(Console.ReadLine());
                        Console.WriteLine("Digite o ID da garagem de destino:");
                        int idDestino = int.Parse(Console.ReadLine());
                        var origem = sistema.PesquisarGaragem(idOrigem);
                        var destino = sistema.PesquisarGaragem(idDestino);
                        if (origem != null && destino != null)
                            sistema.LiberarViagem(origem, destino);
                        else
                            Console.WriteLine("Origem ou destino inválidos.");
                        break;

                    case 6:
                        Console.WriteLine("Digite o ID da garagem:");
                        int idG = int.Parse(Console.ReadLine());
                        var garagem = sistema.PesquisarGaragem(idG);
                        if (garagem != null)
                            sistema.ListarVeiculosNaGaragem(garagem);
                        else
                            Console.WriteLine("Garagem não encontrada.");
                        break;

                    case 7:
                        Console.WriteLine("Digite o ID da garagem de origem:");
                        int idO = int.Parse(Console.ReadLine());
                        Console.WriteLine("Digite o ID da garagem de destino:");
                        int idD = int.Parse(Console.ReadLine());
                        var gOrigem = sistema.PesquisarGaragem(idO);
                        var gDestino = sistema.PesquisarGaragem(idD);
                        if (gOrigem != null && gDestino != null)
                            Console.WriteLine($"Quantidade de viagens: {sistema.QuantidadeDeViagens(gOrigem, gDestino)}");
                        else
                            Console.WriteLine("Origem ou destino inválidos.");
                        break;

                    case 8:
                        Console.WriteLine("Digite o ID da garagem de origem:");
                        int idO2 = int.Parse(Console.ReadLine());
                        Console.WriteLine("Digite o ID da garagem de destino:");
                        int idD2 = int.Parse(Console.ReadLine());
                        var gOrigem2 = sistema.PesquisarGaragem(idO2);
                        var gDestino2 = sistema.PesquisarGaragem(idD2);
                        if (gOrigem2 != null && gDestino2 != null)
                            sistema.ListarViagens(gOrigem2, gDestino2);
                        else
                            Console.WriteLine("Origem ou destino inválidos.");
                        break;

                    case 9:
                        Console.WriteLine("Digite o ID da garagem de origem:");
                        int idO3 = int.Parse(Console.ReadLine());
                        Console.WriteLine("Digite o ID da garagem de destino:");
                        int idD3 = int.Parse(Console.ReadLine());
                        var gOrigem3 = sistema.PesquisarGaragem(idO3);
                        var gDestino3 = sistema.PesquisarGaragem(idD3);
                        if (gOrigem3 != null && gDestino3 != null)
                            Console.WriteLine($"Passageiros transportados: {sistema.QuantidadeDePassageiros(gOrigem3, gDestino3)}");
                        else
                            Console.WriteLine("Origem ou destino inválidos.");
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            } while (opcao != 0);
        }
    }
}
