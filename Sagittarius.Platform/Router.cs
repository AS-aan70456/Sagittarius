using Sagittarius.Platform.Config;

namespace Sagittarius.Platform;

static class Router{

    private static SceneAdapter currentScene;

    public static Screen Screen;
    private static Window window;

    public static void Init(NativeWindowSettings nativeWinSettings) {

        Router.window = new Window(GameWindowSettings.Default, nativeWinSettings);
        Screen = new Screen((uint)window.Size.X, (uint)window.Size.Y);

    }

    public static void Redirect(SceneAdapter currentController){
        if (Router.currentScene == null){
            Router.currentScene = currentController;
            Router.currentScene.Active();

            Screen.LoadScene(Router.currentScene);
            window.LoadScene(currentController);

            window.Run();
            return;
        }

        Router.currentScene.Deactive();
        Router.currentScene = currentController;
        Router.currentScene.Active();

        Screen.LoadScene(Router.currentScene);
        window.LoadScene(Router.currentScene);
    }
}

