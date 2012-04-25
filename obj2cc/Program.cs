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
using System.Collections.Generic;
using System.IO;

namespace obj2cc
{
	class Program
	{
		static void Main(string[] args)
		{
			List<Vector3> vertices = new List<Vector3>();
			List<Vector2> texcoords = new List<Vector2>();
			List<Vector3> normals = new List<Vector3>();
			List<Triangle> triangles = new List<Triangle>();

			if (args.Length == 0)
			{
				Console.WriteLine("No file specified.");
				return;
			}

			if (!File.Exists(args[0]))
			{
				Console.WriteLine("File does not exist.");
				return;
			}

			StreamReader reader = new StreamReader(args[0]);
			//StreamReader reader = new StreamReader(@"C:\Users\Robert Rouhani\Documents\maya\projects\default\scenes\buttonup.obj");
			string file = reader.ReadToEnd();

			foreach (string l in file.Split(Environment.NewLine.ToCharArray()))
			{
				string line = l.Trim();

				//get rid of comments
				int commentStart = line.IndexOf("#");
				if (commentStart != -1)
					line = line.Substring(0, commentStart);

				//if the line is blank, go on to the next line
				if (line.Length == 0)
					continue;

				string[] values = line.Split(' ');

				//based on the type of identifier, do something to the rest of the line.
				switch (values[0])
				{
					case "v":
						vertices.Add(new Vector3(values[1], values[2], values[3]));
						break;
					case "vt":
						texcoords.Add(new Vector2(values[1], values[2]));
						break;
					case "vn":
						normals.Add(new Vector3(values[1], values[2], values[3]));
						break;
					case "f":
					{
						Vertex[] triVerts = new Vertex[3];
						for (int i = 0; i < 3; i++)
						{
							string[] indValues = values[i + 1].Split('/');
							Vector3i indNums = new Vector3i(indValues[0], indValues[1], indValues[2]);
							triVerts[i] = new Vertex(vertices[indNums.X - 1], texcoords[indNums.Y - 1], normals[indNums.Z - 1]);
						}
						triangles.Add(new Triangle(triVerts[0], triVerts[1], triVerts[2]));
						break;
					}
				}
			}

			Console.WriteLine("/**");
			Console.WriteLine(" * Copyright (c) 2010-2012 Lightning Development Studios <lightningdevelopmentstudios@gmail.com>");
			Console.WriteLine(" * ");
			Console.WriteLine(" * Permission is hereby granted, free of charge, to any person obtaining a copy of");
			Console.WriteLine(" * this software and associated documentation files (the \"Software\"), to deal in");
			Console.WriteLine(" * the Software without restriction, including without limitation the rights to");
			Console.WriteLine(" * use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies");
			Console.WriteLine(" * of the Software, and to permit persons to whom the Software is furnished to do");
			Console.WriteLine(" * so, subject to the following conditions:");
			Console.WriteLine(" * ");
			Console.WriteLine(" * The above copyright notice and this permission notice shall be included in all");
			Console.WriteLine(" * copies or substantial portions of the Software.");
			Console.WriteLine(" * ");
			Console.WriteLine(" * THE SOFTWARE IS PROVIDED \"AS IS\", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR");
			Console.WriteLine(" * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,");
			Console.WriteLine(" * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE");
			Console.WriteLine(" * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER");
			Console.WriteLine(" * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,");
			Console.WriteLine(" * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE");
			Console.WriteLine(" * SOFTWARE.");
			Console.WriteLine(" */");
			Console.WriteLine("");
			Console.WriteLine("package com.ltdev.cc.models;");
			Console.WriteLine("");
			Console.WriteLine("/**");
			Console.WriteLine(" * Automatically generated vertex data for model \"" + Path.GetFileName(args[0]) + "\".");
			Console.WriteLine(" * @author Lightning Development Studios");
			Console.WriteLine(" */");
			Console.WriteLine("public class " + Path.GetFileNameWithoutExtension(args[0]) + "Data");
			Console.WriteLine("{");
			Console.WriteLine("\t/**");
			Console.WriteLine("\t * The number of vertices in the array.");
			Console.WriteLine("\t */");
			Console.WriteLine("public static final int vertexCount = " + triangles.Count * 3 + ";");
			Console.WriteLine("");
			Console.WriteLine("\t/**");
			Console.WriteLine("\t * Vertex data.");
			Console.WriteLine("\t */");
			Console.WriteLine("\tpublic static final float[] vertices = {");

			foreach (Triangle t in triangles)
			{
				Console.WriteLine("\t\t" + t.Vertex0.Position.ToJavaArray() + ", " + t.Vertex0.TexCoord.ToJavaArray() + ", " + t.Vertex0.Normals.ToJavaArray() + ",");
				Console.WriteLine("\t\t" + t.Vertex1.Position.ToJavaArray() + ", " + t.Vertex1.TexCoord.ToJavaArray() + ", " + t.Vertex1.Normals.ToJavaArray() + ",");
				Console.WriteLine("\t\t" + t.Vertex2.Position.ToJavaArray() + ", " + t.Vertex2.TexCoord.ToJavaArray() + ", " + t.Vertex2.Normals.ToJavaArray() + ",");
			}

			Console.WriteLine("\t};");
			Console.WriteLine("}");
		}
	}
}
