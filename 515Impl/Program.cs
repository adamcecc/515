/*
 * 
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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _515Impl
{
	class Program
	{
		static void Main(string[] args)
		{
			
			ulong chooseSize = 3;

			string[] things = new string[12] { 
				"Apple",  "Blueberry",  "Cantalope", 
				"Durian", "Egg Fruit",  "Fig", 
				"Grapes", "Honeydew",   "Ita Plam?", 
				"Jujube", "Blackberry", "Dragon Fruit" 
			};
			ulong thingsSetSize = (ulong)things.Count(); 

			Combination515 x515 = new Combination515();

			ulong choose = x515.Choose( thingsSetSize, chooseSize );

			Console.WriteLine( "Number of Combinations {0}", choose );
			Console.WriteLine( "Enter combination index to jump to: (exit to exit)" );

			string readline = ""; 
			while( readline != "exit" )
			{
				 try
				 {
					 readline = Console.ReadLine();
					 ulong index = Convert.ToUInt64( readline );

					 if ( index > choose )
						 continue;

					 ulong[] selectionSet = x515.GetCombinationIndex( thingsSetSize, chooseSize, index );
					 foreach ( ulong selectionIndex in selectionSet )
					 {
						 //Decrement by 1 for 0 indexing of arrays 
						 string selectedData = things[ selectionIndex - 1 ];

						 if ( selectedData != null )
						 {
							 Console.Out.Write( selectedData + ", " );
						 }
					 }

					 Console.Out.WriteLine();
				 } 
				 catch(Exception e)
				 {
					 Console.Out.WriteLine(e.Message); 
				 }
			}
		}
	}
}
