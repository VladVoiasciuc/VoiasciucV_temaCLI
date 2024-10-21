using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;

class Program : GameWindow
{
    private float objX = 0.0f, objY = 0.0f;
    private float speed = 0.05f;

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        GL.ClearColor(0.5f, 0.0f, 0.0f, 1.0f);
        GL.MatrixMode(MatrixMode.Projection);
        GL.LoadIdentity();
        GL.Ortho(-1.0, 1.0, -1.0, 1.0, -1.0, 1.0);
    }


    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        GL.Viewport(0, 0, Width, Height);
    }

    protected override void OnRenderFrame(FrameEventArgs e)
    {
        base.OnRenderFrame(e);
        GL.Clear(ClearBufferMask.ColorBufferBit);


        GL.Begin(PrimitiveType.Triangles);
        GL.Color3(1.0, 0.0, 0.0);
        GL.Vertex2(objX - 0.1f, objY - 0.1f);
        GL.Color3(0.0, 1.0, 0.0);
        GL.Vertex2(objX + 0.1f, objY - 0.1f);
        GL.Color3(0.0, 0.0, 1.0);
        GL.Vertex2(objX, objY + 0.1f);
        GL.End();

        SwapBuffers();
    }

    protected override void OnUpdateFrame(FrameEventArgs e)
    {
        base.OnUpdateFrame(e);


        KeyboardState input = Keyboard.GetState();
        if (input.IsKeyDown(Key.W))
        {
            objY += speed;
        }
        if (input.IsKeyDown(Key.S))
        {
            objY -= speed;
        }
        if (input.IsKeyDown(Key.A))
        {
            objX -= speed;
        }
        if (input.IsKeyDown(Key.D))
        {
            objX += speed;
        }
    }

    protected override void OnMouseMove(MouseMoveEventArgs e)
    {
        base.OnMouseMove(e);


        float normalizedX = (e.X / (float)Width) * 2.0f - 1.0f;
        float normalizedY = 1.0f - (e.Y / (float)Height) * 2.0f;


        objX = normalizedX;
        objY = normalizedY;
    }

    static void Main(string[] args)
    {
        using (Program program = new Program())
        {
            program.Run(60.0);
        }
    }
}