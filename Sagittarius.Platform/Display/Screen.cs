using Sagittarius.Graphics;
using Sagittarius.Platform.BaseComponent;
using System.Drawing;

namespace Sagittarius.Platform;

#pragma warning disable CS8618

internal class Screen : IRender{
    private SceneAdapter baseScene;

    public uint Width { get; }
    public uint Height { get; }

    public Screen(uint Width, uint Height){
        this.Width = Width;
        this.Height = Height;
    }

    public void LoadScene(SceneAdapter baseScene){
        this.baseScene = baseScene;
    }

    public void Render(){
        baseScene?.Render();
    }

    public void Draw(IRenderComponent component){
        
    }

}

