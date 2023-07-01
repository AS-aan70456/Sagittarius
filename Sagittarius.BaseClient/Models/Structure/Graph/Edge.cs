using System;

namespace Sagittarius.BaseClient.Model;

class Edge{

    public int weight;
    public Node AdjacentNode { get; set; }

    public Edge(Node adjacentNode, int weight) {
        this.AdjacentNode = adjacentNode;
        this.weight = weight;
    }
}
