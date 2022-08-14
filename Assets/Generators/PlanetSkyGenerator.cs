using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSkyGenerator : MonoBehaviour
{
    private PlanetSkyConfig config;

    public void Initialise(PlanetSkyConfig _config)
    {
        this.config = _config;
    }

    public void Generate()
    {
        if (CheckNulls() == false) { return; }
        RenderSettings.skybox = config.SkyboxMat;
        RenderSettings.ambientSkyColor = config.AmbientColor;
    }

    private bool CheckNulls()
    {
        if (config == null) { return false; }
        if (config.SkyboxMat == null) { return false; }
        if (config.AmbientColor == null) { return false; }
        return true;
    }
}
