using System;

namespace CSharpBasics.Utilities
{
	public class Calculator
	{
		/// <summary>
		/// Вычисляет сумму всех натуральных чисел меньше <see cref="number"/>, кратных любому из <see cref="divisors"/>
		/// </summary>
		/// <param name="number">Натуральное число</param>
		/// <param name="divisors">Числа, которым должны быть кратны слагаемые искомой суммы</param>
		/// <returns>Вычисленная сумма</returns>
		/// <exception cref="ArgumentOutOfRangeException">
		/// Выбрасывается в случае, если <see cref="number"/> или любое из чисел в <see cref="divisors"/> не является натуральным,
		/// а также если массив <see cref="divisors"/> пустой
		/// </exception>
		public float CalcSumOfDivisors(int number, params int[] divisors)
		{
            int sum = 0, k=0;
            if (number <= 0 || divisors.Length == 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                for (int i = 1; i < number; i++)
                {
                    for (int j = 0; j < divisors.Length; j++)
                    {
                        if (divisors[j] <= 0)
                            throw new ArgumentOutOfRangeException();
                        else
                        {
							if (i % divisors[j] == 0 && divisors[j] < number)
								k = 1;
                        }
                    }
					if (k==1)
                    {
						sum += i;
						k = 0;
                    }
                }
            }
            return sum;
            //throw new NotImplementedException();
		}

		/// <summary>
		/// Возвращает ближайшее наибольшее целое, состоящее из цифр исходного числа <see cref="number"/>
		/// </summary>
		/// <param name="number">Исходное число</param>
		/// <returns>Ближайшее наибольшее целое</returns>
		public long FindNextBiggerNumber(int number)
		{

			string numberstring = number.ToString();
			char[] sNum = numberstring.ToCharArray();
			int lastDigitSeen = sNum[sNum.Length - 1], i, j;
			if (number < 1)
            {
				throw new ArgumentOutOfRangeException();

			}
			for (i = sNum.Length - 1; i >= 0; i--)
			{
				if (lastDigitSeen > sNum[i])
				{
					break;
				}
				lastDigitSeen = sNum[i];
			}
			if (i >= 0)
			{
				for (j = sNum.Length - 1; j > i; j--)
				{
					if (sNum[j] > sNum[i])
					{
						break;
					}
				}

				Swap(sNum, i, j);
				SortSubarray(sNum, i + 1, numberstring.Length - 1);
			}
			else
			{
				throw new InvalidOperationException();
			}

			if (!int.TryParse(new string(sNum), out int result))
			{
				throw new InvalidOperationException();
			}

			return result;

			static void Swap(char[] number, int i, int j)
			{
				char temp = number[i];
				number[i] = number[j];
				number[j] = temp;
			}

			static void SortSubarray(char[] number, int i, int j)
			{
				while (i < j)
				{
					Swap(number, i, j);
					i += 1;
					j -= 1;
				}
			}
			
		}
	}
}