using System;


namespace Sagittarius.Platform.Abstract{
    public interface BaseView{

        void Render(Screen screen);

        void Active();
        void Deactive();
    }
}
