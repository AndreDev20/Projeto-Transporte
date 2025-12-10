using System;

namespace projTransporte
{
    internal class Viagem
    {
        public Garagem Origem { get; private set; }
        public Garagem Destino { get; private set; }
        public int Passageiros { get; private set; }
        public DateTime DataHora { get; private set; }

        public Viagem(Garagem origem, Garagem destino, int passageiros)
        {
            if (passageiros < 0)
                throw new ArgumentException("Número de passageiros não pode ser negativo.");

            Origem = origem;
            Destino = destino;
            Passageiros = passageiros;
            DataHora = DateTime.Now;
        }

        public override string ToString()
        {
            return $"Origem: {Origem.Nome}, Destino: {Destino.Nome}, Passageiros: {Passageiros}, Data/Hora: {DataHora}";
        }
    }
}
