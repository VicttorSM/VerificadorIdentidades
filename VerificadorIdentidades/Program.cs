using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using VerificadorIdentidades.Model;

namespace VerificadorIdentidades
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Public\Verificador Identidades Base\BASE.txt";
            List<string> lines = File.ReadAllLines(path).Select(x => x.Trim()).Where(x => !string.IsNullOrEmpty(x)).ToList();
            Console.WriteLine($"CPFs para serem avaliados: {lines.Where(x => x.Length == 9).Count()}");
            Console.WriteLine($"CNPJs para serem avaliados: {lines.Where(x => x.Length == 12).Count()}");
            Console.WriteLine($"Total de identidades para serem avaliadas: {lines.Count}");

            VerificadorIdentidades verificador = new VerificadorIdentidades(lines);

            for (int i = 1; i <= 8; i++)
            {
                Stopwatch sw = new Stopwatch();
                Console.WriteLine($"Rodando com {i} {(i != 1 ? "threads" : "thread")}...");
                sw.Start();
                verificador.VerificarIdentidades(i);
                sw.Stop();
                Console.WriteLine($"Terminado com {i} threads em {sw.ElapsedMilliseconds} milissegundos.");
            }
            Console.ReadLine();
        }
    }
}
