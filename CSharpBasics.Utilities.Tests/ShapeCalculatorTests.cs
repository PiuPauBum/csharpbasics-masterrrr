using NUnit.Framework;
using System;

namespace CSharpBasics.Utilities.Tests
{
	public class ShapeCalculatorTests
	{
		[TestCase(1, 1, 1)]
		[TestCase(2, 3, 6)]
		[TestCase(5, 8, 40)]
		public void CalcRectangleArea_ValidRectangleSides_ReturnsExpectedArea(int a, int b, int expectedArea)
		{
			var calculator = GetShapeCalculator();

			var actualArea = calculator.CalcRectangleArea(a, b);

			Assert.AreEqual(expectedArea, actualArea);
		}

		[TestCase(0, 0)]
		[TestCase(-1, 10)]
		[TestCase(10, -2)]
		[TestCase(10, 0)]
		[TestCase(0, 21)]
		[TestCase(-3, -7)]
		public void CalcRectangleArea_OneSideIsLessThanOrEqualToZero_ThrowsArgumentOutOfRangeException(int a, int b)
		{
			var calculator = GetShapeCalculator();

			Assert.Throws<ArgumentOutOfRangeException>(() => calculator.CalcRectangleArea(a, b));
		}
		
		private ShapeCalculator GetShapeCalculator()
		{
			return new ShapeCalculator();
		}
	}
}