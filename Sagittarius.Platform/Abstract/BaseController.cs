using OpenTK.Windowing.Common;
using System;


namespace Sagittarius.Platform.Abstract{
    public abstract class BaseController {

        public BaseView View { get; protected set; }

        public BaseController() {}

        public abstract void Active();
        public abstract void Deactive();

        public abstract void Updata(FrameEventArgs args);

        public virtual void MouseMove(Window sender, MouseMoveEventArgs e) { }
        public virtual void OnKeyUp(Window sender, KeyboardKeyEventArgs e) { }
        public virtual void OnKeyDown(Window sender, KeyboardKeyEventArgs e) { }
    }
}
