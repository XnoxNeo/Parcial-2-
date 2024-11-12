using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph<T>
{
    private Dictionary<T, List<(T, int)>> nodes = new Dictionary<T, List<(T, int)>>();
    public void AddNode(T node)
    {
        if (!nodes.ContainsKey(node))
        {
            nodes[node] = new List<(T, int)>();
        }
    }
    public void AddEdge(T from, T to, int cost)
    {
        if (nodes.ContainsKey(from) && nodes.ContainsKey(to))
        {
            nodes[from].Add((to, cost));
        }
    }
    public List<(T, int)> GetConnections(T node)
    {
        if (nodes.ContainsKey(node))
        {
            return nodes[node];
        }
        return null;
    }
}
