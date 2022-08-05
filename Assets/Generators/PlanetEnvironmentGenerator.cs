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

    public void Initialise(Vector3[] _terrainVerts, GroundEnvironmentConfig[] _groundConfigs)
    {
        groundEnvironmentGenerator.Initialise(_terrainVerts, _groundConfigs);
    }

    public void Generate()
    {
        groundEnvironmentGenerator.Generate();
    }

}
