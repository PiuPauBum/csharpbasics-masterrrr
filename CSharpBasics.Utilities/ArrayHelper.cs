using System;
using System.Collections.Generic;
using System.Numerics;

namespace CSharpBasics.Utilities
{
	public class ArrayHelper
	{
		/// <summary>
		/// Вычисляет сумму неотрицательных элементов в одномерном массиве
		/// </summary>
		/// <param name="numbers">Одномерный массив чисел</param>
		/// <returns>Сумма неотрицательных элементов массива</returns>
		/// <exception cref="ArgumentNullException"> Выбрасывается, если <see cref="numbers"/> равен null</exception>
		public float CalcSumOfPositiveElements(int[] numbers)
		{
			int sum = 0;
			if (numbers != null)
			{
				for (int i = 0; i < numbers.Length; i++)
				{
					if (numbers[i] > 0)
					{
						sum += numbers[i];
					}
				}
				return sum;
			}
			else
				throw new ArgumentNullException();
			//throw new NotImplementedException();
		}

		/// <summary>
		/// Заменяет все отрицательные элементы в трёхмерном массиве на нули
		/// </summary>
		/// <param name="numbers">Массив целых чисел</param>
		/// <exception cref="ArgumentNullException"> Выбрасывается, если <see cref="numbers"/> равен null</exception>
		public void ReplaceNegativeElementsBy0(int[,,] numbers)
		{
			if (numbers != null)
			{
				int one, two, three;
				one = numbers.GetLength(0);
				two = numbers.GetLength(1);
				three = numbers.GetLength(2);
				for (int i = 0; i < one; i++)
				{
					for (int j = 0; j < two; j++)
					{
						for (int f = 0; f < three; f++)
						{
							if (numbers[i, j, f] < 0)
                            {
								numbers[i, j, f] = 0;
							}
						}
					}
				}				
			}
			else
				throw new ArgumentNullException();
			
		}

		/// <summary>
		/// Вычисляет сумму элементов двумерного массива <see cref="numbers"/>,
		/// которые находятся на чётных позициях ([1,1], [2,4] и т.д.)
		/// </summary>
		/// <param name="numbers">Двумерный массив целых чисел</param>
		/// <returns>Сумма элементов на четных позициях</returns>
		/// <exception cref="ArgumentNullException"> Выбрасывается, если <see cref="numbers"/> равен null</exception>
		public float CalcSumOfElementsOnEvenPositions(int[,] numbers)
		{
			if (numbers != null)
			{
				int one, two, sum =0;
				one = numbers.GetLength(0);
				two = numbers.GetLength(1);
				
				for (int i = 0; i < one; i++)
				{
					for (int j = 0; j < two; j++)
					{
						if ((i+j)%2==0)
                        {
							sum += numbers[i, j];
                        }
					}
				}
				return sum;
			}
			else
				throw new ArgumentNullException();

			//throw new NotImplementedException();
		}

		/// <summary>
		/// Фильтрует массив <see cref="numbers"/> таким образом, чтобы на выходе остались только числа, содержащие цифру <see cref="filter"/>
		/// </summary>
		/// <param name="numbers">Массив целых чисел</param>
		/// <param name="filter">Цифра для фильтрации массива <see cref="numbers"/></param>
		/// <returns></returns>
		public int[] FilterArrayByDigit(int[] numbers, byte filter)
		{
			int g = 0;
			List<int> res = new List<int>();
			int num;
			if (numbers == null)
			{
				numbers = new int[] { };
			}
			for (int i = 0; i < numbers.Length; i++)
			{
				num = numbers[i];
				while (num > 0)
				{
					if (num % 10 == filter)
					{
						res.Add(numbers[i]);
						g++;
						num = 1;
					}
					num = num / 10;
				}
			}
			int[] result = res.ToArray();

			return result;
			//throw new NotImplementedException();
			//throw new NotImplementedException();
		}
	}
}