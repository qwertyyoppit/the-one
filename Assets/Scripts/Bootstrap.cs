using System;
using System.Collections.Generic;
using Systems;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    private static Bootstrap _instance;

    public static Bootstrap Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindAnyObjectByType<Bootstrap>();
            }

            if (!_instance)
            {
                _instance = new GameObject("Bootstrap").AddComponent<Bootstrap>();
            }

            return _instance;
        }
    }

    public static Dictionary<ISystem, ISystem> Systems = new();
}
