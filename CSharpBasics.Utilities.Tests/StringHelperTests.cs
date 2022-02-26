using NUnit.Framework;

namespace CSharpBasics.Utilities.Tests
{
	[TestFixture]
	public class StringHelperTests
	{
		[TestCase("", 0)]
		[TestCase(null, 0)]
		[TestCase("!!! 765 : \n \t", 0)]
		[TestCase("\nраз два", 3)]
		[TestCase("раз,\n два! (Город) - \t приём!!!", 4)]
		[TestCase("р^а1з,\n д2в:а! (Г,о0р?о!д) - \t п@ри%ём!!!", 4)]
		[TestCase("П@р№и;в%е:т, м*и-р!", 4)]
		public void GetAverageWordLength(string input, int expectedAverageWordLength)
		{
			var stringHelper = GetStringHelper();

			var actualAverageWordLength = stringHelper.GetAverageWordLength(input);

			Assert.AreEqual(expectedAverageWordLength, actualAverageWordLength);
		}

		[TestCase("написать программу, которая", "описание", "ннааппииссаать ппроограамму, коотоораая")]
		[TestCase("хор", "xop", "хор")]
		[TestCase("Привет, мир!", "пРоекТ", "ППрривеетт, мирр!")]
		[TestCase("", "C# basics", "")]
		[TestCase(null, "C# basics", null)]
		[TestCase("original", "", "original")]
		[TestCase("original", null, "original")]
		public void DuplicateCharsInString_PassSomeDifferentStrings_ReturnsExpectedResult(string original, string toDuplicate, string expectedResult)
		{
			var stringHelper = GetStringHelper();

			var result = stringHelper.DuplicateCharsInString(original, toDuplicate);

			Assert.AreEqual(expectedResult, result);
		}

		private StringHelper GetStringHelper()
		{
			return new StringHelper();
		}
	}
}