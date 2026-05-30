
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
	public class Pantalla: GameWindow
	{
		Tools herramientas=new Tools();
		
		Punto luz=new Punto(-4,4,4,0f,0f,0f);
		
		Punto[]vertice=new Punto[]{
			new Punto(-2,2,2,1f,0f,0f),//0
			new Punto(2,2,2,0f,1f,0f),//1
			new Punto(-2,-2,2,0f,0f,1f),//2
			new Punto(2,-2,2,1f,1f,0f),//3
			new Punto(-2,2,-2,0f,1f,1f),//4
			new Punto(2,2,-2,1f,0f,1f),
			new Punto(2,-2,-2,1f,1f,1f),//6
			new Punto(-2,-2,-2,0f,0f,0f),//7
			
};
		int[]indice=new int[]{
			0,1,3,2,
			1,5,7,3,
			7,6,2,3,
			0,4,5,1,
			4,5,7,6,
		
		};
		
		
		
		
		public Pantalla() : base(1000, 1000, GraphicsMode.Default, "3D")
		{
			
		}
		
		protected override void OnLoad(EventArgs e)
		{
			GL.ClearColor(Color.White);
			Matrix4 lookAt = Matrix4.LookAt(5,5,5,0,0,0,0,1,0);
		//	Matrix4 lookAt = Matrix4.CreateLookAt(new Vector3(5, 5, 5), Vector3.Zero, Vector3.UnitY);

			GL.MatrixMode(MatrixMode.Modelview);
			GL.LoadMatrix(ref lookAt);
			
			
			
				
			
		}

		protected override void OnUpdateFrame(FrameEventArgs e)
		{

			GL.Clear(ClearBufferMask.ColorBufferBit); //| ClearBufferMask.DepthBufferBit);
			
		}
		protected override void OnRenderFrame(FrameEventArgs e)
		{
			//.Clear(ClearBufferMask.ColorBufferBit);
			herramientas.grilla();
			herramientas.ejes();
			herramientas.cubo_luz(luz,1);
			herramientas.dibujar_cubo(new Punto(2,2,-7,1f,1f,1f),2,3);
			herramientas.dibujar_cubo(new Punto(0,0,0,1f,1f,1f),2,2);
			
			herramientas.dibujar_cubo(new Punto(0,2,-3,1f,1f,1f),2,1);
			
			herramientas.dibujar_cubo(new Punto(-4,2,0,1f,1f,1f),2,3);
			
			
			//herramientas.cubo();
			SwapBuffers();
		}
		// ...
	
		protected override void OnResize(EventArgs e)
		{
			
			GL.Viewport(0,0,Width,Height);
			float aspectRadio = (float) Width/(float)(Height);
			//Matrix4 perspectiva =Matrix4.CreatePerspectiveFieldOfView(MathHelper);
			Matrix4 perspectiva = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver2, aspectRadio, 0.2f, 100.0f);

			GL.MatrixMode(MatrixMode.Projection);
			GL.LoadMatrix(ref perspectiva);
			
		}
		
		
	}

	
}
