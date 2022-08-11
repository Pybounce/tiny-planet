using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PybUtilities;

public class PlanetGenerator : MonoBehaviour
{
    private PlanetTerrainGenerator planetTerrainGenerator;
    private PlanetEnvironmentGenerator planetEnvironmentGenerator;

    [SerializeField] private GroundEnvironmentConfig[] groundEnvironmentConfigs;
    [SerializeField] private PlanetTerrainConfig planetTerrainConfig;

    void Awake()
    {
        planetTerrainGenerator = this.gameObject.AddComponent<PlanetTerrainGenerator>();
        planetEnvironmentGenerator = this.gameObject.AddComponent<PlanetEnvironmentGenerator>();
    }

    private void Start()
    {
        Generate();
    }

    public void Initialise()
    {
    }

    public void Generate()
    {
        planetTerrainGenerator.Initialise(planetTerrainConfig);
        planetTerrainGenerator.Generate();

        planetEnvironmentGenerator.Initialise(planetTerrainGenerator.TerrainMesh.vertices, groundEnvironmentConfigs);
        planetEnvironmentGenerator.Generate();
    }
}
