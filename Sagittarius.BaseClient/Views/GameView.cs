using Sagittarius.Platform;

namespace Sagittarius.BaseClient.Views;

class GameView : IView{
    Screen screen;

    public void Active(Screen screen){
        this.screen = screen;
    }

    public void Deactive(){
        
    }

    public void Render(){
        
    }
}

