using System;
using System.Collections.Generic;
using System.Linq;

namespace projTransporte
{
    internal class SistemaDeTransporte
    {
        public List<Veiculo> VeiculoList { get; private set; } = new List<Veiculo>();
        public List<Garagem> GaragemList { get; private set; } = new List<Garagem>();
        public List<Viagem> ViagemList { get; private set; } = new List<Viagem>();
        public bool JornadaIniciada { get; private set; }

        public SistemaDeTransporte() { }

        public void CadastrarVeiculo(Veiculo veiculo)
        {
            if (!JornadaIniciada)
            {
                if (!VeiculoList.Any(v => v.Id == veiculo.Id))
                {
                    VeiculoList.Add(veiculo);
                    Console.WriteLine("Veículo adicionado com sucesso!");
                }
                else
                {
                    Console.WriteLine("Veículo já existe!");
                }
            }
            else
            {
                Console.WriteLine("Não é possível cadastrar veículos com a jornada iniciada.");
            }
        }

        public Veiculo PesquisarVeiculo(int id) =>
            VeiculoList.FirstOrDefault(v => v.Id == id);

        public void CadastrarGaragem(Garagem garagem)
        {
            if (!JornadaIniciada)
            {
                if (!GaragemList.Any(g => g.Id == garagem.Id))
                {
                    GaragemList.Add(garagem);
                    Console.WriteLine("Garagem adicionada com sucesso!");
                }
                else
                {
                    Console.WriteLine("Garagem já existe!");
                }
            }
            else
            {
                Console.WriteLine("Não é possível cadastrar garagens com a jornada iniciada.");
            }
        }

        public Garagem PesquisarGaragem(int id) =>
            GaragemList.FirstOrDefault(g => g.Id == id);

        public void IniciarJornada()
        {
            if (!JornadaIniciada)
            {
                if (VeiculoList.Count > 0 && GaragemList.Count >= 2)
                {
                    JornadaIniciada = true;
                    DistribuirVeiculosEntreGaragens();
                    Console.WriteLine("Jornada iniciada com sucesso!");
                }
                else
                {
                    Console.WriteLine("Não é possível iniciar a jornada sem veículos ou garagens suficientes.");
                }
            }
            else
            {
                Console.WriteLine("Jornada já está iniciada.");
            }
        }

        public void EncerrarJornada()
        {
            if (JornadaIniciada)
            {
                JornadaIniciada = false;
                Console.WriteLine("Jornada encerrada.");
                // TODO: implementar relatório se necessário
            }
            else
            {
                Console.WriteLine("Jornada ainda não foi iniciada.");
            }
        }

        public void LiberarViagem(Garagem origem, Garagem destino)
        {
            if (origem.Veiculos.Count > 0)
            {
                var veiculo = origem.RemoverVeiculo();
                if (veiculo != null)
                {
                    veiculo.IniciarViagem();
                    var viagem = new Viagem(origem, destino, veiculo.Capacidade);
                    ViagemList.Add(viagem);
                    Console.WriteLine($"Viagem do veículo {veiculo.Id} liberada de {origem.Nome} para {destino.Nome}.");
                }
            }
            else
            {
                Console.WriteLine("Nenhum veículo disponível na garagem de origem.");
            }
        }

        public void ListarVeiculosNaGaragem(Garagem garagem)
        {
            Garagem garagemPesquisada = PesquisarGaragem(garagem.Id);
            if (garagemPesquisada != null)
                garagemPesquisada.ListarVeiculos();
            else
                Console.WriteLine("Garagem não encontrada.");
        }

        public int QuantidadeDeViagens(Garagem origem, Garagem destino) =>
            ViagemList.Count(v => v.Origem == origem && v.Destino == destino);

        public int QuantidadeDePassageiros(Garagem origem, Garagem destino) =>
            ViagemList.Where(v => v.Origem == origem && v.Destino == destino)
                      .Sum(v => v.Passageiros);

        public void ListarViagens(Garagem origem, Garagem destino)
        {
            var viagens = ViagemList.Where(v => v.Origem == origem && v.Destino == destino);
            foreach (var viagem in viagens)
            {
                Console.WriteLine(viagem.ToString());
            }
        }

        private void DistribuirVeiculosEntreGaragens()
        {
            var garagem1 = GaragemList[0];
            var garagem2 = GaragemList[1];
            int i = 0;

            foreach (var veiculo in VeiculoList)
            {
                if (i % 2 == 0)
                    garagem1.AdicionarVeiculo(veiculo);
                else
                    garagem2.AdicionarVeiculo(veiculo);
                i++;
            }

            Console.WriteLine("Veículos distribuídos entre as garagens.");
        }
    }
}
