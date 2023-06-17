using OpenTK.Windowing.GraphicsLibraryFramework;
using System;

namespace Sagittarius.Platform{
    public class KeyBoard{

        private bool[] KeyPress;
        
        public KeyBoard() => KeyPress = new bool[350];

        public bool IsKeyPressed(char keys) => KeyPress[(int)((Keys)keys)];
        public bool IsKeyPressed(Keys keys) => KeyPress[(int)keys];
        public void KeyDown(Keys keys) => KeyPress[(int)keys] = true;
        public void KeyUp(Keys keys) => KeyPress[(int)keys] = false;
        
    }
}
