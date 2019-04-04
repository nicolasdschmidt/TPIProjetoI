using System;
using System.IO; // necessário para ler e escrever em arquivos
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
				ForegroundColor = ConsoleColor.Yellow;
				WritePos(10, 1, "TP - Projeto I");

				ForegroundColor = ConsoleColor.Yellow;
				WritePos(2, 3, "1 - ");
				ForegroundColor = ConsoleColor.Gray;
				Write("Estatística de uma lista de valores lidos de um arquivo texto");

				ForegroundColor = ConsoleColor.Yellow;
				WritePos(2, 4, "2 - ");
				ForegroundColor = ConsoleColor.Gray;
				Write("MMC entre dois valores digitados");

				ForegroundColor = ConsoleColor.Yellow;
				WritePos(2, 5, "3 – ");
				ForegroundColor = ConsoleColor.Gray;
				Write("Raiz Cúbica de um valor digitado");

				ForegroundColor = ConsoleColor.Yellow;
				WritePos(2, 6, "4 – ");
				ForegroundColor = ConsoleColor.Gray;
				Write("MDC por subtrações sucessivas");

				ForegroundColor = ConsoleColor.Yellow;
				WritePos(2, 7, "5 – ");
				ForegroundColor = ConsoleColor.Gray;
				Write("Lista de números de Fibonacci");

				ForegroundColor = ConsoleColor.Yellow;
				WritePos(2, 8, "6 – ");
				ForegroundColor = ConsoleColor.Gray;
				Write("Seno Hiperbólico");

				ForegroundColor = ConsoleColor.Yellow;
				WritePos(2, 20, "99 – ");
				ForegroundColor = ConsoleColor.Gray;
				Write("Terminar o programa");

				ForegroundColor = ConsoleColor.Yellow;
				WritePos(2, 22, "Opção: ");
				ForegroundColor = ConsoleColor.Gray;
				opcao = int.Parse(ReadLine());

				switch (opcao)
				{
					case 1: LerArquivo(); break;
					case 2: CalcularMMC();  break;
					case 3: AproximacaoDaRaizCubica(); break;
					case 4: MDCporSubtracoes(); break;
					case 5: ListarFibonacci(); break;
					case 6: break;
				}
			}
			while (opcao != 99);
		}

		private static void LerArquivo()
		{
			Clear();
			WritePos(2, 2, "Insira o nome do arquivo texto: ");
			WritePos(2, 3, "(localizado na pasta root do projeto)");
			WritePos(2, 4, @"..\..\                          .txt");
			SetCursorPosition(8, 4);
			string caminho;
			try																	// executa o código verificando por exceções
			{
				string arquivo = ReadLine();
				if (arquivo.EndsWith(".txt"))									// verifica se o usuário inseriu ".txt" no fim do
				{																// nome do arquivo, se não, insere automaticamente
					caminho = @"..\..\" + arquivo;
				}
				else															// também é feita uma concatenação, completando o nome
				{																// do arquivo com um comando para voltar duas pastas no
					caminho = @"..\..\" + arquivo + ".txt";						// sistema de arquivos, de modo a encontrar o arquivo na
				}																// pasta root do projeto, e não em "\bin\Debug"

				var reader = new StreamReader(caminho);							// instancia um StreamReader usando a string concatenada com o arquivo
				var somaGeral = new Somatoria();								// somatória de todos os números lidos
				var somaV = new Somatoria();									// somatória dos valores V lidos com peso P
				var somaP = new Somatoria();									// somatória apenas dos valores P lidos
				var prodGeral = new Produtorio();								// produtório de todos os números lidos
				var somaInversos = new Somatoria();								// somatória dos inversos de todos os números lidos
				while (!reader.EndOfStream)
				{
					string linhaLida = reader.ReadLine();						// lê a linha e divide os valores em
					double v = double.Parse(linhaLida.Substring(0, 8));			// v,
					double p = double.Parse(linhaLida.Substring(8, 8));			// p

					somaGeral.Somar(v);											// adiciona v e p à soma geral
					somaGeral.Somar(p);
					somaV.Somar(v * p);											// adiciona v com peso p à somaV
					somaP.Somar(p);												// adiciona p à somaP
					prodGeral.Multiplicar(v);									// adiciona v e p ao produtório geral
					prodGeral.Multiplicar(p);
					somaInversos.Somar(1 / v);									// adiciona os inversos de v e p à soma dos inversos
					somaInversos.Somar(1 / p);
				}																// repete até o fim do arquivo
				var mat = new MatematicaDouble(prodGeral.Valor);
				WritePos(2, 6, $"RMQ = {Math.Sqrt(somaGeral.MediaAritmetica())}");		// calcula RMQ como a raiz da MA
				WritePos(2, 7, $"MA = {somaGeral.MediaAritmetica()}");					// calcula MA
				WritePos(2, 8, $"MP = {somaV.Valor / somaP.Valor}");					// calcula MP como média entre V com peso e P
				WritePos(2, 9, $"MG = {mat.NEsimaRaiz(prodGeral.Qtos)}");				// calcula MG como a n-ésima raiz do produto geral
				WritePos(2, 10, $"MH = {somaGeral.Valor / somaInversos.Valor}");		// calcula MH como a soma geral dividida pela soma dos inversos
			}
			catch (Exception e)													// se houver exceção, recebê-la e escrever sua mensagem
			{
				WritePos(2, 5, "O arquivo não pode ser lido:\n\n");
				WritePos(2, 6, e.Message);
				WriteLine();
			}
			EsperarEnter();
		}

		private static void CalcularMMC()
		{
            string opcao;
            do
            {
                Clear();
                WritePos(10, 1, "MMC");
                WritePos(2, 3, "Insira o primeiro valor: ");
                int a = int.Parse(ReadLine());
                WritePos(2, 4, "Insira o segundo valor: ");
                int b = int.Parse(ReadLine());
                var mat = new Matematica(a);
                WritePos(2, 6, $"O MMC entre {a} e {b} é {mat.MMC(b)}");
                WritePos(2, 19, "Digite [99] para sair \n");
                WritePos(2, 20, "Digite [ENTER] para continuar \n");
                WritePos(2, 21, "Opção: ");
                opcao = ReadLine();
            } while (opcao != "99");
        }

		private static void MDCporSubtracoes()
		{
			Clear();
			WritePos(5, 1, "Calculo de MDC por subtrações sucessivas");
			WritePos(2, 3, "Insira o primeiro valor: ");
			int a = int.Parse(ReadLine());
			WritePos(2, 4, "Insira o segundo valor: ");
			int b = int.Parse(ReadLine());

			var mat = new Matematica(a);

			WritePos(2, 6, $"O MDC entre {a} e {b} é {mat.MDCPorSubtracoes(b)}");  // calcula MDC entre "a" e "b"
			EsperarEnter();
		}

		private static void AproximacaoDaRaizCubica()
		{
			Clear();
			WritePos(5, 1, "Aproximação de raíz cúbica");
			WritePos(2, 3, "Digite o valor a ser calculado: ");
			int valor = int.Parse(ReadLine());                                  // recebe o valor a ser calculado
			WritePos(2, 4, "Digite a margem de erro entre 0,001 e 0,06: ");
			double margem;
			try
			{
				margem = double.Parse(ReadLine());                              // recebe a margem de erro
				if (margem > 0.06 || margem < 0.001)                            // verifica se a margem corresponde a um valor entre 0.001 e 0.06
				{
					throw new Exception("Valor da margem inválido.");
				}
				else
				{
					var mat = new Matematica(valor);
					WritePos(2, 6, $"O valor aproximado da raíz cúbica de {valor} é {mat.AproximacaoRaizCubica(margem)}");
					WritePos(2, 7, $"Arredondando: {Math.Round(mat.AproximacaoRaizCubica(margem))}");
				}
			}
			catch (Exception e)
			{
				WritePos(2, 6, e.Message);
				WriteLine();
			}
			EsperarEnter();
		}

		private static void ListarFibonacci()
		{
			Clear();
			WritePos(2, 2, "Insira a quantidade desejada de números de Fibonacci: ");
			int n;
			try
			{
				n = int.Parse(ReadLine());
				if(n <= 0)
				{
					throw new Exception("Digite um valor maior que 0.");
				}
				else
				{
					WriteLine();
					var mat = new Matematica(n);
					foreach (double a in mat.Fibonacci())
					{
						WriteLine("  " + a);
					}
					WriteLine();
					WriteLine("  Pressione [Enter] para prosseguir: ");
					ReadLine();
				}
			}
			catch (Exception e)
			{
				WriteLine();
				WritePos(2, 4, e.Message);
				WriteLine();
				EsperarEnter();
			}
		}

		static void Main(string[] args)
		{
			SeletorDeOpcoes();
		}
	}
}
