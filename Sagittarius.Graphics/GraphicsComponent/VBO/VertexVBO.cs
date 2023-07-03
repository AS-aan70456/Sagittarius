using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VAO;

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

