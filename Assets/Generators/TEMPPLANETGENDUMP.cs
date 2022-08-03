using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PybUtilities;

public class TEMPPLANETGENDUMP : MonoBehaviour
{
    private Vector3[] verts;
    private PlanetEnvironmentConfig config;

    public TEMPPLANETGENDUMP(PlanetEnvironmentConfig _config, Vector3[] _verts)
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
                if (_config.EnvironmentPrefabs.Length <= 0) { continue; }   //No objects in config to place
                if (PybMath.Chance(_config.SpawnChance) == false) { continue; } //Failed spawn chance check
                if (false) { continue; }    //*** ***Perlin Chance Check Goes Here*** ***\\  //Failed perlin chance check
                int _totalWeight = 0;
                foreach (var _prefab in _config.EnvironmentPrefabs)
                {
                    _totalWeight += _prefab.SpawnWeight;
                }
                GroundEnvironmentObject _selectedPrefab;
                int _randomObjChance = Random.Range(0, _totalWeight);
                foreach (var _prefab in _config.EnvironmentPrefabs)
                {
                    _selectedPrefab = _prefab;
                    if (_prefab.SpawnWeight <= _randomObjChance) { break; }
                    _randomObjChance -= _prefab.SpawnWeight;
                }

                //*** ***Spawn Object Here*** ***\\

                break;  //If an object has been placed on this point, we don't need to check the other configs.
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
