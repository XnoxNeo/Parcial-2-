using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabyrinthSolver : MonoBehaviour
{
    public LabyrinthGenerator generator;

    public Vector2Int start = new Vector2Int(0, 0);
    public Vector2Int exit = new Vector2Int(4, 4);

    public List<NodeMaze> path;


    private void Awake()
    {
        if (generator == null)
        {
            generator = FindObjectOfType<LabyrinthGenerator>();
            if (generator == null)
            {
                Debug.LogError("Generator has not been found");

                return;
            }

        }

        generator.GenerateLabyrinth();

        NodeMaze startNode = generator.GetNode(start.x, start.y);
        NodeMaze exitNode = generator.GetNode(exit.x, exit.y);

        path = FindPath(startNode, exitNode);
        if (path != null)
        {
            Debug.Log("A path has been found");
            foreach (var node in path)
            {
                Debug.Log($"Step: {node.Position}");
            }
        }
        else
        {
            Debug.Log("No path has been found");
        }
    }
    private void Start()
    {

    }

    public List<NodeMaze> FindPath(NodeMaze start, NodeMaze goal)
    {
        Queue<NodeMaze> queue = new Queue<NodeMaze>();

        Dictionary<NodeMaze, NodeMaze> cameFrom = new Dictionary<NodeMaze, NodeMaze>();

        queue.Enqueue(start);

        cameFrom[start] = null;

        while (queue.Count > 0)
        {
            NodeMaze current = queue.Dequeue();

            if (current == goal)
            {
                return ReconstructPath(cameFrom, start, goal);
            }

            foreach (NodeMaze neighbor in current.Neighbors)
            {
                if (!cameFrom.ContainsKey(neighbor))
                {
                    queue.Enqueue(neighbor);

                    cameFrom[neighbor] = current;
                }
            }
        }

        return null;
    }

    public List<NodeMaze> ReconstructPath(Dictionary<NodeMaze, NodeMaze> cameFrom, NodeMaze start, NodeMaze goal)
    {
        List<NodeMaze> path = new List<NodeMaze>();

        for (NodeMaze at = goal; at != null; at = cameFrom[at])
        {
            path.Add(at);
        }

        path.Reverse();
        return path;
    }
}
