using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabyrinthGenerator : MonoBehaviour
{
    public GameObject wallPrefab;
    public GameObject pathPrefab;
    public int width = 5;
    public int height = 5;

    public NodeMaze[,] nodes;
    public int[,] labyrinth = {
        {1, 1, 1, 1, 1},
        {0, 0, 0, 0, 1},
        {1, 1, 1, 1, 1},
        {0, 0, 1, 0, 0},
        {1, 1, 1, 1, 1}
    };

    public void GenerateLabyrinth()
    {
        nodes = new NodeMaze[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3 position = new Vector3(x, y, 0);

                if (labyrinth[x, y] == 1)
                {
                    Instantiate(pathPrefab, position, Quaternion.identity, transform);
                    nodes[x, y] = new NodeMaze(x, y);
                }
                else
                {
                    Instantiate(wallPrefab, position, Quaternion.identity, transform);
                }
            }
        }

        
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (nodes[x, y] != null)
                {
                    if (x > 0 && nodes[x - 1, y] != null)
                    {
                        nodes[x, y].AddNeighbor(nodes[x - 1, y]);
                    }

                    if (x < width - 1 && nodes[x + 1, y] != null)
                    {
                        nodes[x, y].AddNeighbor(nodes[x + 1, y]);
                    }

                    if (y > 0 && nodes[x, y - 1] != null)
                    {
                        nodes[x, y].AddNeighbor(nodes[x, y - 1]);
                    }

                    if (y < height - 1 && nodes[x, y + 1] != null)
                    {
                        nodes[x, y].AddNeighbor(nodes[x, y + 1]);
                    }
                }
            }
        }
    }

    public NodeMaze GetNode(int x, int y)
    {
        return nodes[x, y];
    }
}
