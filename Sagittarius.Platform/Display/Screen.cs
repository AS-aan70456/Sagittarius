using Sagittarius.Core;
using Sagittarius.Graphics;

namespace Sagittarius.Platform;

#pragma warning disable CS8618

public class Screen{
    public Camera currentCamera { get; set; } 
    private IView View;

    public uint Width { get; }
    public uint Height { get; }

    public Screen(uint Width, uint Height){
        this.Width = Width;
        this.Height = Height;

    }

    public void Render(){
        View?.Render();
    }


    public void LoadView(IView View){
        this.View?.Deactive();
        this.View = View;
        this.View.Active(this);
    }
}

