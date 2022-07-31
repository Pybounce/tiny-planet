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
    }

}
