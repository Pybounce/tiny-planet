using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlanetTerrainConfig_", menuName = "Scriptable Objects/Planet Terrain Config")]
public class PlanetTerrainConfig : ScriptableObject
{
    public int Density = 1;
    public float Radius = 1f;
}
