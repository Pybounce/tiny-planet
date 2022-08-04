using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PybUtilities;


[RequireComponent(typeof(PlanetEnvironmentGenerator))]
public class GroundEnvironmentGenerator : MonoBehaviour
{
    private Vector3[] terrainVerts;
    private GroundEnvironmentConfig[] groundConfigs;


    /// <summary>
    /// Loops through each vert and places an object if needed (based on groundEnvironmentConfig).
    /// </summary>
    public void Generate()
    {
        foreach (Vector3 _vert in terrainVerts)
        {
            foreach (GroundEnvironmentConfig _config in groundConfigs)
            {

            }
        }
    }

    /// <summary>
    /// Returns the environmental prefab containing the object to be placed.
    /// </summary>
    private bool ConfigPassBasicChance(GroundEnvironmentConfig _config)
    {
        return PybMath.Chance(_config.SpawnChance);
    }

    private GroundEnvironmentObject GetObjectToPlace(GroundEnvironmentConfig _config)
    {
        int _randomObjChance = Random.Range(0, _config.TotalWeight);
        foreach (var _prefab in _config.EnvironmentPrefabs)
        {
            if (_prefab.SpawnWeight <= _randomObjChance) { return _prefab; }
            _randomObjChance -= _prefab.SpawnWeight;
        }
        if (_config.EnvironmentPrefabs == null || _config.EnvironmentPrefabs.Length <= 0)
        {
            throw new System.Exception("Config must contain at least 1 envionmental config.");
        }
        Debug.LogWarning("GroundEnvironmentGenerator.GetObjectToPlace - chance check broken, returning default first.");
        return _config.EnvironmentPrefabs[0];   //If for some reason the above chance check doesn't pass, it will default to returning the first object.

    }


}
