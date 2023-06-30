using Sagittarius.Platform.Config;

namespace Sagittarius.Platform;

static class Router{

    private static ControllerAdapter currentController;

    public static Screen Screen;
    private static Window window;

    public static void Init(NativeWindowSettings nativeWinSettings) {

        Router.window = new Window(GameWindowSettings.Default, nativeWinSettings);
        Screen = new Screen((uint)window.Size.X, (uint)window.Size.Y);

    }

    public static void Redirect(ControllerAdapter currentController){
        if (Router.currentController == null){
            Router.currentController = currentController;
            Router.currentController.Active();

            Screen.LoadView(Router.currentController.GetView());
            window.SetController(currentController);

            window.Run();
            return;
        }

        Router.currentController.Deactive();
        Router.currentController = currentController;
        Router.currentController.Active();

        Screen.LoadView(Router.currentController.GetView());
        window.SetController(currentController);
    }
}

