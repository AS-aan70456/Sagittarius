namespace Sagittarius.BaseClient.Model;

#pragma warning disable CS8618 

class Node {
    public Vector2i PositionNode { get; set; }

    public List<Edge> Edges { get; set; }
    public Node Parent { get; set; }

    public Node(Vector2i nodeData) {
        PositionNode = nodeData;
        Edges = new List<Edge>();
        
    }
}
