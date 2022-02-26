using System;
using NUnit.Framework;

namespace CSharpBasics.Utilities.Tests
{
	public class ArrayHelperTests
	{
		private static object[] _arraysWithExpectedSumOfPositiveElements =
		{
			new object[] {new[] {1, 2, 3}, 6},
			new object[] {new[] {0, -10, 30, -20, -50, 60}, 90},
			new object[] {new[] {-1, -2, -3}, 0},
			new object[] {new[] {0, 0, 0}, 0},
			new object[] {new int[0], 0}
		};

		[TestCaseSource(nameof(_arraysWithExpectedSumOfPositiveElements))]
		public void CalcSumOfPositiveElements_ValidArrayOfNumbers_ReturnsExpectedSum(int[] numbers, int expectedSum)
		{
			var arrayHelper = GetArrayHelper();

			var actualSum = arrayHelper.CalcSumOfPositiveElements(numbers);

			Assert.AreEqual(expectedSum, actualSum);
		}

		[Test]
		public void CalcSumOfPositiveElements_ArrayIsNull_ThrowsArgumentNullException()
		{
			var arrayHelper = GetArrayHelper();

			Assert.Throws<ArgumentNullException>(() => arrayHelper.CalcSumOfPositiveElements(null));
		}

		private static object[] _arraysBeforeAndAfterReplacementOfNegativeElements =
		{
			new object[]
			{
				new [,,] {{ {1, 2, 3}, { 1, 2, 3 }, { 1, 2, 3 } }},
				new [,,] {{ {1, 2, 3}, { 1, 2, 3 }, { 1, 2, 3 } }}
			},
			new object[]
			{
				new [,,] {{ {-1, 2, -3}, { 1, -2, 3 }, { -1, -2, -3 } }},
				new [,,] {{ {0, 2, 0}, { 1, 0, 3 }, { 0, 0, 0 } }}
			}
		};

		[TestCaseSource(nameof(_arraysBeforeAndAfterReplacementOfNegativeElements))]
		public void ReplaceNegativeElementsBy0_ValidArrayOfNumbers_AllOfNegativeElementsHaveBeenReplacedBy0(int[,,] sourceArray, int[,,] expectedArray)
		{
			var arrayHelper = GetArrayHelper();

			arrayHelper.ReplaceNegativeElementsBy0(sourceArray);

			CollectionAssert.AreEqual(expectedArray, sourceArray);
		}

		[Test]
		public void ReplaceNegativeElementsBy0_ArrayIsNull_ThrowsArgumentNullException()
		{
			var arrayHelper = GetArrayHelper();

			Assert.Throws<ArgumentNullException>(() => arrayHelper.ReplaceNegativeElementsBy0(null));
		}

		private static object[] _arraysWithExpectedSumOfElementsOnEvenPositions =
		{
			new object[] {new[,] {{1, 2}, {3, 4}}, 5},
			new object[] {new[,] {{1, 2}, {3, 4}, {5, 6}, {7, 8}}, 18},
			new object[] {new[,] {{1, 2, 3, 4}, {5, 6, 7, 8}}, 18},
			new object[] {new[,] {{1, 2, 3, 4}, {5, 6, 7, 8}, {9, 10, 11, 12}, {13, 14, 15, 16}}, 68},
		};

		[TestCaseSource(nameof(_arraysWithExpectedSumOfElementsOnEvenPositions))]
		public void CalcSumOfElementsOnEvenPositions_ValidArray_ReturnsExpectedSum(int[,] numbers, float expectedSum)
		{
			var arrayHelper = GetArrayHelper();

			var actualSum = arrayHelper.CalcSumOfElementsOnEvenPositions(numbers);

			Assert.AreEqual(expectedSum, actualSum);
		}

		[Test]
		public void CalcSumOfElementsOnEvenPositions_ArrayIsNull_ThrowsArgumentNullException()
		{
			var arrayHelper = GetArrayHelper();

			Assert.Throws<ArgumentNullException>(() => arrayHelper.CalcSumOfElementsOnEvenPositions(null));
		}

		private static object[] _arraysWithFiltersAndExpectedResults =
		{
			new object[] {new[] {1, 2, 3, 12, 21, 45}, (byte)2, new[] {2, 12, 21}},
			new object[] {new[] {1, 2, 3, 12, 21, 45}, (byte)1, new[] {1, 12, 21}},
			new object[] {new int[] {}, (byte)1, new int[] {}},
			new object[] {new [] { 1, 2, 3, 12, 21, 45 }, (byte)9, new int[] {}},
			new object[] {null, (byte)9, new int[] {}}
		};

		[TestCaseSource(nameof(_arraysWithFiltersAndExpectedResults))]
		public void FilterArrayByDigit_ValidArrayAndFilter_ReturnsExpectedArray(int[] numbers, byte filter, int[] expectedResult)
		{
			var arrayHelper = GetArrayHelper();

			var result = arrayHelper.FilterArrayByDigit(numbers, filter);

			CollectionAssert.AreEqual(expectedResult, result);
		}

		private ArrayHelper GetArrayHelper()
		{
			return new ArrayHelper();
		}
	}
}