#region MIT License
/*Copyright (c) 2010-2012 Lightning Development Studios <lightningdevelopmentstudios@gmail.com>

Permission is hereby granted, free of charge, to any person obtaining a copy of
this software and associated documentation files (the "Software"), to deal in
the Software without restriction, including without limitation the rights to
use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies
of the Software, and to permit persons to whom the Software is furnished to do
so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.*/
#endregion

using System;
using System.Runtime.InteropServices;

namespace obj2cc
{
	/// <summary>
	/// A 3-component vector of integers.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct Vector3i
	{
		/// <summary>
		/// The X component.
		/// </summary>
		public int X;

		/// <summary>
		/// The Y component.
		/// </summary>
		public int Y;

		/// <summary>
		/// The Z component.
		/// </summary>
		public int Z;

		/// <summary>
		/// Initializes a new instance of the <see cref="Vector3i"/> struct.
		/// </summary>
		/// <param name="x">The X component.</param>
		/// <param name="y">The Y component.</param>
		/// <param name="z">The Z component.</param>
		public Vector3i(int x, int y, int z)
			: this()
		{
			X = x;
			Y = y;
			Z = z;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Vector3i"/> struct.
		/// </summary>
		/// <param name="x">The X component.</param>
		/// <param name="y">The Y component.</param>
		/// <param name="z">The Z component.</param>
		public Vector3i(string x, string y, string z)
			: this()
		{
			try
			{
				X = int.Parse(x);
				Y = int.Parse(y);
				Z = int.Parse(z);
			}
			catch
			{
			}
		}

		public override string ToString()
		{
			return "<" + X + ", " + Y + ", " + Z + ">";
		}
	}
}
