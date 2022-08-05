using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PybUtilities;

public class PlanetGenerator : MonoBehaviour
{
    private PlanetTerrainGenerator planetTerrainGenerator;
    private PlanetEnvironmentGenerator planetEnvironmentGenerator;

    [SerializeField] private GroundEnvironmentConfig[] groundEnvironmentConfigs;
    [SerializeField] private GameObject tempPlanetVertObj;  //THIS IS TEMPORARY!

    private void Awake()
    {
        planetTerrainGenerator = this.gameObject.AddComponent<PlanetTerrainGenerator>();
        planetEnvironmentGenerator = this.gameObject.AddComponent<PlanetEnvironmentGenerator>();
    }

    private void Start()
    {
        Initialise();
        Generate();
    }

    public void Initialise()
    {
        planetEnvironmentGenerator.Initialise(tempPlanetVertObj.GetComponent<MeshFilter>().sharedMesh.vertices, groundEnvironmentConfigs);
    }

    public void Generate()
    {
        planetEnvironmentGenerator.Generate();
    }
}
