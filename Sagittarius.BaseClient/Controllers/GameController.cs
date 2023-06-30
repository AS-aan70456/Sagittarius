using OpenTK.Windowing.Common;
using Sagittarius.BaseClient.Views;
using Sagittarius.Platform;

namespace Sagittarius.BaseClient.Controllers;

public class GameController : BaseController {

    public GameController() {
        GameView View = new GameView();
        base.View = View;
    }

    public override void Active(){

    }

    public override void Deactive(){
        
    }

    public override void Updata(FrameEventArgs args){
       
    }
}

