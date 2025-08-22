using System;
using System.Collections.Generic;
using System.Linq;


abstract class Veiculo
{
    public string Nome { get; protected set; }
    public int Velocidade { get; protected set; } 

    protected Veiculo(string nome, int velocidade)
    {
        Nome = nome;
        Velocidade = velocidade;
    }

    
    public abstract void Mover();
}


class Carro : Veiculo
{
    public Carro(string nome, int velocidade) : base(nome, velocidade) { }
    public override void Mover() => Console.WriteLine($"{Nome}: Vruuummmm!");
}
class Bicicleta : Veiculo
{
    public Bicicleta(string nome, int velocidade) : base(nome, velocidade) { }
    public override void Mover() => Console.WriteLine($"{Nome}: Pedalando...");
}
class Program
{
    static void Main()
    {
        
        var veiculos = new List<Veiculo>
        {
            new Carro("Carro", 180),
            new Bicicleta("Bicicleta", 35),
        };

        Console.WriteLine("=== Corrida de Veículos (Herança + Polimorfismo) ===\n");

        
        ImprimirMenu(veiculos);

       
        int i1 = LerIndice("Escolha o 1º veículo (número): ", veiculos.Count);
        int i2 = LerIndice("Escolha o 2º veículo (número): ", veiculos.Count, proibido: i1);

        var v1 = veiculos[i1];
        var v2 = veiculos[i2];

        Console.WriteLine($"\nVeículos escolhidos: {v1.Nome} vs {v2.Nome}\n");

        
        v1.Mover();
        v2.Mover();

        
        Console.WriteLine();
        if (v1.Velocidade == v2.Velocidade)
            Console.WriteLine("Empate técnico! Mesma velocidade máxima teórica.");
        else
        {
            var vencedor = v1.Velocidade > v2.Velocidade ? v1 : v2;
            Console.WriteLine($"Vencedor (por velocidade): {vencedor.Nome} ({vencedor.Velocidade} km/h)");
        }
    }

    static void ImprimirMenu(List<Veiculo> veiculos)
    {
        Console.WriteLine("Escolha dois veículos para competir:");
        for (int i = 0; i < veiculos.Count; i++)
            Console.WriteLine($"{i} - {veiculos[i].Nome} (Velocidade: {veiculos[i].Velocidade} km/h)");
        Console.WriteLine();
    }

    static int LerIndice(string prompt, int tamanho, int? proibido = null)
    {
        while (true)
        {
            Console.Write(prompt);
            var entrada = Console.ReadLine();

            if (int.TryParse(entrada, out int idx) && idx >= 0 && idx < tamanho && idx != proibido)
                return idx;

            if (proibido.HasValue && int.TryParse(entrada, out idx) && idx == proibido.Value)
                Console.WriteLine("Você já escolheu esse veículo. Selecione outro.\n");
            else
                Console.WriteLine("Entrada inválida. Tente novamente.\n");
        }
    }
}
