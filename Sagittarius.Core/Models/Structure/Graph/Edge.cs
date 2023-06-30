using System;

namespace Sagittarius.Core.Structure;

class Edge{

    public int weight;
    public Node AdjacentNode { get; set; }

    public Edge(Node adjacentNode, int weight) {
        this.AdjacentNode = adjacentNode;
        this.weight = weight;
    }
}
