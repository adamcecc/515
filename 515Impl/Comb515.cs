/*
 * Copyright (c) 2016 Adam Cecchetti 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights 
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell 
 * copies of the Software, and to permit persons to whom the Software is 
 * furnished to do so, subject to the following conditions: 
 * 
 * The above copyright notice and this permission notice shall be included in 
 * all copies or substantial portions of the Software.  
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR 
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE 
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE 
 * SOFTWARE.
 * 
 */

using System;
using System.Numerics;

namespace _515Impl
{
	/// <summary>
	/// 
	/// </summary>
	public class Combination515
	{
		/// <summary>
		/// 
		/// </summary>
		public Combination515() { }


		/// <summary>
		/// 
		/// </summary>
		/// <param name="setSize"></param>
		/// <param name="chooseSize"></param>
		/// <param name="combinationIndex"></param>
		/// <returns></returns>
		public ulong[] GetCombinationIndex(ulong setSize, ulong chooseSize, ulong combinationIndex)
		{
			ulong[] combinationOrder = new ulong[chooseSize];

			ulong chosenIndex = 0;
			ulong accumulator = 0;
			ulong range = 0;

			for (chosenIndex = 0; chosenIndex < chooseSize - 1; chosenIndex++)
			{
				combinationOrder[chosenIndex] = ((chosenIndex != 0) ? combinationOrder[chosenIndex - 1] : 0);

				do
				{
					combinationOrder[chosenIndex]++;
					range = (ulong)Choose(setSize - combinationOrder[chosenIndex], chooseSize - (chosenIndex + 1));
					accumulator = accumulator + range;

				} while (accumulator < combinationIndex);

				accumulator = accumulator - range;
			}

			combinationOrder[chooseSize - 1] = combinationOrder[chooseSize - 2] + combinationIndex - accumulator;

			return combinationOrder;
		}

		/// <summary>
		///     
		/// </summary>
		/// <param name="setSize"></param>
		/// <param name="chooseSize"></param>
		/// <returns></returns>
		public ulong Choose(ulong setSize, ulong chooseSize)
		{
			BigInteger choose = 0;

			if (setSize < 0 || chooseSize < 0)
				throw new Exception("Set size or chooseSize can't be negative"); 

			if (setSize < chooseSize)
				return 0;

			if (setSize == chooseSize)
				return 1;

			BigInteger dist = 0;
			BigInteger max = 0;

			if (chooseSize < setSize - chooseSize)
			{
				dist = setSize - chooseSize;
				max = chooseSize;
			}
			else
			{
				dist = chooseSize;
				max = setSize - chooseSize;
			}

			choose = dist + 1;

			for (ulong iteration = 2; iteration <= max; ++iteration)
			{
				choose = (choose * (dist + iteration)) / iteration;
			}

			return (ulong) choose;
		}
	}
}
