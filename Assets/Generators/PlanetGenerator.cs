using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PybUtilities;

public class PlanetGenerator : MonoBehaviour
{
    private PlanetTerrainGenerator planetTerrainGenerator;
    private PlanetEnvironmentGenerator planetEnvironmentGenerator;

    [SerializeField] private PlanetEnvironmentConfig planetEnvironmentConfig;
    [SerializeField] private PlanetTerrainConfig planetTerrainConfig;

    void Awake()
    {
        planetTerrainGenerator = this.gameObject.AddComponent<PlanetTerrainGenerator>();
        planetEnvironmentGenerator = this.gameObject.AddComponent<PlanetEnvironmentGenerator>();
    }

    private void Start()
    {
        CheckNulls();
        Generate();
    }

    public void Initialise()
    {
    }

    public void Generate()
    {
        planetTerrainGenerator.Initialise(planetTerrainConfig);
        planetTerrainGenerator.Generate();

        planetEnvironmentGenerator.Initialise(planetTerrainGenerator.TerrainMesh.vertices, planetEnvironmentConfig);
        planetEnvironmentGenerator.Generate();
    }

    private void CheckNulls()
    {
        if (planetEnvironmentConfig == null) { throw new System.Exception("Planet Environment Config is null."); }
        if (planetTerrainConfig == null) { throw new System.Exception("Planet Terrain Config is null."); }
    }
}
