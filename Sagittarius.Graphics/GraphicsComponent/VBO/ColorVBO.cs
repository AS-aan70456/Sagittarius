namespace Sagittarius.Graphics.GraphicsComponent;

class ColorVBO : VBO{

    public ColorVBO(float[] vertexces) : base(vertexces){}

    public override void SendVBO(){
        GL.EnableClientState(ArrayCap.ColorArray);
        GL.BindBuffer(BufferTarget.ArrayBuffer, indexVBO);
        GL.ColorPointer(4, ColorPointerType.Float, 0, 0);
        GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        GL.EnableClientState(ArrayCap.ColorArray);
    }
}

