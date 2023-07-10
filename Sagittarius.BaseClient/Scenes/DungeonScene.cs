using Sagittarius.Graphics;
using Sagittarius.Platform.BaseComponent;

namespace Sagittarius.BaseClient.Scenes;

public class DungeonScene : GameScene{

    private Level level;
    private Camera camera;

    public DungeonScene(IRender render) : base(render){

        ResurseMeneger.LoadWall(FileSystem.GetPath(@"Resurces/Walls/Void.json"));
        ResurseMeneger.LoadWall(FileSystem.GetPath(@"Resurces/Walls/Wall.json"));
        ResurseMeneger.LoadWall(FileSystem.GetPath(@"Resurces/Walls/DoorH.json"));
        ResurseMeneger.LoadWall(FileSystem.GetPath(@"Resurces/Walls/DoorV.json"));


    }

    public override void Start(){

        level = new DungeonsGenerator(567).GenerateDungeon(new Vector2i(32, 48), 8, 8);

        camera = new Camera(new EntitySettings
        {
            Position = new Vector3(level.SpawnPoint.X, level.SpawnPoint.Y, 0.5f),
            Size = new Vector2(0.5f, 0.5f)
        }, level);
        camera.countRey = 512;
        camera.fov = 60;
        camera.depth = 16;

        level.AddEntity(camera);

        LoadCamera(camera);
        AddComponent(level);
    }

    public override void Update(double args){
        base.Update(args);

        if (KeyBoard.IsKeyPressed('W'))
            camera.Move(5f, 0f, args);
        if (KeyBoard.IsKeyPressed('S'))
            camera.Move(-5f, 0f, args);
        if (KeyBoard.IsKeyPressed('A'))
            camera.Move(0f, 2f, args);
        if (KeyBoard.IsKeyPressed('D'))
            camera.Move(0f, -2f, args);
        if (KeyBoard.IsKeyPressed('Q'))
            camera.RotateX(50, args);
        if (KeyBoard.IsKeyPressed('E'))
            camera.RotateX(-50, args);

    }

}
