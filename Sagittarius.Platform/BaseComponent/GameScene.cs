using Sagittarius.Graphics;
using System.Diagnostics.Metrics;
using System.Drawing;

namespace Sagittarius.Platform.BaseComponent;

public class GameScene : BaseScene{

    private FrameBuffer frameBuffer;
    private Camera camera;

    public GameScene(IRender render) : base(render){}

    public override void Update(double args){
        base.Update(args);

        DrawDisplay();
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

    private void DrawDisplay(){
        for (int i = 0; i < camera.countRey; i++)
            DrawFlore(camera.reyContainer[i].GetFloreHit(), i);
        
        for (int i = 0; i < camera.countRey; i++)
            DrawWall((HitWall)camera.reyContainer[i].GetLastHit(new HitWall().GetType()), i);
    }

    private void DrawFlore(IEnumerable<Hit> HitsFlore, int index){

        Hit preHitFlore = null;


        foreach (Hit hitFlore in HitsFlore) {
            if (preHitFlore == null)
                preHitFlore = new HitFlore(){
                    ReyDistance = 0,
                    ReyPoint = camera.Center,
                    Wall = hitFlore.Wall,
                };

            Color color = Color.Yellow;

            if (((float)((int)hitFlore.ReyPoint.X + (int)hitFlore.ReyPoint.Y)) % 2f == 0)
                color = Color.Green;

            frameBuffer.Fill(
            (int)(preHitFlore.ReyDistance * 25),
            index,
            (int)(hitFlore.ReyDistance * 25),
            index + 1,
            color
            );
        }
    }

    private void DrawWall(HitWall HitWall, int index){
        frameBuffer.Fill(
            (int)((frameBuffer.Height / 2) * (1 - (1 / HitWall.ReyDistance))),
            index,
            (int)((frameBuffer.Height / 2) * (1 + (1 / HitWall.ReyDistance))),
            index + 1,
            HitWall.Wall.textureHprizontal.GetSlice((int)(HitWall.offset * 16))
        );
    }
}
