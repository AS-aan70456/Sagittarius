using OpenTK.Windowing.Desktop;
using Sagittarius.Platform.Abstract;
using System;

namespace Sagittarius.Platform{
    public static class Router{

        public static BaseController CurrentController { get; private set; }
        public static Screen Screen { get; private set; }

        private static Window window;

        public static void Init(NativeWindowSettings nativeWinSettings) {

            Router.window = new Window(GameWindowSettings.Default, nativeWinSettings);
            Screen = new Screen((uint)window.Size.X, (uint)window.Size.Y);

        }

        public static void Start(BaseController controller){
            if (CurrentController == null){
                CurrentController = controller;
                CurrentController.Active();

                Screen.LoadView(CurrentController.View);

                window.Run();
                return;
            }

            CurrentController.Deactive();
            CurrentController = controller;
            CurrentController.Active();

            Screen.LoadView(CurrentController.View);
        }
    }
}
