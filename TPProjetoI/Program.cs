using System;
using System.IO; // Necessário para ler e escrever arquivos
using static System.Console;
using static Utilitarios;

namespace TPProjetoI
{
    class Program
    {
        private static void SeletorDeOpcoes()
        {
            int opcao;

            do
            {
                Clear();
                WritePos(10, 0, "TP - Projeto I");

                WritePos(2, 2, "1 – Estatística de uma lista de valores lidos de um arquivo texto");
                WritePos(2, 3, "2 – MMC entre dois valores digitados");
                WritePos(2, 4, "3 – Raiz Cúbica de um valor digitado");
                WritePos(2, 5, "4 – MDC por subtrações sucessivas");
                WritePos(2, 6, "5 – Lista de números de Fibonacci");
                WritePos(2, 7, "6 – Seno Hiperbólico");

                WritePos(2, 20, "99 – Terminar o programa");

                WritePos(2, 22, "Opção: ");
                opcao = int.Parse(ReadLine());

                switch (opcao)
                {
                    case 1: LerArquivo(); break;
                    case 2: CalcularMMC(); break;
                    case 3: AproximacaoDaRaizCubica(); break;
                    case 4: break;
                    case 5: ListarFibonacci(); break;
                    case 6: break;
                }
            }
            while (opcao != 99);
        }

        private static void LerArquivo()
        {
            Clear();
            var reader = new StreamReader(@"..\..\..\file.txt");
            while (!reader.EndOfStream)
            {
                string linhaLida = reader.ReadLine();
                double v = double.Parse(linhaLida.Substring(0, 8));
                double p = double.Parse(linhaLida.Substring(8, 8));

                var mat = new MatematicaDouble(v);
                WriteLine($"RMQ = {mat.RaizMediaQuad(p)}");

                WriteLine($"MA = {mat.Media}");

                ReadKey();
            }
            EsperarEnter();
        }

        private static void CalcularMMC()
        {
            Clear();
            WritePos(2, 1, "Insira o primeiro valor: ");
            int a = int.Parse(ReadLine());
            WritePos(2, 2, "Insira o segundo valor: ");
            int b = int.Parse(ReadLine());
            var mat = new Matematica(a);

        }

        private static void AproximacaoDaRaizCubica()
        {
            Clear();
            WritePos(5, 1, "Aproximação de raíz cúbica");
            WritePos(2, 3, "Digite o a ser calculado: ");
            int valor = int.Parse(ReadLine()); // Recebendo o valor a ser calculado
            WritePos(2, 4, "Digite o margem de erro: ");
            double margem = double.Parse(ReadLine());  // Recebendo a margem de erro
            if (margem >= 0.06 || margem < 0.01) // Verificando se a margem corresponde a um valor menor que 0,06
            {
                WritePos(2, 6, "Valor da margem inválido.");
                EsperarEnter();
            }
            else
            {
                var mat = new Matematica(valor); // Instanciado um objeto da classe Matematica
                WritePos(2, 6, $"O valor aproximado da raíz cúbica de {valor} é {mat.AproximacaoRaizCubica(margem)}");
                EsperarEnter();
            }

        }

        private static void ListarFibonacci()
        {
            Clear();
            WritePos(2, 2, "Insira a quantidade desejada de números de Fibonacci: ");
            int n = int.Parse(ReadLine());
            WriteLine();
            var mat = new Matematica(n);
            foreach (double a in mat.Fibonacci())
            {
                WriteLine(a);
            }
            EsperarEnter();
        }

        static void Main(string[] args)
        {
            SeletorDeOpcoes();
        }
    }
}
