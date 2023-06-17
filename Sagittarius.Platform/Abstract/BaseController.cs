using OpenTK.Windowing.Common;
using System;


namespace Sagittarius.Platform.Abstract{
    public abstract class BaseController {

        public BaseView View { get; protected set; }

        public BaseController() {}

        public abstract void Active();
        public abstract void Deactive();

        public abstract void Updata(FrameEventArgs args);

    }
}
