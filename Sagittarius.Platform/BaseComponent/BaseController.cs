namespace Sagittarius.Platform;

public class BaseController {

    protected IView View {  get; set; }


    public IView GetView() { return View; }
    protected void SetView(IView View) { this.View = View;  }

    public virtual void Active() { }
    public virtual void Deactive() { }

    public virtual void Updata(FrameEventArgs args) { }

    public virtual void MouseMove(MouseMoveEventArgs e) { }
    public virtual void OnKeyUp(KeyboardKeyEventArgs e) { }
    public virtual void OnKeyDown(KeyboardKeyEventArgs e) { }
}