using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlanetEnvironmentConfig_", menuName = "Scriptable Objects/Planet Environment Config")]
public class PlanetEnvironmentConfig : ScriptableObject
{
    [Tooltip("In order of priority. 0 index overruling all.")]
    public GroundEnvironmentConfig[] GroundConfig;
}
