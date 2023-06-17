using OpenTK.Windowing.GraphicsLibraryFramework;
using System;

namespace Sagittarius.Platform{
    public static class KeyBoard{

        private static bool[] KeyPress = new bool[350];

        public static bool IsKeyPressed(char keys) => KeyPress[(int)((Keys)keys)];
        public static bool IsKeyPressed(Keys keys) => KeyPress[(int)keys];
        public static void KeyDown(Keys keys) => KeyPress[(int)keys] = true;
        public static void KeyUp(Keys keys) => KeyPress[(int)keys] = false;
        
    }
}
