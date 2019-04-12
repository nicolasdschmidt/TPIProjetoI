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

    public bool EhPrimo()
    {
        if (nInt % 2 == 0)
            if (nInt == 2)  // 2 é o único primo par
                return true;
            else
                return false;
        else // número ímpar
        {
            var possivelDivisor = new Contador(3, nInt / 2, 2);
            int resto = 1;
            while (resto != 0 && possivelDivisor.Prosseguir())
            {
                resto = nInt % possivelDivisor.Valor;
            }

            return (resto != 0);  // se não achamos resto == 0, o número é primo
        }
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
        double a = 0;                                   // definindo os valores
        double b = 1;                                   // iniciais da lista
        for (int i = 0; i < nInt; i++)					// repete nInt vezes
        {
            double temp = a;							// guarda o valor atual em uma variável temporária
            a = b;                                      // o valor atual recebe o próximo valor
            b = temp + b;								// calcula o próximo valor usando o valor atual e o valor anterior
            Fibonacci.Add(a);							// adiciona o valor atual à lista
        }
        return Fibonacci;
    }

    public double AproximacaoRaizCubica(double palpiteAnterior)	// retorna a aproximação da raíz cúbica de um valor inteiro
    {
        palpiteAnterior = (nInt / (palpiteAnterior * palpiteAnterior) + 2 * palpiteAnterior) / 3; // calcula o próximo palpite
        return palpiteAnterior;
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
            else if (b > a)             // senão se b é maior que a,
            {
                b -= a;                 // faça b = b - a
            }
        } while (a != b);				// repete até que os dois valores se tornem iguais
        return a;
    }

    public int MMC(int y)
    {
        int numeroInteiro = nInt;
        var cont = new Contador(2, int.MaxValue, 1); // contador que será os divisores
        var mmc = new Produtorio();     // instancia um produtório que aclculará o MMC
        bool jaMultiplicado;    // verifica se o valor dividido já foi multiplicado no MMC

        while (true)
        {
            var mat = new Matematica(cont.Valor);

            if (mat.EhPrimo())    //verifica se o valor é primo
            {
                jaMultiplicado = false;     // no inicios

                if (numeroInteiro % cont.Valor == 0)    // verifica se o primeiro valor é divisível por cont.Valor
                {
                    numeroInteiro /= cont.Valor;    // divide o premeiro numero 
                    mmc.Multiplicar(cont.Valor);
                    jaMultiplicado = true;     // cont.Valor já foi multiplicado no MMC 
                }

                if (y % cont.Valor == 0)    // verifica se o segundo é divisível por cont.Valor
                {
                    if (!jaMultiplicado)    // se já foi multiplicado antes, não devemos fazer novamente
                    {
                        mmc.Multiplicar(cont.Valor);
                    }

                    y /= cont.Valor;    // divide o premeiro numero 
                }
            }

            if (numeroInteiro % cont.Valor != 0 && y % cont.Valor != 0)     // verifica se os valor ainda são divisiveis pelo cont.Valor
                cont.Contar();    // soma um ao contador

            if (numeroInteiro == 1 && y == 1)   // se os dois valores chegaram a 1, o MMC foi encontrado
            {
                return (int)mmc.Valor;  // retorna o MMC
            }

        }
    }
}
