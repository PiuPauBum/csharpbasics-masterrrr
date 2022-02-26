using System;

namespace CSharpBasics.Utilities
{
	public class ShapeCalculator
	{
		/// <summary>
		/// Возвращает площадь прямоугольника со сторонами <see cref="a"/> и <see cref="b"/>
		/// </summary>
		/// <param name="a">Длина стороны a прямоугольника</param>
		/// <param name="b">Длина стороны b прямоугольника</param>
		/// <returns>Площадь прямоугольника</returns>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		public float CalcRectangleArea(int a, int b)
		{
			int s;
			if (a>0 && b>0)
            {
				s = a * b;
				return s;
            }
			else
			{
				throw new ArgumentOutOfRangeException();
			}
			//throw new NotImplementedException();
		}
	}
}