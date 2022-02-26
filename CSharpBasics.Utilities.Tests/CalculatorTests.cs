using System;
using NUnit.Framework;

namespace CSharpBasics.Utilities.Tests
{
	public class CalculatorTests
	{
		[TestCase(10, 23, 3, 5)]
		[TestCase(20, 70, 4, 5)]
		[TestCase(10, 0, 10)]
		[TestCase(10, 0, 20, 30, 40)]
		public void CalcSumOfDivisors_ValidNumberAndDivisors_ReturnsExpectedSum(int number, float expectedSum, params int[] divisors)
		{
			var calculator = GetCalculator();

			var actualSum = calculator.CalcSumOfDivisors(number, divisors);

			Assert.AreEqual(expectedSum, actualSum);
		}

		[TestCase(0)]
		[TestCase(int.MinValue)]
		[TestCase(-1)]
		public void CalcSumOfDivisors_InvalidNumber_ThrowsArgumentOutOfRangeException(int number)
		{
			var calculator = GetCalculator();

			Assert.Throws<ArgumentOutOfRangeException>(() => calculator.CalcSumOfDivisors(number, 1));
		}

		[TestCase(0, 1, 2)]
		[TestCase(int.MinValue, -1, -15)]
		[TestCase(5, -1, 0)]
		[TestCase]
		public void CalcSumOfDivisors_InvalidDivisors_ThrowsArgumentOutOfRangeException(params int[] divisors)
		{
			var calculator = GetCalculator();

			Assert.Throws<ArgumentOutOfRangeException>(() => calculator.CalcSumOfDivisors(int.MaxValue, divisors));
		}

		[TestCase(12, ExpectedResult = 21)]
		[TestCase(513, ExpectedResult = 531)]
		[TestCase(2017, ExpectedResult = 2071)]
		[TestCase(414, ExpectedResult = 441)]
		[TestCase(144, ExpectedResult = 414)]
		[TestCase(1234321, ExpectedResult = 1241233)]
		[TestCase(1234126, ExpectedResult = 1234162)]
		[TestCase(3456432, ExpectedResult = 3462345)]
		public long FindNextBiggerNumber_NumberThatHasBiggerNumberWitheTheSameDigits_ReturnsExpectedNumber(int number)
		{
			var calculator = GetCalculator();

			var result = calculator.FindNextBiggerNumber(number);

			return result;
		}

		[TestCase(0)]
		[TestCase(-1)]
		[TestCase(int.MinValue)]
		public void FindNextBiggerNumber_InvalidNumber_ThrowsArgumentOutOfRangeException(int number)
		{
			var calculator = GetCalculator();

			Assert.Throws<ArgumentOutOfRangeException>(() => calculator.FindNextBiggerNumber(number));
		}

		[TestCase(10)]
		[TestCase(20)]
		[TestCase(1)]
		public void FindNextBiggerNumber_NumberThatDoesNotHaveBiggerNumberWithTheSameDigits_ThrowsInvalidOperationException(int number)
		{
			var calculator = GetCalculator();

			Assert.Throws<InvalidOperationException>(() => calculator.FindNextBiggerNumber(number));
		}

		private Calculator GetCalculator() => new Calculator();
	}
}