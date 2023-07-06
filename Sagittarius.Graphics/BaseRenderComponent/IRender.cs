namespace Sagittarius.Graphics;

public interface IRender{

    uint Width { get; }
    uint Height { get; }

    void Draw(IRenderComponent renderComponent);

}

