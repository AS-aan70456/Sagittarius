using OpenTK.Windowing.Desktop;
using Sagittarius.Graphics;
using System.Drawing;

namespace Sagittarius.BaseClient.Views;

#pragma warning disable CS8618 

class GameView : IView{
    private FrameBuffer frameBuffer;
    private Screen screen;
    private Camera camera;

    public GameView(Camera camera) {
        this.camera = camera;
        

    }

    public void Active(Screen screen){
        this.screen = screen;
        this.screen.currentCamera = camera;

        frameBuffer = new FrameBuffer(
           (uint)(camera.countRey),
           (uint)(screen.Height / (screen.Width / camera.countRey))
        );
    }

    public void Deactive(){
        frameBuffer.ClearBuffer();

        DrawWalls();
    }

    public void UpdataBuffer(){
        frameBuffer.ClearBuffer();

        DrawWalls();
    }

    public void Render(){
        frameBuffer.Draw();
    }

    private void DrawWalls(){
        for (int i = 0; i < camera.countRey; i++)
            DrawWall((HitWall)camera.reyContainer[i].GetLastHit(new HitWall()), i);
    }

    private void DrawWall(HitWall HitWall, int index) {
        frameBuffer.Fill(
            (int)((frameBuffer.Height / 2) * (1 - (1 / HitWall.ReyDistance))),
            index,
            (int)((frameBuffer.Height / 2) * (1 + (1 / HitWall.ReyDistance))),
            index + 1,
            Color.White
        );
    }
}

