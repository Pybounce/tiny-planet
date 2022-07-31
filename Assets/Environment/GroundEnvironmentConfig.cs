using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GroundEnvironmentConfig_", menuName = "Scriptable Objects/Ground Environment Config")]
public class GroundEnvironmentConfig : ScriptableObject
{
    public GroundEnvironmentObject[] EnvironmentPrefabs;
    public float PerlinFrequency;
    [Range(0f, 1f), Tooltip("Perlin noise sampled at position. Object will not spawn if sampled value is below this.")]
    public float PerlinFloor = 1f;
    [Range (0f, 1f), Tooltip("Random chance. The object will not spawn if it fails this chance.")]
    public float SpawnChance = 1f;
}

[Serializable]
public struct GroundEnvironmentObject
{
    public GameObject Prefab;
    public int SpawnWeight;
    [Range(0.1f, 4f)]
    public float MinScale;
    [Range(0.1f, 4f)]
    public float MaxScale;
}
