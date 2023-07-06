using Sagittarius.Platform.Config;

namespace Sagittarius.Platform;

#pragma warning disable CS8618

class Window : GameWindow{
    private double fps = 0f;
    private double offsetTime;

    private SceneAdapter currentScene;

    public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings)

    : base(gameWindowSettings, nativeWindowSettings){
        VSync = VSyncMode.On;
        //CursorVisible = false;


        Console.WriteLine(GL.GetString(StringName.Version));
        Console.WriteLine(GL.GetString(StringName.Vendor));
        Console.WriteLine(GL.GetString(StringName.Renderer));
        Console.WriteLine(GL.GetString(StringName.ShadingLanguageVersion));

    }

    public void LoadScene(SceneAdapter Scene) {
        currentScene = Scene;
    }

    protected override void OnLoad(){
        base.OnLoad();


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

        currentScene.Updata(args);
    }

    protected override void OnRenderFrame(FrameEventArgs args){
        base.OnRenderFrame(args);

        Router.Screen.Render();

        SwapBuffers();
    }

    protected override void OnKeyDown(KeyboardKeyEventArgs e){
        base.OnKeyDown(e);
        KeyBoard.KeyDown(e.Key);
        currentScene.OnKeyDown(e);
    }

    protected override void OnKeyUp(KeyboardKeyEventArgs e){
        base.OnKeyDown(e);
        KeyBoard.KeyUp(e.Key);
        currentScene.OnKeyUp(e);
    }

    protected override void OnMouseMove(MouseMoveEventArgs e){
        base.OnMouseMove(e);
        currentScene.MouseMove(e);
    }
}

