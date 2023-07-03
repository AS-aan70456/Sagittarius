using Sagittarius.BaseClient.Views;
using Sagittarius.Core;
using System.Reflection.Emit;

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

        level.AddEntity(camera);

        GameView View = new GameView(camera);
        base.View = View;
    }

    public override void Active(){

    }

    public override void Deactive(){
        
    }

    public override void Updata(double args){

        Vector2 velocity = new Vector2();

        if (KeyBoard.IsKeyPressed('W'))
            velocity += (5f, 0f);
        if (KeyBoard.IsKeyPressed('S'))
            velocity += (-5f, 0f);
        if (KeyBoard.IsKeyPressed('A'))
            velocity += (0f, 2f);
        if (KeyBoard.IsKeyPressed('D'))
            velocity += (0f, -2f);
        if (KeyBoard.IsKeyPressed('Q'))
            camera.RotateX(50, args);
        if (KeyBoard.IsKeyPressed('E'))
            camera.RotateX(-50, args);

        camera.Move(velocity, args);
        level.UpdataLevel(args);

        camera.Look();
        ((GameView)View).UpdataBuffer();
    }
}

