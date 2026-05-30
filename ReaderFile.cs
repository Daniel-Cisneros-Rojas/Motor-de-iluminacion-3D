
using System;
using System.IO;

namespace Tarea16
{
	/// <summary>
	/// Description of ReaderFile.
	/// </summary>
	public class ReaderFile
	{
		public ReaderFile()
		{
		}
		
		public ReaderFile(string archivo)
		{
			StreamReader datos=new StreamReader(archivo);
			String linea;
			while(!datos.EndOfStream)
			{
				linea=datos.ReadLine();
				string[] token=linea.Split(',');
				foreach(string x in token)
				{
					Console.WriteLine(x);
				}
				
			}
		}
	}
}
