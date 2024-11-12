using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public string planetName; 
    public Graph<Planet> graph; 

    private void OnMouseDown()
    {
        PlayerPlanet.Instance.MoveToPlanet(this);
    }
}
