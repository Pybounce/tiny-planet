using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PybUtilities
{
    public class PybMath
    {
        /// <summary>
        /// Returns true if inputted value is greater than or equal to a random float between 0 and 1.
        /// </summary>
        /// <param name="_chance"> Value should be between 0 and 1. </param>
        public static bool Chance(float _chance)
        {
            if (_chance >= Random.Range(0f, 1f)) { return true; }
            return false;
        }


        public static float PerlinNoise3D(float x, float y, float z, int _seed = 0, float _frequency = 1f)
        {
            x = (x * _frequency) + _seed;
            y = (y * _frequency) + _seed;
            z = (z * _frequency) + _seed;

            float xy = Mathf.PerlinNoise(x, y);
            float xz = Mathf.PerlinNoise(x, z);
            float yz = Mathf.PerlinNoise(y, z);
            float yx = Mathf.PerlinNoise(y, x);
            float zx = Mathf.PerlinNoise(z, x);
            float zy = Mathf.PerlinNoise(z, y);

            return (xy + xz + yz + yx + zx + zy) / 6f;
        }
        public static float PerlinNoise3D(Vector3 v3, int _seed = 0, float _frequency = 1f)
        {
            float _return = PerlinNoise3D(v3.x, v3.y, v3.z, _seed, _frequency);
            return _return;
        }
    }

}
