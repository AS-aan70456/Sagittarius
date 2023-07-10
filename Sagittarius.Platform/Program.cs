#pragma warning disable CS8601

using Sagittarius.Platform;
using Sagittarius.Platform.BaseComponent;
using Sagittarius.Platform.Config;
using System.Drawing.Text;
using System.Numerics;

Loger.WriteLine("Starting Engine");




//RepWall DoorV = new RepWall(){
//    Id = 2,
//    Name = "DoorV",
//    Half = Sagittarius.Core.Half.VerticalHalf,
//    isCollision = true,
//    isVoid = false,
//    isTransparent = false,
//    pathTextureH = "Img/Walss/Door.png",
//    pathTextureV = "Img/Walss/Door.png",
//};


//FileSystem.WriteObject<RepWall>(DoorV, @"Resurces\Walls\DoorV.json");
//FileSystem.WriteObject<RepWall>(DoorH, @"Resurces\Walls\DoorH.json");

ResurseMeneger.Init();

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

Router.Init(WinSettings);

// load dll game
dll dllBaseClient = new dll(@"C:\\Users\\User\\Desktop\\Released\\Sagittarius\\Sagittarius.BaseClient\\bin\\Debug\\net6.0\\Sagittarius.BaseClient.dll");
dllClass MainController = dllBaseClient.DllClass(EngSettings.mainController, Router.Screen);

//check for presence in hierarchy
if (MainController == null) {
    Loger.WriteLine("Head controller not found", LogMessageType.Fatal);
    return;
}

Type isType = MainController.GetInstanceType();


if (!ChangeHierarchy(isType, new BaseScene().GetType())) {
    Loger.WriteLine("Head controller not in hierarchy", LogMessageType.Fatal);
    return;
}

Loger.WriteLine("Starting game");

SceneAdapter adapter = new SceneAdapter(MainController);

// Start game
Router.Redirect(adapter);

bool ChangeHierarchy(Type Type,Type type) {
    if (Type == type) return true;
    if (Type.BaseType != null) return ChangeHierarchy(Type.BaseType, type);
    return true;
}




