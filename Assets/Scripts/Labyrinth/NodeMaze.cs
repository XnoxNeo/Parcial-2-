using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeMaze
{
    public Vector2Int Position { get; private set; }
    public List<NodeMaze> Neighbors { get; private set; }

    public NodeMaze(int x, int y)
    {
        Position = new Vector2Int(x, y);
        Neighbors = new List<NodeMaze>();
    }

    public void AddNeighbor(NodeMaze neighbor)
    {
        Neighbors.Add(neighbor);
    }
}
