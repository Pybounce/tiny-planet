using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PybUtilities;


[RequireComponent(typeof(PlanetEnvironmentGenerator))]
public class GroundEnvironmentGenerator : MonoBehaviour
{
    private Vector3[] terrainVerts;
    private GroundEnvironmentConfig[] groundConfigs;


    public void Initialise(Vector3[] _terrainVerts, GroundEnvironmentConfig[] _groundConfigs)
    {
        this.terrainVerts = _terrainVerts;
        this.groundConfigs = _groundConfigs;
    }

    /// <summary>
    /// Loops through each vert and places an object if needed (based on groundEnvironmentConfig).
    /// </summary>
    public void Generate()
    {
        foreach (Vector3 _vert in terrainVerts)
        {
            foreach (GroundEnvironmentConfig _config in groundConfigs)
            {
                if (ConfigPassBasicChance(_config) == false) { continue; }
                if (ConfigPassPerlinChance(_config, _vert) == false) { continue; }
                GroundEnvironmentObject _objToPlace = GetObjectToPlace(_config);
                PlaceObjectAtVert(_objToPlace, _vert);
            }
        }
    }

    private bool ConfigPassBasicChance(GroundEnvironmentConfig _config)
    {
        return PybMath.Chance(_config.SpawnChance);
    }

    private bool ConfigPassPerlinChance(GroundEnvironmentConfig _config, Vector3 _vert)
    {
        return PybMath.PerlinNoise3D(_vert) >= _config.PerlinFloor;
    }

    /// <summary>
    /// Returns the environmental prefab containing the object to be placed.
    /// </summary>
    private GroundEnvironmentObject GetObjectToPlace(GroundEnvironmentConfig _config)
    {
        int _randomObjChance = Random.Range(0, _config.TotalWeight);
        foreach (var _prefab in _config.EnvironmentPrefabs)
        {
            if (_prefab.SpawnWeight >= _randomObjChance) { return _prefab; }
            _randomObjChance -= _prefab.SpawnWeight;
        }
        if (_config.EnvironmentPrefabs == null || _config.EnvironmentPrefabs.Length <= 0)
        {
            throw new System.Exception("Config must contain at least 1 envionmental config.");
        }
        Debug.LogWarning("GroundEnvironmentGenerator.GetObjectToPlace - chance check broken, returning default first.");
        return _config.EnvironmentPrefabs[0];   //If for some reason the above chance check doesn't pass, it will default to returning the first object.

    }

    /// <summary>
    /// Assuming all verts point out from the origin. Places an object on the vert at the correct angle.
    /// </summary>
    private void PlaceObjectAtVert(GroundEnvironmentObject _obj, Vector3 _vert)
    {
        GameObject _environmentObj = Instantiate(_obj.Prefab);
        _environmentObj.transform.position = _vert;
        _environmentObj.transform.rotation = Quaternion.LookRotation(_vert);
        _environmentObj.transform.Rotate(new Vector3(90f, 0f, 0f));
        _environmentObj.transform.localScale = Random.Range(_obj.MinScale, _obj.MaxScale) * Vector3.one;
    }

}
