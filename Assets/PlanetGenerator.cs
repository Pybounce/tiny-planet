using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PybUtilities;

public class PlanetGenerator : MonoBehaviour
{
    private Vector3[] verts;
    private PlanetEnvironmentConfig config;

    public PlanetGenerator(PlanetEnvironmentConfig _config, Vector3[] _verts)
    {
        this.verts = _verts;
        this.config = _config;
    }

    public void GeneratePlanet()
    {
        if (CanGenerate() == false) { return; }

    }

    private void GenerateGroundObjects(GroundEnvironmentConfig[] _configs)
    {
        foreach (Vector3 _vert in verts)
        {
            foreach (GroundEnvironmentConfig _config in _configs)
            {
                //do normal chance
                //if pass, do perlin chance
                //if pass get object
                //if any fail, continue
                if (PybMath.Chance(_config.SpawnChance) == false) { continue; }

            }
        }
    }

    /// <summary>
    /// Checks the input data
    /// </summary>
    private bool CanGenerate()
    {
        if (verts == null || verts.Length <= 0) { return false; }
        if (config == null) { return false; }
        return true;
    }
}
