namespace Sagittarius.Graphics;

public class FrameBuffer : IRenderItem{

    public uint Height { get; }
    public uint Width { get; }

    private Byte[,] _buffer;
    private int _gltexture = -1;

    public FrameBuffer(uint width, uint height) {

        Width = width;
        Height = height;

        _buffer = new byte[height, width * 3];

        GL.GenTextures(1, out _gltexture);

    }


    ~FrameBuffer(){
        GL.DeleteTexture(_gltexture);
    }

    public void Draw() {

        // Init texture
        GL.BindTexture(TextureTarget.Texture2D, _gltexture);

        GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, (int)Width, (int)Height, 0,
            PixelFormat.Rgb, PixelType.UnsignedByte, _buffer);

        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);

        GL.Enable(EnableCap.Texture2D);
        GL.Begin(PrimitiveType.Quads);

        // Draw texture
        GL.BindTexture(TextureTarget.Texture2D, _gltexture);
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


    public void ClearBuffer() {
        _buffer = new byte[Height, Width * 3];
    }

    public void SetPixel(int X, int Y, Color color){
        int ox = X * 3;
        int oy = Y;
        _buffer[oy, ox] = color.R;
        _buffer[oy, ox + 1] = color.G;
        _buffer[oy, ox + 2] = color.B;
    }


    public void FillRelative(int X, int Y, int width, int height, Color color) {

        for (int y = X; y < height + X; y++){
            for (int x = Y; x < width + Y; x++){
                SetPixel(x, y, color);
            }
        }
    }

    public void Fill(int X1, int Y1, int X2, int Y2, Color color){

        if (X1 > Height) X1 = (int)Height;
        if (X1 < 0) X1 = 0;

        if (Y1 > Width) Y1 = (int)Width;
        if (Y1 < 0) X1 = 0;

        if (X2 > Height) X2 = (int)Height;
        if (X2 < 0) X2 = 0;

        if (Y2 > Width) Y2 = (int)Width;
        if (Y2 < 0) Y2 = 0;

        for (int y = X1; y < X2; y++){
            for (int x = Y1; x < Y2; x++){
                SetPixel(x, y,color);
            }
        }
    }

}
