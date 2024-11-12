using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlanet : MonoBehaviour
{
    public static PlayerPlanet Instance;
    private Planet currentPlanet;

    public float moveSpeed = 5f;

    [SerializeField] private Planet start;

    private void Awake()
    {
        Instance = this;

        SetStartingPlanet(start);
    }

    public void SetStartingPlanet(Planet planet)
    {
        currentPlanet = planet;
        transform.position = planet.transform.position;
    }

    public void MoveToPlanet(Planet targetPlanet)
    {
        if (currentPlanet == null || targetPlanet == null || currentPlanet == targetPlanet)
        {
            return;
        }

        var connections = currentPlanet.graph.GetConnections(currentPlanet);
        int travelCost = -1;

        foreach (var connection in connections)
        {
            if (connection.Item1 == targetPlanet)
            {
                travelCost = connection.Item2;
                break;
            }
        }

        if (travelCost >= 0)
        {
            Debug.Log($"Viajando de {currentPlanet.planetName} a {targetPlanet.planetName} con un costo de {travelCost}");
            StartCoroutine(Travel(targetPlanet, travelCost));
        }
        else
        {
            Debug.Log("No hay una conexión directa a este planeta.");
        }
    }

    private System.Collections.IEnumerator Travel(Planet targetPlanet, int cost)
    {
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = targetPlanet.transform.position;
        float journey = 0f;

        while (journey < 1f)
        {
            journey += Time.deltaTime * moveSpeed;
            transform.position = Vector3.Lerp(startPosition, targetPosition, journey);
            yield return null;
        }

        currentPlanet = targetPlanet;
    }
}
