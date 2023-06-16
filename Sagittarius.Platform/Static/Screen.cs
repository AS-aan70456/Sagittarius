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
            View?.Render(this);
        }

        public void LoadView(BaseView View) {
            this.View?.Deactive();
            this.View = View;
            this.View.Active();
        }

    }
}
