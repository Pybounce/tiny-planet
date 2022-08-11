using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PybUtilities
{
    public class PybArray
    {

        public static T[] Concat<T>(T[] _firstArray, T[] _secondArray)
        {
            T[] _newArray = new T[_firstArray.Length + _secondArray.Length];
            for (int i = 0; i < _firstArray.Length; i++)
            {
                _newArray[i] = _firstArray[i];
            }
            for (int i = _firstArray.Length; i < _newArray.Length; i++)
            {
                _newArray[i] = _secondArray[i - _firstArray.Length];
            }
            return _newArray;
        }

    }

}
