namespace Sagittarius.Platform;

static class Router{

    private static dllClass currentController;

    public static void Init() {
    
    }

    public static void Redirect(dllClass currentController){
        Router.currentController = currentController;
    }

}

