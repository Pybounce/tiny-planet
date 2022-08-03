using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlanetGenerator))]
public class PlanetTerrainGenerator : MonoBehaviour
{
    private string aa;
    public void Initialise(string a)
    {
        this.aa = a;
    }
}
