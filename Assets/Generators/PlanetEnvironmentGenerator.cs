using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlanetGenerator))]
public class PlanetEnvironmentGenerator : MonoBehaviour
{
    private GroundEnvironmentGenerator groundEnvironmentGenerator;
    private OrbitalEnvironmentGenerator orbitalEnvironmentGenerator;

    private void Awake()
    {
        groundEnvironmentGenerator = this.gameObject.AddComponent<GroundEnvironmentGenerator>();
        orbitalEnvironmentGenerator = this.gameObject.AddComponent<OrbitalEnvironmentGenerator>();
    }

    public void Initialise(Vector3[] _terrainVerts, PlanetEnvironmentConfig _planetEnvironmentConfig, int _seed = 0)
    {
        groundEnvironmentGenerator.Initialise(_terrainVerts, _planetEnvironmentConfig.GroundConfig, _seed);
    }

    public void Generate()
    {
        groundEnvironmentGenerator.Generate();
    }

}
