using System;
using System.Collections.Generic;
using System.Linq;

namespace projTransporte
{
    internal class Garagem
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        internal Stack<Veiculo> Veiculos { get; private set; }

        public Garagem(int id, string nome)
        {
            Id = id;
            Nome = nome;
            Veiculos = new Stack<Veiculo>();
        }

        public Garagem(int id) : this(id, "") { }

        public Garagem() : this(-1, "") { }

        public bool AdicionarVeiculo(Veiculo v)
        {
            // Evita duplicidade de veículos pelo Id
            if (Veiculos.Any(veiculo => veiculo.Id == v.Id))
                return false;

            Veiculos.Push(v);
            return true;
        }

        public Veiculo RemoverVeiculo()
        {
            return Veiculos.Count > 0 ? Veiculos.Pop() : null;
        }

        public void ListarVeiculos()
        {
            if (Veiculos.Count == 0)
            {
                Console.WriteLine("Nenhum veículo na garagem.");
                return;
            }

            foreach (var veiculo in Veiculos)
            {
                Console.WriteLine(
                    $"Id: {veiculo.Id} | " +
                    $"Capacidade: {veiculo.Capacidade} | " +
                    $"Passageiros: {veiculo.QtdeTotalPassageiros} | " +
                    $"Estado: {(veiculo.EmViagem ? "Em viagem" : "Repouso")}"
                );
            }
        }
    }
}
