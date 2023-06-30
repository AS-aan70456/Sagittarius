
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

    public void Updata(FrameEventArgs args) { Controller.Method("Deactive", new object[] { args });}

    public virtual void MouseMove(MouseMoveEventArgs e) { }
    public virtual void OnKeyUp(KeyboardKeyEventArgs e) { }
    public virtual void OnKeyDown(KeyboardKeyEventArgs e) { }

}
