using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MatematicaDouble
{
	static double nDouble, media;

	public MatematicaDouble(double nInformado)
	{
		nDouble = nInformado;
	}

	public double Media { get => media; }

	public double RaizMediaQuad(double n2)
	{
		double v = nDouble;
		double p = n2;

		var soma = new Somatoria();
		soma.Somar(v);
		soma.Somar(p);
		media = soma.MediaAritmetica();
		return Math.Sqrt(media);
	}
}