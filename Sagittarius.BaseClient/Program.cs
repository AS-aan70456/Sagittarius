using System;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using Sagittarius.BaseClient.Controllers;
using Sagittarius.Platform;

namespace Sagittarius.BaseClient{
    class Program{
        static void Main(string[] args){
            var nativeWinSettings = new NativeWindowSettings(){
                Size = new Vector2i(1080, 720),
                Location = new Vector2i(220, 200),
                WindowBorder = WindowBorder.Resizable,
                WindowState = WindowState.Normal,
                Title = "LearnOpenTK - Creating a Window",

                // Flags = ContextFlags.ForwardCompatible,
                Flags = ContextFlags.Default,
                APIVersion = new Version(3, 3),
                // Profile = ContextProfile.Core,
                Profile = ContextProfile.Compatability,
                API = ContextAPI.OpenGL,

                NumberOfSamples = 0
            };

            Router.Init(nativeWinSettings);
            Router.Start(new GameController());
        }
    }
}
