using Sagittarius.Graphics;
using System.Diagnostics.Metrics;

namespace Sagittarius.Platform.BaseComponent;

public class GameScene : BaseScene{

    private FrameBuffer frameBuffer;
    private Camera camera;

    public GameScene(IRender render) : base(render){}

    public override void Update(double args){
        base.Update(args);

        DrawWalls();
    }

    public override void Render(){
        frameBuffer.Draw();

        frameBuffer.ClearBuffer();
        base.Render();
    }

    public void LoadCamera(Camera camera) {
        this.camera = camera;

        frameBuffer = new FrameBuffer(
            (uint)(camera.countRey),
            (uint)(screan.Height / (screan.Width / camera.countRey))
        );

        base.AddComponent(this.camera);
    }

    private void DrawWalls(){
        for (int i = 0; i < camera.countRey; i++)
            DrawWall((HitWall)camera.reyContainer[i].GetLastHit(new HitWall()), i);
    }

    private void DrawWall(HitWall HitWall, int index)
    {
        frameBuffer.Fill(
            (int)((frameBuffer.Height / 2) * (1 - (1 / HitWall.ReyDistance))),
            index,
            (int)((frameBuffer.Height / 2) * (1 + (1 / HitWall.ReyDistance))),
        index + 1,
        System.Drawing.Color.White
        );
    }
}
