using System;

public class Somatoria
{
	double soma;
	int quantosValoresForamSomados;

	public Somatoria()
	{
		soma = quantosValoresForamSomados = 0;
	}

	public double Valor
	{
		get => soma;
	}
	public void Somar(double valorASerSomado)
	{
		soma += valorASerSomado;        // acumula na soma o valor passado como parâmetro
		quantosValoresForamSomados++;   // conta a quantidade de valores já somados
	}

	public double MediaAritmetica()
	{
		if (quantosValoresForamSomados > 0)
			return soma / quantosValoresForamSomados;

		throw new Exception("Divisão por zero");
	}
}
