using OpenTK.Windowing.Common;
using OpenTK.Mathematics;
using OpenTK.Input;
using Sagittarius.BaseClient.View;
using Sagittarius.Core.Entitys;
using Sagittarius.Platform.Abstract;
using System;
using Sagittarius.Core.System;
using Sagittarius.Platform;
using System.Reflection;


namespace Sagittarius.BaseClient.Controllers{
    class GameController : BaseController{

        private float prePositionX;
        private float prePositionY;

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
            camera.fov = 60;
            camera.depth = 16;


            gameView = new GameView(camera);

            View = gameView;
        }


        public override void Active(){
            
        }

        public override void Deactive(){
            
        }

        public override void Updata(FrameEventArgs args){

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
            gameView.UpdataBuffer();
        }

        public override void MouseMove(Window sender, MouseMoveEventArgs e){

            camera.RotateX((prePositionX - sender.MousePosition.X) * 0.1f);

            sender.MousePosition = sender.Size / 2;
            prePositionX = (sender.Size / 2).X;
        }

    }
}
