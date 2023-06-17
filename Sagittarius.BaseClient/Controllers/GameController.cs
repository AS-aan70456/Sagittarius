using OpenTK.Windowing.Common;
using OpenTK.Mathematics;
using Sagittarius.BaseClient.View;
using Sagittarius.Core.Entitys;
using Sagittarius.Platform.Abstract;
using System;
using Sagittarius.Core.System;
using Sagittarius.Platform;

namespace Sagittarius.BaseClient.Controllers{
    class GameController : BaseController{

        private Level level;
        private Camera camera;
        private GameView gameView;

        public GameController() : base() {

            level = new Level(new char[,] {
                { '1','1','1','1','1','1','1','1' },
                { '1',' ',' ',' ',' ',' ',' ','1' },
                { '1',' ',' ',' ',' ',' ',' ','1' },
                { '1',' ',' ',' ',' ',' ',' ','1' },
                { '1',' ',' ',' ',' ',' ',' ','1' },
                { '1',' ',' ',' ',' ',' ',' ','1' },
                { '1',' ',' ',' ',' ',' ',' ','1' },
                { '1',' ',' ',' ',' ',' ',' ','1' },
                { '1',' ',' ',' ',' ',' ',' ','1' },
                { '1','1','1','1','1','1','1','1' }
            });

            camera = new Camera(new EntitySettings{
                Position = new Vector3(2, 2, 0.5f),
                Size = new Vector2(0.5f, 0.5f)

            }, level);
            camera.countRey = 512;
            camera.fov = 75;
            camera.depth = 16;


            gameView = new GameView(camera);

            View = gameView;
        }


        public override void Active(){
            
        }

        public override void Deactive(){
            
        }

        public override void Updata(FrameEventArgs args){

            if(Router.KeyBoard.IsKeyPressed('W'))
                camera.Move(0.1f, 0);
            if (Router.KeyBoard.IsKeyPressed('S'))
                camera.Move(-0.1f, 0);
            if (Router.KeyBoard.IsKeyPressed('A'))
                camera.Move(0, 0.1f); ;
            if (Router.KeyBoard.IsKeyPressed('D'))
                camera.Move(0, -0.1f);
            if (Router.KeyBoard.IsKeyPressed('Q'))
                camera.RotateX(1);
            if (Router.KeyBoard.IsKeyPressed('E'))
                camera.RotateX(-1);



            camera.Look();
            gameView.UpdataBuffer();
        }
    }
}
