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
	/// A 3-component vector.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct Vector3
	{
		/// <summary>
		/// The X component.
		/// </summary>
		public float X;

		/// <summary>
		/// The Y component.
		/// </summary>
		public float Y;

		/// <summary>
		/// The Z component.
		/// </summary>
		public float Z;

		/// <summary>
		/// Initializes a new instance of the <see cref="Vector3"/> struct.
		/// </summary>
		/// <param name="x">The X component.</param>
		/// <param name="y">The Y component.</param>
		/// <param name="z">The Z component.</param>
		public Vector3(float x, float y, float z)
			: this()
		{
			X = x;
			Y = y;
			Z = z;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Vector3"/> struct.
		/// </summary>
		/// <param name="x">The X component.</param>
		/// <param name="y">The Y component.</param>
		/// <param name="z">The Z component.</param>
		public Vector3(string x, string y, string z)
			: this()
		{
			try
			{
				X = float.Parse(x);
				Y = float.Parse(y);
				Z = float.Parse(z);
			}
			catch
			{
			}
		}

		public string ToJavaArray()
		{
			//also convert from Y-up to Z-up.
			return X.ToString("G") + "f, " + Z.ToString("G") + "f, " + Y.ToString("G") + "f";
		}

		public override string ToString()
		{
			return "<" + X + ", " + Y + ", " + Z + ">";
		}
	}
}
