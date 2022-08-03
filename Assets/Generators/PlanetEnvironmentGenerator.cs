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

}
