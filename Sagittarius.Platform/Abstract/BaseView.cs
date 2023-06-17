using System;


namespace Sagittarius.Platform.Abstract{
    public interface BaseView{

        void Render();

        void Active(Screen screen);
        void Deactive();
    }
}
