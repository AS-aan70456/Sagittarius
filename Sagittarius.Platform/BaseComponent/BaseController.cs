namespace Sagittarius.Platform;

public class BaseController {

    protected IView View {  get; set; }


    public IView GetView() { return View; }
    protected void SetView(IView View) { this.View = View;  }

    public virtual void Active() { }
    public virtual void Deactive() { }

    public virtual void Updata(double time) { }

    public virtual void MouseMove(float x, float y) { }
    public virtual void OnKeyUp(char key) { }
    public virtual void OnKeyDown(char key) { }
}