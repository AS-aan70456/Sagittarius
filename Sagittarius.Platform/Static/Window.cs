using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System;


namespace Sagittarius.Platform{
    class Window : GameWindow{

        private double fps = 0f;
        private double offsetTime;

        private KeyBoard keyBoard;

        public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings, KeyBoard keyBoard)
        : base(gameWindowSettings, nativeWindowSettings){
            VSync = VSyncMode.On;

            Console.WriteLine(GL.GetString(StringName.Version));
            Console.WriteLine(GL.GetString(StringName.Vendor));
            Console.WriteLine(GL.GetString(StringName.Renderer));
            Console.WriteLine(GL.GetString(StringName.ShadingLanguageVersion));

            this.keyBoard = keyBoard;
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
            keyBoard.KeyDown(e.Key);
        }

        protected override void OnKeyUp(KeyboardKeyEventArgs e){
            base.OnKeyDown(e);
            keyBoard.KeyUp(e.Key);
        }

    }
}
