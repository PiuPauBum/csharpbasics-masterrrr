using System;
using System.Linq;

namespace CSharpBasics.Utilities
{
	public class StringHelper
	{
		/// <summary>
		/// Вычисляет среднюю длину слова в переданной строке без учётов знаков препинания и специальных символов
		/// </summary>
		/// <param name="inputString">Исходная строка</param>
		/// <returns>Средняя длина слова</returns>
		public int GetAverageWordLength(string inputString)
		{
			if (inputString==null)
            {
				return 0;
            }
			if (inputString.Length!=0)
            {
				int col, result;
				string[] textMass;
				textMass = inputString.Split(' ');
				col = (textMass.Length);
				for (int i = 0; i < col; i++)
				{
					var prom = new String(textMass[i].Where(Char.IsLetter).ToArray());
					if (prom.Length == 0)
					{
						col--;
					}
				}
				var onlyLetters = new String(inputString.Where(Char.IsLetter).ToArray());

				result = onlyLetters.Length / col;
				return result;
			}
			else 
            {
				return 0;
            }
			
			//throw new NotImplementedException();
		}

		/// <summary>
		/// Удваивает в строке <see cref="original"/> все буквы, принадлежащие строке <see cref="toDuplicate"/>
		/// </summary>
		/// <param name="original">Строка, символы в которой нужно удвоить</param>
		/// <param name="toDuplicate">Строка, символы из которой нужно удвоить</param>
		/// <returns>Строка <see cref="original"/> с удвоенными символами, которые есть в строке <see cref="toDuplicate"/></returns>
		public string DuplicateCharsInString(string original, string toDuplicate)
		{
			
			if(original == null)
            {
				return null;
            }
			else if (toDuplicate == null)
            {
				return original;
            }
			else
            {
                //string orig = original;
                //orig.ToUpper();
                //string toDup = toDuplicate;
                //toDup.ToUpper();
                string result = "";
				
				for (int i = 0; i < original.Length; i++)
				{
					if (toDuplicate.Contains(original[i]))
					{
						result += original[i];
						result += original[i];
					}
					else if (toDuplicate.ToUpper().Contains(original[i]))
					{
						result += original[i];
						result += original[i];
					}
					else if (toDuplicate.ToLower().Contains(original[i]))
					{
						result += original[i];
						result += original[i];
					}
					else
					{
						result += original[i];
					}
				}
				return result;
			}				
			
			//throw new NotImplementedException();

		}
	}
}