using OpenTK.Windowing.Common;
using System;


namespace Sagittarius.Platform.Abstract{
    public abstract class BaseController {

        public BaseController() {
            
        }

        public BaseView View { get; protected set; }

        public abstract void Active();
        public abstract void Deactive();

        public abstract void Updata(FrameEventArgs args);

    }
}
