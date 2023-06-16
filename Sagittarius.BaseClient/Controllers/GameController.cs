using OpenTK.Windowing.Common;
using Sagittarius.BaseClient.View;
using Sagittarius.Platform.Abstract;
using System;


namespace Sagittarius.BaseClient.Controllers{
    class GameController : BaseController{

        private GameView gameView;

        

        public GameController() : base() {
            gameView = new GameView();

            

            View = gameView;
        }


        public override void Active(){
            
        }

        public override void Deactive(){
            
        }

        public override void Updata(FrameEventArgs args){
            
        }
    }
}
