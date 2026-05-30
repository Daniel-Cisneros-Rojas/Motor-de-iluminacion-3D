using System;
using System.Drawing;
using OpenTK;
using System.Drawing;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System.Collections.Generic;

namespace Tarea16
{
	
	public class Tools
	{
		Punto luz=new Punto(-4,4,4,0f,0f,0f);
		Punto[]vertice=new Punto[]{
			new Punto(-2,2,2,1f,0f,0f),//0
			new Punto(2,2,2,0f,1f,0f),//1
			new Punto(2,-2,2,0f,0f,1f),//2
			new Punto(-2,-2,2,1f,1f,0f),//3
			new Punto(-2,2,-2,0f,1f,1f),//4
			new Punto(2,2,-2,1f,0f,1f),
			new Punto(2,-2,-2,1f,1f,1f),//6
			new Punto(-2,-2,-2,0f,0f,0f),//7
			
};
		int[]indice=new int[]{
			0,1,3,2,
			7,6,2,3,
			0,4,2,3,
			0,4,5,6,
			
				
		};
		
		
		
		int[]secuencia=new int[]{
			4,5,6,7,
			1,2,6,5,
			0,3,7,4,
			2,3,7,6,
			0,1,5,4,
			
			0,1,2,3,
	};
		
		Punto[]esquinas=new Punto[]
		{
			new Punto(),//0
			new Punto(),//1
			new Punto(),//2
			new Punto(),//3
			new Punto(),//4
			new Punto(),
			new Punto(),//6
			new Punto(),//7
		};
		float rojo=1;
		public Tools()
		{
			
		}
		
		public double distancia_puntos(Punto a,Punto b)
		{
			double distancia;
			distancia=Math.Sqrt(Math.Pow((b.x-a.x),2)+Math.Pow((b.y-a.y),2)+Math.Pow((b.z-a.z),2));
			return distancia;
		}
		
			public void dibujar_cubo(Punto a,int tam,int color)
		{
			double distancia;
			GL.Begin(PrimitiveType.Quads);
			esquinas[0]=new Punto(a.x,a.y,a.z,0f,0f,0f);
			esquinas[1]=new Punto(a.x+tam,a.y,a.z,0f,0f,0f);
			esquinas[2]=new Punto(a.x+tam,a.y+tam,a.z,0f,0f,0f);
			esquinas[3]=new Punto(a.x,a.y+tam,a.z,0f,0f,0f);
			
			esquinas[4]=new Punto(a.x,a.y,a.z+tam,0f,0f,0f);
			esquinas[5]=new Punto(a.x+tam,a.y,a.z+tam,0f,0f,0f);
			esquinas[6]=new Punto(a.x+tam,a.y+tam,a.z+tam,0f,0f,0f);
			esquinas[7]=new Punto(a.x,a.y+tam,a.z+tam,0f,0f,0f);
			
			for(int i=0;i<8;i++)
			{
				distancia=distancia_puntos(luz,esquinas[i]);
				distancia=5/distancia;
				if(distancia>1)
				{
					distancia=1;
				}
				//Console.WriteLine(distancia);
				if(color==1)
				{
				  esquinas[i].R=(float)distancia;	
				}
				if(color==2)
				{
				  esquinas[i].G=(float)distancia;	
				}
				if(color==3)
				{
				  esquinas[i].B=(float)distancia;	
				}
				
			}
			
			foreach(int x in secuencia)
			{
				GL.Color3(esquinas[x].Colores());
				GL.Vertex3(esquinas[x].x,esquinas[x].y,esquinas[x].z);
			}
            
			GL.End();
		}
			
			public void cubo_luz(Punto a, int tam)
			{
			GL.Begin(PrimitiveType.Quads);
			esquinas[0]=new Punto(a.x,a.y,a.z,1f,0f,0f);
			esquinas[1]=new Punto(a.x+tam,a.y,a.z,rojo,0f,0f);
			esquinas[2]=new Punto(a.x+tam,a.y+tam,a.z,1f,0f,0f);
			esquinas[3]=new Punto(a.x,a.y+tam,a.z,1f,0f,0f);
			
			esquinas[4]=new Punto(a.x,a.y,a.z+tam,1f,0f,0f);
			esquinas[5]=new Punto(a.x+tam,a.y,a.z+tam,1f,0f,0f);
			esquinas[6]=new Punto(a.x+tam,a.y+tam,a.z+tam,1f,0f,0f);
			esquinas[7]=new Punto(a.x,a.y+tam,a.z+tam,1f,0f,0f);
			
			
			foreach(int x in secuencia)
			{
				GL.Color3(esquinas[x].Colores());
				GL.Vertex3(esquinas[x].x,esquinas[x].y,esquinas[x].z);
			}
            
			GL.End();
			}
		
		public void cubo()
		{
			GL.Begin(PrimitiveType.Quads);
			foreach(int x in indice)
			{
				GL.Color3(vertice[x].Colores());
				 GL.Vertex3(vertice[x].x,vertice[x].y,vertice[x].z);
			}
			
           
			GL.End();
		}
		
		public void ejes()
		{
			GL.LineWidth(2);
			GL.Begin(PrimitiveType.Lines);
			GL.Color4(Color4.Aqua);
			GL.Vertex3(0,0,0);GL.Vertex3(1,0,0);
			GL.Color4(Color4.Aquamarine);
			GL.Vertex3(0,0,0);GL.Vertex3(0,1,0);
			GL.Color4(Color4.BlueViolet);
			GL.Vertex3(0,0,0); GL.Vertex3(0,0,1);
			GL.Color4(Color4.AntiqueWhite);
			GL.End();
			
		}
		public void grilla()
		{
			GL.Begin(PrimitiveType.Lines);
			GL.Color4(Color4.AntiqueWhite);
			for (double t=-5; t <5; t +=0.5)
			{
				GL.Vertex3(t,0,-5);
				GL.Vertex3(t,0,5);
				GL.Vertex3(-5,0,t);
				GL.Vertex3(5,0,t);
			}
			GL.End();
		}
		
		public void multi_mat(int[,]a,int[,]b)
		{
			int[,]c=new int[a.GetLength(0),b.GetLength(1)];
			
			if(a.GetLength(1)==b.GetLength(0))
			{
				//poner en 0 la matriz
				for(int i=0;i<a.GetLength(0);i++)
				{
					for(int j=0;j<b.GetLength(1);j++)
					{
						c[i,j]=0;
					}
				}
				//operaciones
				for(int i=0;i<a.GetLength(0);i++)
				{
					for(int j=0;j<b.GetLength(1);j++)
					{
						for(int k=0;k<a.GetLength(1);k++)
						{
							c[i,j]=c[i,j]+(a[i,k]*b[k,j]);
						}
					}
				}
				//imprimir resultado
				for(int i=0;i<a.GetLength(0);i++)
				{
					for(int j=0;j<b.GetLength(1);j++)
					{
						Console.WriteLine("c["+i+","+j+"] = "+c[i,j]);
					}
				}
			}
			else
			{
				Console.WriteLine("No se puede realizar esta operacion");
			}
		}
	}
}