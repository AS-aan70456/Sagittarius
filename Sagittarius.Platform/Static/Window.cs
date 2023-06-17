using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using System;


namespace Sagittarius.Platform{
    public class Window : GameWindow{

        private double fps = 0f;
        private double offsetTime;

        public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings)
        : base(gameWindowSettings, nativeWindowSettings){
            VSync = VSyncMode.On;
            CursorVisible = false;

            Console.WriteLine(GL.GetString(StringName.Version));
            Console.WriteLine(GL.GetString(StringName.Vendor));
            Console.WriteLine(GL.GetString(StringName.Renderer));
            Console.WriteLine(GL.GetString(StringName.ShadingLanguageVersion));

        }

        protected override void OnResize(ResizeEventArgs e){
            GL.Viewport(0, 0, Size.X, Size.Y);
            base.OnResize(e);
        }

        protected override void OnUpdateFrame(FrameEventArgs args){
            base.OnUpdateFrame(args);
            offsetTime += args.Time;
            fps++;

            if (offsetTime >= 1.0f){
                Title = fps.ToString();
                offsetTime = 0;
                fps = 0;
            }

            Router.CurrentController.Updata(args);
        }

        protected override void OnRenderFrame(FrameEventArgs args){
            base.OnRenderFrame(args);

            Router.Screen.Render();

            SwapBuffers();
        }

        protected override void OnKeyDown(KeyboardKeyEventArgs e){
            base.OnKeyDown(e);
            KeyBoard.KeyDown(e.Key);
            Router.CurrentController.OnKeyDown(this, e);
        }

        protected override void OnKeyUp(KeyboardKeyEventArgs e){
            base.OnKeyDown(e);
            KeyBoard.KeyUp(e.Key);
            Router.CurrentController.OnKeyUp(this, e);
        }

        protected override void OnMouseMove(MouseMoveEventArgs e){
            base.OnMouseMove(e);
            Router.CurrentController.MouseMove(this, e);
        }
    }
}
