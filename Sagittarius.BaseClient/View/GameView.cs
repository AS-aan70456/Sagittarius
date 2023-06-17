using OpenTK.Graphics.OpenGL4;
using Sagittarius.Core.Entitys;
using Sagittarius.Platform;
using Sagittarius.Platform.Abstract;
using Sagittarius.Graphics;

using System;
using System.Drawing;
using System.Collections;
using Sagittarius.Core.Reycasting;

namespace Sagittarius.BaseClient.View{
    class GameView : BaseView{

        FrameBuffer frameBuffer;
        Camera currentCamera;

        public GameView(Camera camera) {
            currentCamera = camera;
        }

        public void Active(Screen screen){

            frameBuffer = new FrameBuffer(
                (uint)(currentCamera.countRey),
                (uint)(screen.Height / (screen.Width / currentCamera.countRey))
            );

            
        }

        public void Deactive(){
            
        }

        public void Render(){
            frameBuffer.Draw();
        }

        public void UpdataBuffer() {
            frameBuffer.ClearBuffer();

            DrawWalls();

        }

        private void DrawWalls() {
            for (int i = 0; i < currentCamera.countRey ;i++) 
                    DrawWall((HitWall)currentCamera.reyContainer[i].GetLastHit(new HitWall()), i);
        }

        private void DrawWall(HitWall HitWall, int index){

            frameBuffer.Fill(
                (int)((frameBuffer.Height / 2) * (1 - (1 / HitWall.ReyDistance))),
                index,
                (int)((frameBuffer.Height / 2) * (1 + (1 / HitWall.ReyDistance))),
                index + 1,
                Color.White
            );
        }


    }
}
