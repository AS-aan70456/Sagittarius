using OpenTK.Graphics.OpenGL4;
using Sagittarius.Platform;
using Sagittarius.Platform.Abstract;
using System;


namespace Sagittarius.BaseClient.View{
    class GameView : BaseView{

        //private Camera

        private Byte[,] _buffer;
        private int _gltexture = -1;


        public void Active(){
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
        }

        public void Deactive(){
            
        }

        public void Render(Screen screen){
            GL.Clear(ClearBufferMask.ColorBufferBit);

            
        }
    }
}
