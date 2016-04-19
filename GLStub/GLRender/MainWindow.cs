using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using GLStub.Control;

namespace GLStub.GLRender
{
    public class MainWindow : GameWindow
    {
        Camera camera = new Camera();

        public MainWindow() : base(800, 600)
        {
            Title = "GL Stub";
        }

        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(Color.Black);
            GL.Enable(EnableCap.DepthTest);

            //GL.MatrixMode(MatrixMode.Modelview);
            //GL.LoadIdentity();
        }

        protected override void OnUnload(EventArgs e)
        {
            //
        }

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(ClientRectangle);

            float aspect = this.ClientSize.Width / (float)this.ClientSize.Height;
            Matrix4 projection_matrix;
            Matrix4.CreatePerspectiveFieldOfView((float)Math.PI / 4, aspect, 1, 1000, out projection_matrix);
            
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.LoadMatrix(ref projection_matrix);
            GL.MatrixMode(MatrixMode.Modelview);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            //
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.LoadIdentity();

            DisplayCamara();

            DisplayAxis();

            SwapBuffers();
        }

        protected override void OnMouseDown(OpenTK.Input.MouseButtonEventArgs e)
        {
            if(e.Mouse.IsButtonDown(OpenTK.Input.MouseButton.Left))
            {
                camera.LastX = e.Mouse.X;
                camera.LastY = e.Mouse.Y;
                camera.IsPressed = true;
            }
        }

        protected override void OnMouseUp(OpenTK.Input.MouseButtonEventArgs e)
        {
            if(e.Mouse.IsButtonUp(OpenTK.Input.MouseButton.Left))
            {
                camera.IsPressed = false;
            }
        }

        protected override void OnMouseMove(OpenTK.Input.MouseMoveEventArgs e)
        {
            if (camera.IsPressed == true)
            {
                float diffx = e.Mouse.X - camera.LastX;
                float diffy = e.Mouse.Y - camera.LastY;
                camera.LastX = e.Mouse.X;
                camera.LastY = e.Mouse.Y;
                camera.XRot += (float)diffy;
                camera.YRot += (float)diffx;
            }
        }

        public void DisplayCamara()
        {
            GL.Translate(0.0, 0.0, -camera.CRadius);
            GL.Rotate(camera.XRot, 1.0, 0.0, 0.0);

            GL.Rotate(camera.YRot, 0.0, 1.0, 0.0);
            GL.Translate(-camera.XPos, 0.0, -camera.ZPos);
        }

        public void DisplayAxis()
        {
            GL.PushMatrix();

            GL.Color3(1.0, 0.0, 0.0);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex3(0.0, 0.0, 0.0);
            GL.Vertex3(5.0, 0.0, 0.0);
            GL.End();

            GL.Color3(0.0, 1.0, 0.0);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex3(0.0, 0.0, 0.0);
            GL.Vertex3(0.0, 5.0, 0.0);
            GL.End();

            GL.Color3(0.0, 0.0, 1.0);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex3(0.0, 0.0, 0.0);
            GL.Vertex3(0.0, 0.0, 5.0);
            GL.End();

            GL.PopMatrix();
        }
    }
}
