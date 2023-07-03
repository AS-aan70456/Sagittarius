namespace VAO;

class VAO{

    private int indexVAO;

    private VBO colorVBO;
    private VBO vertexVBO;

    public VAO(float[] VertexArrey, float[] ColorArrey){
        vertexVBO = new VertexVBO(VertexArrey);
        colorVBO = new ColorVBO(ColorArrey);

        InitVAO();
    }

    ~VAO(){
        GL.DeleteVertexArray(indexVAO);
    }

    private void InitVAO(){
        indexVAO = GL.GenVertexArray();
        GL.BindVertexArray(indexVAO);

        vertexVBO.SendVBO();
        colorVBO.SendVBO();

        GL.BindVertexArray(0);
    }

    public void DrawVAO(){
        GL.BindVertexArray(indexVAO);
        GL.DrawArrays(PrimitiveType.TriangleStrip, 0, 4);
        GL.BindVertexArray(0);
    }
}

