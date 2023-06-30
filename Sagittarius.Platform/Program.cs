#pragma warning disable CS8601

using Sagittarius.Platform;
using Sagittarius.Platform.Config;
using System.Numerics;

Loger.WriteLine("Starting Engine");

// load game setting
WindowSettings winSettings = FileSystem.ReadObject<WindowSettings>(@"xml\\NativeWindowSettings.xml");
EngineSettings EngSettings = FileSystem.ReadObject<EngineSettings>(@"xml\\GameSettings.xml");

var WinSettings = new NativeWindowSettings(){
    Size = new Vector2i(winSettings.SizeX, winSettings.SizeY),
    Location = new Vector2i(220, 200),
    WindowBorder = winSettings.windowBorder,
    WindowState = winSettings.windowState,
    Title = winSettings.Title,

    // Flags = ContextFlags.ForwardCompatible,
    Flags = winSettings.contextFlags,
    APIVersion = new Version(winSettings.APIVersionMajor, winSettings.APIVersionMinor),
    // Profile = ContextProfile.Core,
    Profile = winSettings.Profile,
    API = winSettings.API,

    NumberOfSamples = winSettings.NumberOfSamples,
};

// load dll game
dll dllBaseClient = new dll(@"C:\\Users\\User\\Desktop\\Released\\Sagittarius\\Sagittarius.BaseClient\\bin\\Debug\\net6.0\\Sagittarius.BaseClient.dll");
dllClass MainController = dllBaseClient.DllClass(EngSettings.mainController);

//check for presence in hierarchy
Type isType = MainController.GetInstanceType();
if ((isType.BaseType != new BaseController().GetType())) {
    Loger.WriteLine("Head controller not in hierarchy", LogMessageType.Fatal);
    return;
}

Loger.WriteLine("Starting game");

// Start game
Router.Init();
Router.Redirect(MainController);




