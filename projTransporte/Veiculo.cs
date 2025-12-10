using System;

namespace projTransporte
{
    internal class Veiculo
    {
        public int Id { get; set; }
        public int Capacidade { get; set; }
        public int QtdeTotalPassageiros { get; private set; }
        public bool EmViagem { get; private set; }

        public Veiculo(int id, int capacidade, int qtdePassageiros, bool emViagem)
        {
            Id = id;
            Capacidade = capacidade;
            QtdeTotalPassageiros = qtdePassageiros;
            EmViagem = emViagem;
        }

        // Construtor usado para pesquisa
        public Veiculo(int id) : this(id, 0, 0, false) { }

        public void IniciarViagem()
        {
            if (!EmViagem)
            {
                EmViagem = true;
            }
            else
            {
                Console.WriteLine("O veículo já está em viagem.");
            }
        }

        public void FinalizarViagem(int passageiros)
        {
            if (EmViagem)
            {
                if (passageiros <= Capacidade)
                {
                    QtdeTotalPassageiros += passageiros;
                    EmViagem = false;
                }
                else
                {
                    Console.WriteLine("Número de passageiros excede a capacidade do veículo!");
                }
            }
            else
            {
                Console.WriteLine("O veículo não está em viagem.");
            }
        }
    }
}
