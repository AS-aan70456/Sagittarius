using Sagittarius.Graphics;

namespace Sagittarius.Platform.BaseComponent;

public class BaseScene : IComponent{

    private List<IComponent> gameElements;
    protected IRender screan;

    public BaseScene(){}

    public BaseScene(IRender screan) {
        this.gameElements = new List<IComponent>();
        this.screan = screan;
    }

    public virtual void Start(){}
   
    public virtual  void Update(double args){
        foreach (IComponent el in gameElements)
            el.Update(args);
    }

    public virtual void Render(){
        foreach (IRenderComponent el in gameElements)
            screan.Draw(el);
    }

    public virtual void End(){

    }

    protected void AddComponent(IComponent component) {
        gameElements.Add(component);
    }

}
