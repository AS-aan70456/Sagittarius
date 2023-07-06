namespace Sagittarius.Graphics.GraphicsComponent;

class VertexVBO : VBO{

    public VertexVBO(float[] vertexces) : base(vertexces) { }

    public override void SendVBO()
    {

        GL.EnableClientState(ArrayCap.VertexArray);
        GL.BindBuffer(BufferTarget.ArrayBuffer, indexVBO);
        GL.VertexPointer(3, VertexPointerType.Float, 0, 0);
        GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        GL.EnableClientState(ArrayCap.VertexArray);

    }
}

