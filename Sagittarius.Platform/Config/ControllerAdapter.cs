
namespace Sagittarius.Platform.Config;


class ControllerAdapter{

    private dllClass Controller;

    public ControllerAdapter(dllClass Controller) {
        this.Controller = Controller;
    }

    public IView GetView() {
        return (IView)Controller.Method("GetView");
    }

    public void Active() { Controller.Method("Active"); }
    public void Deactive() { Controller.Method("Deactive"); }

    public void Updata(FrameEventArgs args) { Controller.Method("Updata", new object[] { args.Time });}

    public virtual void MouseMove(MouseMoveEventArgs args) { Controller.Method("MouseMove", new object[] { args.X, args.Y }); }
    public virtual void OnKeyUp(KeyboardKeyEventArgs args) { Controller.Method("OnKeyUp", new object[] { (char)args.Key }); }
    public virtual void OnKeyDown(KeyboardKeyEventArgs args) { Controller.Method("OnKeyDown", new object[] { (char)args.Key }); }

}
