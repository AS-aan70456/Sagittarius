namespace VAO;

abstract class VBO{

    protected int indexVBO { get; private set; }

    public VBO(float[] vertexces) {
        InitVBO(vertexces);
    }

    ~VBO(){
        GL.DeleteBuffer(indexVBO);
    }

    private void InitVBO(float[] vertexces) {
        indexVBO = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ArrayBuffer, indexVBO);
        GL.BufferData(BufferTarget.ArrayBuffer, sizeof(float) * vertexces.Length, vertexces, BufferUsageHint.DynamicDraw);
        GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
    }

    public abstract void SendVBO();
}

