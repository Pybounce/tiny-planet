using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PybUtilities;

public class PlanetGenerator : MonoBehaviour
{
    private PlanetTerrainGenerator planetTerrainGenerator;
    private PlanetEnvironmentGenerator planetEnvironmentGenerator;

    private void Awake()
    {
        planetTerrainGenerator = this.gameObject.AddComponent<PlanetTerrainGenerator>();
        planetEnvironmentGenerator = this.gameObject.AddComponent<PlanetEnvironmentGenerator>();

    }
}
