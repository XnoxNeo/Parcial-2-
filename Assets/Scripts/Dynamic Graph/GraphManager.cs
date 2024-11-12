using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphManager : MonoBehaviour
{
    public Graph<Planet> graph = new Graph<Planet>();
    public List<Planet> planets = new List<Planet>();

    void Start()
    {
        InitializeGraph();
    }
    private void InitializeGraph()
    {
        foreach (Planet planet in planets)
        {
            graph.AddNode(planet);
            planet.graph = graph;
        }

        AddConnection(planets[0], planets[1], 8);

        AddConnection(planets[1], planets[3], 4);

        AddConnection(planets[0], planets[2], 2);

        AddConnection(planets[2], planets[3], 3);

        AddConnection(planets[3], planets[7], 3);
        AddConnection(planets[2], planets[5], 5);

        AddConnection(planets[5], planets[7], 2);

        AddConnection(planets[5], planets[6], 1);
        AddConnection(planets[6], planets[8], 9);
        AddConnection(planets[6], planets[10], 15);

        AddConnection(planets[7], planets[8], 6);

        AddConnection(planets[8], planets[10], 11);
        AddConnection(planets[10], planets[11], 4);

        AddConnection(planets[1], planets[4], 9);
        AddConnection(planets[4], planets[9], 7);

        AddConnection(planets[9], planets[11], 8);
        AddConnection(planets[9], planets[8], 1);
    }
    private void AddConnection(Planet from, Planet to, int cost)
    {
        graph.AddEdge(from, to, cost);
        graph.AddEdge(to, from, cost);
    }
}
