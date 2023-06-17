using OpenTK.Graphics.OpenGL;
using Sagittarius.Platform.Abstract;
using System;


namespace Sagittarius.Platform{
    public class Screen{

        private BaseView View;

        public uint Width { get; }
        public uint Height { get; }

        public Screen(uint Width, uint Height) {
            this.Width = Width;
            this.Height = Height;
        
        }

        public void Render() {
            View?.Render();
        }

        public void LoadView(BaseView View) {
            this.View?.Deactive();
            this.View = View;
            this.View.Active(this);
        }

        public void DrawTexture(int t){
            GL.Enable(EnableCap.Texture2D);
            GL.Begin(PrimitiveType.Quads);

            GL.BindTexture(TextureTarget.Texture2D, t);
            GL.TexCoord2(0.0f, 0.0f);
            GL.Vertex2(-1.0f, 1.0f);

            GL.TexCoord2(0.0f, 1.0f);
            GL.Vertex2(-1.0f, -1.0f);

            GL.TexCoord2(1.0f, 1.0f);
            GL.Vertex2(1.0f, -1.0f);

            GL.TexCoord2(1.0f, 0.0f);
            GL.Vertex2(1.0f, 1.0f);

            GL.End();
        }

    }
}
