using System;
using System.Collections.Generic;

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

	public List<double> Fibonacci() // Função do tipo List<double>, retorna uma lista de valores reais
	{
		List<double> Fibonacci = new List<double>();
		double a = 0;
		double b = 1;
		for (int i = 0; i < nInt; i++)
		{
			double temp = a;
			a = b;
			b = temp + b;
			Fibonacci.Add(a);
		}
		return Fibonacci;
	}



}
