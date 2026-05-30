using System;
using System.Drawing;

namespace Tarea16
{

	public class Punto
	{
		int cx,cy,cz;
		float cr,cg,cb;
		public Punto()
		{
			cx=cy=cz=0;
		}
		
		public Punto(int x,int y, int z,float r,float g,float b)
		{
			cx=x;
			cy=y;
			cz=z;
			
			cr=r;
			cg=g;
			cb=b;
		}
		
		public void setcolor(float r,float g,float b)
		{
			cr=r;
			cg=g;
			cb=b;
		}
		
		public float R
		{
			set{cr=value;}
			get{return cr;}
		}
		
		public float G
		{
			set{cg=value;}
			get{return cg;}
		}
		
		public float B
		{
			set{cb=value;}
			get{return cb;}
		}
		
		public float[] Colores()
		{
			return new float[]{cr,cg,cb};
		}
		
		public int x
		{
			get{return cx;}
			set{cx=value;}
		}
		
		
		public int y
		{
			get{return cy;}
			set{cy=value;}
		}
		
		public int z
		{
			get{return cz;}
			set{cz=value;}
		}
		
		
	}
}
