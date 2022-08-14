using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PybUtilities;

public class PlanetGenerator : MonoBehaviour
{
    private PlanetTerrainGenerator planetTerrainGenerator;
    private PlanetEnvironmentGenerator planetEnvironmentGenerator;
    private PlanetSkyGenerator planetSkyGenerator;
    private int seed = 0;

    [SerializeField] private PlanetEnvironmentConfig planetEnvironmentConfig;
    [SerializeField] private PlanetTerrainConfig planetTerrainConfig;
    [SerializeField] private PlanetSkyConfig planetSkyConfig;

    void Awake()
    {
        planetTerrainGenerator = this.gameObject.AddComponent<PlanetTerrainGenerator>();
        planetEnvironmentGenerator = this.gameObject.AddComponent<PlanetEnvironmentGenerator>();
        planetSkyGenerator = this.gameObject.AddComponent<PlanetSkyGenerator>();
    }

    private void Start()
    {
        seed = Random.Range(1000, 100000);
        CheckNulls();
        Generate();
    }

    public void Generate()
    {
        planetSkyGenerator.Initialise(planetSkyConfig);
        planetSkyGenerator.Generate();

        planetTerrainGenerator.Initialise(planetTerrainConfig, seed);
        planetTerrainGenerator.Generate();

        planetEnvironmentGenerator.Initialise(planetTerrainGenerator.TerrainMesh.vertices, planetEnvironmentConfig, seed);
        planetEnvironmentGenerator.Generate();
    }

    private void CheckNulls()
    {
        if (planetEnvironmentConfig == null) { throw new System.Exception("Planet Environment Config is null."); }
        if (planetTerrainConfig == null) { throw new System.Exception("Planet Terrain Config is null."); }
    }
}
