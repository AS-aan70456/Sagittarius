namespace Sagittarius.Platform;

public interface IView{
    void Render();

    void Active(Screen screen);
    void Deactive();
}

