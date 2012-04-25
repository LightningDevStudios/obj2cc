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
	[StructLayout(LayoutKind.Sequential)]
	public struct Triangle
	{
		public Vertex Vertex0;
		public Vertex Vertex1;
		public Vertex Vertex2;

		public Triangle(Vertex v0, Vertex v1, Vertex v2)
			: this()
		{
			Vertex0 = v0;
			Vertex1 = v1;
			Vertex2 = v2;
		}

		public override string ToString()
		{
			return "v0:\n" + Vertex0.ToString() + "\n\n"
				+ "v1:\n" + Vertex1.ToString() + "\n\n"
				+ "v2:\n" + Vertex2.ToString() + "\n\n";
		}
	}
}
