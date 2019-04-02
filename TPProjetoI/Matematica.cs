using System;
using System.Collections.Generic; // necessário para uso de listas

class Matematica
{
    static int nInt;

    public Matematica(int nInformado)
    {
        nInt = nInformado;
    }

    public int Fatorial()
    {
        var fat = new Produtorio();
        var contador = new Contador(1, nInt, 1);
        while (contador.Prosseguir())
            fat.Multiplicar(contador.Valor);

        return (int)fat.Valor;
    }

    public static string Divisores()
    {
        string lista = "";
        var possivelDivisor = new Contador(2, nInt / 2, 1);
        while (possivelDivisor.Prosseguir())
        {
            int resto = nInt % possivelDivisor.Valor;
            if (resto == 0)
                lista = lista + possivelDivisor.Valor + ", ";
        }
        lista = "1, " + lista + nInt;
        return lista;
    }

    public int MDC(int n2)
    {
        int dividendo = nInt;
        int divisor = n2;
        int resto;
        do
        {
            resto = dividendo % divisor;
            if (resto != 0)
            {
                dividendo = divisor;
                divisor = resto;
            }
        }
        while (resto != 0);

        return divisor;
    }

    public bool Palindromo()
    {
        int numero = nInt;
        int aoContrario = 0;
        while (numero > 0)
        {
            int quociente = numero / 10;
            int resto = numero - 10 * quociente;

            aoContrario = aoContrario * 10 + resto;
            numero = quociente;
        }

        return nInt == aoContrario;
    }

    public int SomaDosDigitos()
    {
        var soma = new Somatoria();
        int n = nInt;
        while (n > 0)
        {
            int quo = n / 10;
            int digito = n - 10 * quo;

            soma.Somar(digito);

            n = quo;
        }
        return (int)soma.Valor;
    }

    public double Elevado(double a)
    {
        var pot = new Produtorio();
        var vez = new Contador(1, nInt, 1);

        while (vez.Prosseguir())
        {
            pot.Multiplicar(a);
        }
        return pot.Valor;
    }

    public List<double> Fibonacci()						// retorna até o n-ésimo termo da lista de Fibonacci
    {
        List<double> Fibonacci = new List<double>();	// instanciação de uma lista de valores reais
        double a = 0;									// definindo os valores
		double b = 1;									// iniciais da lista
		for (int i = 0; i < nInt; i++)					// repete nInt vezes
        {
            double temp = a;							// guarda o valor atual em uma variável temporária
            a = b;                                      // o valor atual recebe o próximo valor
			b = temp + b;								// calcula o próximo valor usando o valor atual e o valor anterior
            Fibonacci.Add(a);							// adiciona o valor atual à lista
        }
        return Fibonacci;
    }

    public double AproximacaoRaizCubica(double erro)	// retorna a aproximação da raíz cúbica de um valor inteiro
    {
        double palpiteAnterior, palpiteAtual;
		palpiteAtual = 1;
        do
        {
			palpiteAnterior = palpiteAtual;
			palpiteAtual = (nInt / (palpiteAnterior * palpiteAnterior) + 2 * palpiteAnterior) / 3; // calcula o próximo palpite

        } while (Math.Abs(palpiteAtual - palpiteAnterior) > erro); // repete até que a diferença entre dois palpites seja menor do que o erro
        return palpiteAtual;
    }

    public int MDCPorSubtracoes(int b)	// retorna o MDC de dois valores pelo método das subtrações sucessivas, recebendo um valor inteiro
    {
        int a = nInt;					// a e b são os valores que terão o MDC calculado
        do 
        {
            if (a > b)					// se a é maior que b,
            {
                a -= b;                 // faça a = a - b
			}
            else if (b > a)				// senão se b é maior que a,
			{
                b -= a;                 // faça b = b - a
			}
        } while(a != b);				// repete até que os dois valores se tornem iguais
        return a;
    }
}
