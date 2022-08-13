using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PybUtilities;

public class PlanetGenerator : MonoBehaviour
{
    private PlanetTerrainGenerator planetTerrainGenerator;
    private PlanetEnvironmentGenerator planetEnvironmentGenerator;
    private int seed = 0;

    [SerializeField] private PlanetEnvironmentConfig planetEnvironmentConfig;
    [SerializeField] private PlanetTerrainConfig planetTerrainConfig;

    void Awake()
    {
        planetTerrainGenerator = this.gameObject.AddComponent<PlanetTerrainGenerator>();
        planetEnvironmentGenerator = this.gameObject.AddComponent<PlanetEnvironmentGenerator>();
    }

    private void Start()
    {
        seed = Random.Range(1000, 100000);
        CheckNulls();
        Generate();
    }

    public void Generate()
    {
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
