using Sagittarius.Graphics;

namespace Sagittarius.Platform.Config;


class SceneAdapter{

    private dllClass Scene;

    public SceneAdapter(dllClass Scene) {
        this.Scene = Scene;
    }

    public void Active() { Scene.Method("Start"); }
    public void Deactive() { Scene.Method("End"); }

    public void Updata(FrameEventArgs args) { Scene.Method("Update", new object[] { args.Time });}
    public void Render() { Scene.Method("Render", new object[] { }); }

    public virtual void MouseMove(MouseMoveEventArgs args) { Scene.Method("MouseMove", new object[] { args.X, args.Y }); }
    public virtual void OnKeyUp(KeyboardKeyEventArgs args) { Scene.Method("OnKeyUp", new object[] { (char)args.Key }); }
    public virtual void OnKeyDown(KeyboardKeyEventArgs args) { Scene.Method("OnKeyDown", new object[] { (char)args.Key }); }

}
