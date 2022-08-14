using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlanetSkyConfig_", menuName = "Scriptable Objects/Planet Sky Config")]
public class PlanetSkyConfig : ScriptableObject
{
    public Material SkyboxMat;
    public Color AmbientColor;
}

