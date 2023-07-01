using Sagittarius.BaseClient.Views;
using Sagittarius.Core;

namespace Sagittarius.BaseClient.Controllers;

public class GameController : BaseController {

    private Level level;
    private Camera camera;

    public GameController() {

        level = new DungeonsGenerator(567).GenerateDungeon(new Vector2i(32, 48), 8, 8);

        camera = new Camera(new EntitySettings{
            Position = new Vector3(level.SpawnPoint.X, level.SpawnPoint.Y, 0.5f),
            Size = new Vector2(0.5f, 0.5f)
        }, level);
        camera.countRey = 512;
        camera.fov = 60;
        camera.depth = 16;

        

        GameView View = new GameView(camera);
        base.View = View;
    }

    public override void Active(){

    }

    public override void Deactive(){
        
    }

    public override void Updata(double args){

        if (KeyBoard.IsKeyPressed('W'))
            camera.Move(0.1f, 0);
        if (KeyBoard.IsKeyPressed('S'))
            camera.Move(-0.1f, 0);
        if (KeyBoard.IsKeyPressed('A'))
            camera.Move(0, 0.1f); ;
        if (KeyBoard.IsKeyPressed('D'))
            camera.Move(0, -0.1f);
        if (KeyBoard.IsKeyPressed('Q'))
            camera.RotateX(1);
        if (KeyBoard.IsKeyPressed('E'))
            camera.RotateX(-1);


        camera.Look();
        ((GameView)View).UpdataBuffer();
    }
}

