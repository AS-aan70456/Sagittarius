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

    public override void Updata(double args){

    }
}

